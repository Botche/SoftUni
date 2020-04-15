import models from '../models/index.js';

export default {
    get: {
        async home(ctx) {
            const token = sessionStorage.getItem('token');
            if (token) {
                // Change path to firebase
                const collectionFromDb = await models.requester.get(`causes.json?auth=${token}`)
                if (collectionFromDb) {
                    ctx.causes = Object.keys(collectionFromDb).map(id => ({ ...collectionFromDb[id], id }))
                        // .sort((a, b) => b['likes'] - a['likes']);
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