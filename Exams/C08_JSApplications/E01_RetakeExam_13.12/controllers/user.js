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

                    document.getElementById('successBox').innerText = 'Logout successfull';
                    document.getElementById('successBox').style.display = 'block';

                    setTimeout(function(){
                        document.getElementById('successBox').style.display = 'none';
                    }, 5000)
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

            const ideasFromDB = await models.requester.get(`/ideas.json?auth=${token}`);

            if (ideasFromDB) {
                const ideas = Array.from(Object.values(ideasFromDB))
                    .filter(idea => idea['authorId']
                        === sessionStorage.getItem('userId'));

                ctx.ideas = ideas;
                ctx.count = ideas.length;
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
            const { email, password, repeatPassword } = ctx.params;

            if (password !== repeatPassword || email.length < 3 || password.length < 3) {
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