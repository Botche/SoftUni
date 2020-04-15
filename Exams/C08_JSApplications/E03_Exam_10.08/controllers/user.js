import models from '../models/index.js';

export default {
    get: {
        login(ctx) {
            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/user/login.hbs');
            })
        },
        register(ctx) {
            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/user/register.hbs');
            })
        },
        logout(ctx) {
            ctx.email = sessionStorage.getItem('email');
            ctx.isLoggedIn = !!sessionStorage.getItem('token');

            models.user.logout()
                .then(async function () {
                    sessionStorage.clear();
                    await ctx.redirect('#/home');
                })
                .catch(function (error) {
                    var errorCode = error.code;
                    var errorMessage = error.message;
                    
                    document.getElementById('errorBox').innerText = errorMessage;
                    document.getElementById('errorBox').style.display = 'block';

                    setTimeout(function(){
                        document.getElementById('errorBox').style.display = 'none';
                    }, 5000)
                });
        },
        async account(ctx) {
            const token = sessionStorage.getItem('token');

            ctx.email = sessionStorage.getItem('email');
            ctx.isLoggedIn = !!sessionStorage.getItem('token');

            const entitiesFromDB = await models.requester.get(`/trecks.json?auth=${token}`);

            if (entitiesFromDB) {
                const entities = Array.from(Object.values(entitiesFromDB))
                    .filter(treck => treck['authorId']
                        === sessionStorage.getItem('userId'));

                ctx.entities = entities;
                ctx.count = entities.length;
            }

            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/user/profile.hbs');
            })
        }
    },
    post: {
        login(ctx) {
            const { email, password } = ctx.params;

            models.user.login(email, password)
                .then(response => {
                    const token = response.user.xa;
                    sessionStorage.setItem('token', token);
                    sessionStorage.setItem('email', response.user.email);
                    sessionStorage.setItem('userId', response.user.uid);

                    ctx.redirect('#/');
                })
                .catch(function (error) {
                    var errorCode = error.code;
                    var errorMessage = error.message;
                    
                    document.getElementById('errorBox').innerText = errorMessage;
                    document.getElementById('errorBox').style.display = 'block';

                    setTimeout(function(){
                        document.getElementById('errorBox').style.display = 'none';
                    }, 5000)
                });
            ctx.isLoggedIn = true;
        },
        register(ctx) {
            const { email, password, rePassword } = ctx.params;

            if (password !== rePassword) {
                return;
            }

            models.user.register(email, password)
                .then(_ => {
                    ctx.redirect('#/user/login');
                })
                .catch(function (error) {
                    var errorCode = error.code;
                    var errorMessage = error.message;

                    document.getElementById('errorBox').innerText = errorMessage;
                    document.getElementById('errorBox').style.display = 'block';

                    setTimeout(function(){
                        document.getElementById('errorBox').style.display = 'none';
                    }, 5000)
                });
        }
    }
}