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
                this.partial('../views/entities/create.hbs');
            })
        },
        async details(ctx) {
            ctx.email = sessionStorage.getItem('email');
            ctx.isLoggedIn = !!sessionStorage.getItem('token');

            const token = sessionStorage.getItem('token');

            const entityFromDb = await models.requester.get(`causes/${ctx.params.id}.json?auth=${token}`);
            entityFromDb.id = ctx.params.id;
            entityFromDb.isAuthor = sessionStorage.getItem('userId') === entityFromDb.authorId;

            Object.keys(entityFromDb).forEach(key => {
                ctx[key] = entityFromDb[key];
            })

            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/entities/details.hbs');
            })
        },
        async del(ctx) {
            const token = sessionStorage.getItem('token');

            await models.requester.del(`causes/${ctx.params.id}.json?auth=${token}`)
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
            const id = ctx.params.id;
            const token = sessionStorage.getItem('token');

            ctx.id = id;
            const entityFromDb = await models.requester.get(`causes/${ctx.params.id}.json?auth=${token}`);

            Object.keys(entityFromDb).forEach(key => {
                ctx[key] = entityFromDb[key];
            })

            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/entities/edit.hbs');
            })
        },
    },
    post: {
        create(ctx) {
            const { cause, pictureUrl, neededFunds, description } = ctx.params;
            const token = sessionStorage.getItem('token');
            const authorId = sessionStorage.getItem('userId');

            if (cause.length < 5
                || description.length < 9
                || !((pictureUrl.startsWith('http://')
                    || pictureUrl.startsWith('https://')))) {
                var errorMessage = 'Information is not valid.';

                document.getElementById('errorBox').innerText = errorMessage;
                document.getElementById('errorBox').style.display = 'block';

                setTimeout(function () {
                    document.getElementById('errorBox').style.display = 'none';
                }, 5000)

                return;
            }

            models.requester.create(`causes.json?auth=${token}`, {
                authorId,
                cause,
                pictureUrl,
                neededFunds,
                description,
                collectedFunds: 0,
                donors: [],
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
        donate(ctx) {
            const token = sessionStorage.getItem('token');

            const { currentDonation, id } = ctx.params;
            models.requester.get(`causes/${ctx.params.id}.json?auth=${token}`)
                .then(entityFromDb => {
                    models.requester.update(`causes/${ctx.params.id}.json?auth=${token}`, {
                        collectedFunds: entityFromDb['collectedFunds'] + +currentDonation,
                    })

                    return entityFromDb;
                })
                .then(response => {
                    if (!Object.values(response.donors).includes(sessionStorage.getItem('email'))) {
                        models.requester.update(`causes/${ctx.params.id}/donors/.json?auth=${token}`, {
                            [sessionStorage.getItem('userId')]: sessionStorage.getItem('email')
                        })
                    }
                })
                .then(response => ctx.redirect(`#/causes/details/${id}`));



        }
    }
}