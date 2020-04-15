import models from '../models/index.js';

export default {
    get: {
        create(ctx) {
            ctx.email = sessionStorage.getItem('email');
            ctx.isLoggedIn = !!sessionStorage.getItem('token');

            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/ideas/create.hbs');
            })
        },
        async details(ctx) {
            ctx.email = sessionStorage.getItem('email');
            ctx.isLoggedIn = !!sessionStorage.getItem('token');

            const token = sessionStorage.getItem('token');

            const ideaFromDB = await models.requester.get(`/ideas/${ctx.params.id}.json?auth=${token}`);
            ideaFromDB.id = ctx.params.id;
            ideaFromDB.isAuthor = sessionStorage.getItem('userId') === ideaFromDB.authorId;

            if (ideaFromDB.comments) {
                ctx.commentsToDisplay = Object.values(ideaFromDB.comments);
            }

            Object.keys(ideaFromDB).forEach(key => {
                ctx[key] = ideaFromDB[key];
            })

            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/ideas/details.hbs');
            })
        },
        async del(ctx) {
            const token = sessionStorage.getItem('token');

            await models.requester.del(`/ideas/${ctx.params.id}.json?auth=${token}`)
                .then(response => {
                    ctx.redirect('#/home');
                })
                .catch(function (error) {
                    var errorCode = error.code;
                    var errorMessage = error.message;

                    document.getElementById('errorBox').innerText = errorMessage;
                    document.getElementById('errorBox').style.display = 'block';

                    setTimeout(function () {
                        document.getElementById('errorBox').style.display = 'none';
                    }, 5000)
                });
        },
        async like(ctx) {
            const token = sessionStorage.getItem('token');

            let likes = +document.querySelector('large').innerText + 1;
            await models.requester.update(`/ideas/${ctx.params.id}.json?auth=${token}`, {
                likes: likes
            })
                .then(response => {
                    ctx.redirect(`#/ideas/${ctx.params.id}`);
                })
                .catch(function (error) {
                    var errorCode = error.code;
                    var errorMessage = error.message;

                    document.getElementById('errorBox').innerText = errorMessage;
                    document.getElementById('errorBox').style.display = 'block';

                    setTimeout(function () {
                        document.getElementById('errorBox').style.display = 'none';
                    }, 5000)
                });
        },
    },
    post: {
        async create(ctx) {
            const { title, description, imageURL } = ctx.params;
            const token = sessionStorage.getItem('token');
            const authorId = sessionStorage.getItem('userId');

            if (title.lenght < 5 || description.lenght < 9 || !imageURL.startsWith('http://') || !imageURL.startsWith('https://')) {
                var errorMessage = 'Information is not valid.';

                document.getElementById('errorBox').innerText = errorMessage;
                document.getElementById('errorBox').style.display = 'block';

                setTimeout(function () {
                    document.getElementById('errorBox').style.display = 'none';
                }, 5000)

                return;
            }

            await models.requester.create(`/ideas.json?auth=${token}`, {
                authorId,
                title,
                description,
                imageURL,
                likes: 0,
                comments: []
            })
                .then(function () {

                    ctx.params.message = '123'
                    ctx.redirect('#/home');
                })
                .catch(function (error) {
                    var errorCode = error.code;
                    var errorMessage = error.message;

                    document.getElementById('errorBox').innerText = errorMessage;
                    document.getElementById('errorBox').style.display = 'block';

                    setTimeout(function () {
                        document.getElementById('errorBox').style.display = 'none';
                    }, 5000)
                });
        },
        async comment(ctx) {
            const token = sessionStorage.getItem('token');
            const { newComment, id } = ctx.params;
            await models.requester.create(`/ideas/${ctx.params.id}/comments.json?auth=${token}`, {
                author: sessionStorage.getItem('email'),
                comment: newComment,
                userId: id
            })
                .then(response => {
                    ctx.redirect(`#/ideas/${ctx.params.id}`);
                })
                .catch(function (error) {
                    var errorCode = error.code;
                    var errorMessage = error.message;

                    document.getElementById('errorBox').innerText = errorMessage;
                    document.getElementById('errorBox').style.display = 'block';

                    setTimeout(function () {
                        document.getElementById('errorBox').style.display = 'none';
                    }, 5000)
                });
        },
    }
}