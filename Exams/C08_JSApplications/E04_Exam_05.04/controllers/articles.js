import models from '../models/index.js';

// TODO check all paths
export default {
    get: {
        create(ctx) {
            ctx.email = sessionStorage.getItem('email');
            ctx.isLoggedIn = !!sessionStorage.getItem('token');

            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/articles/create.hbs');
            })
        },
        async details(ctx) {
            ctx.email = sessionStorage.getItem('email');
            ctx.isLoggedIn = !!sessionStorage.getItem('token');

            const token = sessionStorage.getItem('token');
            const { id } = ctx.params;

            const article = await models.requester.get(`/articles/${id}.json?auth=${token}`);

            article.id = id;
            article.isAuthor = sessionStorage.getItem('userId') === article.authorId;

            Object.keys(article).forEach(key => {
                ctx[key] = article[key];
            })

            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/articles/details.hbs');
            })
        },
        async del(ctx) {
            const token = sessionStorage.getItem('token');
            const { id } = ctx.params;

            await models.requester.del(`/articles/${id}.json?auth=${token}`)
                .then(response => {
                    ctx.redirect('#/home');
                })
                .catch(function (error) {
                    var errorCode = error.code;
                    var errorMessage = error.message;

                    console.log(errorMessage);
                });
        },
        async edit(ctx) {
            const token = sessionStorage.getItem('token');
            ctx.isLoggedIn = !!sessionStorage.getItem('token');

            const { id } = ctx.params;
            const article = await models.requester.get(`/articles/${id}.json?auth=${token}`);

            article.id = id;

            Object.keys(article).forEach(key => {
                ctx[key] = article[key];
            })

            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/articles/edit.hbs');
            })
        },
    },
    post: {
        create(ctx) {
            const { title, category, content } = ctx.params;

            const token = sessionStorage.getItem('token');
            const authorId = sessionStorage.getItem('userId');


            models.requester.create(`articles.json?auth=${token}`, {
                authorId,
                title,
                category,
                content,
            })
                .then(function () {
                    ctx.redirect('#/home');
                })
                .catch(function (error) {
                    var errorCode = error.code;
                    var errorMessage = error.message;

                    console.log(errorMessage);
                });
        },
        edit(ctx) {
            const token = sessionStorage.getItem('token');
            const { title, category, content, id } = ctx.params;

            models.requester.update(`/articles/${id}.json?auth=${token}`, {
                title,
                category,
                content,
            })
                .then(response => {
                    ctx.redirect(`#/`);
                })
                .catch(function (error) {
                    var errorCode = error.code;
                    var errorMessage = error.message;

                    console.log(errorMessage);
                });
        }
    }
}