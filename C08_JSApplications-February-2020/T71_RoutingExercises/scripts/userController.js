import { get } from "./requester.js";

async function applyCommon() {
    this.partials = {
        header: await this.load('../templates/common/header.hbs'),
        footer: await this.load('../templates/common/footer.hbs'),
    }

    this.email = sessionStorage.getItem('email');
    this.loggedIn = !!sessionStorage.getItem('token');
}

export async function loginViewHandler(ctx) {
    await applyCommon.call(this);
    this.partials.loginForm = await this.load('../templates/login/loginForm.hbs');

    await this.partial('../templates/login/loginPage.hbs');

    document.getElementById('login').addEventListener('click', async () => {
        const email = document.getElementById('email').value;
        const password = document.getElementById('password').value;

        await firebase.auth().signInWithEmailAndPassword(email, password)
            .then(response => {
                firebase.auth().currentUser.getIdToken()
                    .then(token => {
                        sessionStorage.setItem('token', token);
                        sessionStorage.setItem('email', response.user.email);
                        sessionStorage.setItem('userId', response.user.uid);

                        get('teams.json?auth=' + token)
                            .then(teams => {
                                for (const teamKey in teams) {
                                    for (const playerKey in teams[teamKey].players) {
                                        if (playerKey === response.user.uid) {
                                            sessionStorage.setItem('teamId', teamKey);
                                        }
                                    }
                                }
                            });
                    });

                ctx.redirect('#/');
            })
            .catch(error => {
                clearAlert('container');
                createAlert(error.message, 'container', 'loginForm')
            })
    })
}

export async function registerViewHandler(ctx) {
    await applyCommon.call(this);
    this.partials.registerForm = await this.load('../templates/register/registerForm.hbs');

    await this.partial('../templates/register/registerPage.hbs');


    document.getElementById('register').addEventListener('click', async () => {
        const email = document.getElementById('email');
        const password = document.getElementById('password');
        const repeatPassword = document.getElementById('repeatPassword');

        clearAlert('container');
        if (password.value !== repeatPassword.value) {
            createAlert('Passwords mismatched!', 'container', 'registerForm')

            password.value = '';
            repeatPassword.value = '';

            return;
        }

        await firebase.auth().createUserWithEmailAndPassword(email.value, password.value)
            .then(_ => {
                ctx.redirect('#/login');
            })
            .catch(error => {
                clearAlert('container');
                createAlert(error.message, 'container', 'registerForm')
            })
    })
}

export async function logoutHandler(ctx) {
    await applyCommon.call(this);
    sessionStorage.clear();
    firebase.auth().signOut();
    ctx.redirect('#/home');
}

function createAlert(message, parentNodeClassName, nodeToInsertBeforeId) {
    const errorMessage = document.createElement('div');
    errorMessage.classList.add('alert', 'alert-danger');
    errorMessage.role = 'alert';
    errorMessage.textContent = message;

    document.getElementsByClassName(parentNodeClassName)[0]
        .insertBefore(errorMessage, document.getElementById(nodeToInsertBeforeId));
}

function clearAlert(parentNodeClassName) {
    const alert = document.getElementsByClassName('alert')[0];

    if (alert) {
        document.getElementsByClassName(parentNodeClassName)[0].removeChild(alert);
    }
}