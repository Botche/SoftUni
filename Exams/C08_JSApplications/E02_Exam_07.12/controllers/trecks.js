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
                this.partial('../views/trecks/create.hbs');
            })
        },
        async details(ctx) {
            ctx.email = sessionStorage.getItem('email');
            ctx.isLoggedIn = !!sessionStorage.getItem('token');

            const token = sessionStorage.getItem('token');

            const treckFromDb = await models.requester.get(`/trecks/${ctx.params.id}.json?auth=${token}`);
            treckFromDb.id = ctx.params.id;
            treckFromDb.isAuthor = sessionStorage.getItem('userId') === treckFromDb.authorId;

            Object.keys(treckFromDb).forEach(key => {
                ctx[key] = treckFromDb[key];
            })

            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/trecks/details.hbs');
            })
        },
        async del(ctx) {
            const token = sessionStorage.getItem('token');

            await models.requester.del(`/trecks/${ctx.params.id}.json?auth=${token}`)
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
        async edit(ctx) {
            const treckId = ctx.params.id;
            const token = sessionStorage.getItem('token');

            ctx.id = treckId;
            const treckFromDb = await models.requester.get(`/trecks/${ctx.params.id}.json?auth=${token}`);
            Object.keys(treckFromDb).forEach(key => {
                ctx[key] = treckFromDb[key];
            })

            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/trecks/edit.hbs');
            })
        },
        async like(ctx) {
            const token = sessionStorage.getItem('token');

            let likes = +document.querySelectorAll('large')[1].innerText + 1;
            await models.requester.update(`/trecks/${ctx.params.id}.json?auth=${token}`, {
                likes: likes
            })
                .then(response => {
                    ctx.redirect(`#/trecks/details/${ctx.params.id}`);
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
        create(ctx) {
            console.log(ctx)
            const { location, dateTime, imageURL, description } = ctx.params;
            const token = sessionStorage.getItem('token');
            const authorId = sessionStorage.getItem('userId');

            if (location.length < 5 || description.length < 9 || !((imageURL.startsWith('http://') || imageURL.startsWith('https://')))) {
                var errorMessage = 'Information is not valid.';

                document.getElementById('errorBox').innerText = errorMessage;
                document.getElementById('errorBox').style.display = 'block';

                setTimeout(function () {
                    document.getElementById('errorBox').style.display = 'none';
                }, 5000)

                return;
            }

            models.requester.create(`trecks.json?auth=${token}`, {
                authorId,
                location,
                dateTime,
                description,
                imageURL,
                likes: 0,
            })
                .then(function () {
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
        edit(ctx) {
            const token = sessionStorage.getItem('token');
            const { likes, organizer, imageURL, description, location, dateTime } = ctx.params;

             models.requester.update(`/trecks/${ctx.params.id}.json?auth=${token}`, {
                authorId: organizer,
                location,
                description,
                dateTime,
                imageURL,
                likes
            })
                .then(response => {
                    ctx.redirect(`#/trecks/details/${ctx.params.id}`);
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
        }
    }
}