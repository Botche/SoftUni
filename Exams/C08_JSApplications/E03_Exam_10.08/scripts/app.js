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

    // Entities
    this.get('#/causes/create', controllers.entities.get.create);
    this.post('#/causes/create', controllers.entities.post.create);

    this.get('#/causes/details/:id', controllers.entities.get.details);

    this.post('#/causes/donate/:id', controllers.entities.post.donate);
    this.get('#/causes/delete/:id', controllers.entities.get.del);

})

app.run('#/');