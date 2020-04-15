import models from '../models/index.js';

export default {
    get: {
        async home(ctx) {
            const token = sessionStorage.getItem('token');
            if (token) {
                const ideasFromDB = await models.requester.get(`/ideas.json?auth=${token}`);
                if (ideasFromDB) {
                    ctx.ideas = Object.keys(ideasFromDB).map(id => ({ ...ideasFromDB[id], id }))
                        .sort((a, b) => b['likes'] - a['likes']);
                }
            }
            console.log(ctx);
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