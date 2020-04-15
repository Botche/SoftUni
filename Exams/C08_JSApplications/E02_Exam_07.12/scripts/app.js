import controllers from '../controllers/index.js';

const app = new Sammy('#main', function () {
    this.use('Handlebars', 'hbs');

    // Home
    this.get('#/', controllers.home.get.home);
    this.get('#/home', controllers.home.get.home);

    // User
    this.get('#/user/login', controllers.user.get.login);
    this.post('#/user/login', controllers.user.post.login);

    this.get('#/user/register', controllers.user.get.register);
    this.post('#/user/register', controllers.user.post.register);

    this.get('#/user/logout', controllers.user.get.logout);

    this.get('#/user/account', controllers.user.get.account)

    // Trecks
    this.get('#/trecks/create', controllers.trecks.get.create);
    this.post('#/trecks/create', controllers.trecks.post.create);

    this.get('#/trecks/details/:id', controllers.trecks.get.details);

    this.get('#/trecks/edit/:id', controllers.trecks.get.edit);
    this.post('#/trecks/edit/:id', controllers.trecks.post.edit);

    this.get('#/trecks/like/:id', controllers.trecks.get.like);
    this.get('#/trecks/delete/:id', controllers.trecks.get.del);

})

app.run('#/');