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
                    await ctx.redirect('#/user/login');
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
    },
    post: {
        login(ctx) {
            const { email, password } = ctx.params;

            models.user.login(email, password)
                .then(response => {
                    const token = response.user.ma;
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
            const { email, password } = ctx.params;

            const repeatPassword = ctx.params['rep-pass'];

            if (password !== repeatPassword) {
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