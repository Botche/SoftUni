import models from '../models/index.js';

export default {
    get: {
        async home(ctx) {
            const token = sessionStorage.getItem('token');
            if (token) {
                const trecksFromDb = await models.requester.get(`trecks.json?auth=${token}`)
                if (trecksFromDb) {
                    ctx.trecks = Object.keys(trecksFromDb).map(id => ({ ...trecksFromDb[id], id }))
                        .sort((a, b) => b['likes'] - a['likes']);
                }
            }

            ctx.email = sessionStorage.getItem('email');
            ctx.isLoggedIn = !!sessionStorage.getItem('token');

            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/home/home.hbs');
            })
        }
    }
}