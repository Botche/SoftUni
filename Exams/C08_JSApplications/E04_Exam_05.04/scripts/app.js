import controllers from '../controllers/index.js';

const app = new Sammy('#root', function () {
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

    // Articles
    this.get('#/articles/create', controllers.articles.get.create);
    this.post('#/articles/create', controllers.articles.post.create);

    this.get('#/articles/details/:id', controllers.articles.get.details);

    this.get('#/articles/edit/:id', controllers.articles.get.edit);
    this.post('#/articles/edit/:id', controllers.articles.post.edit);

    this.get('#/articles/delete/:id', controllers.articles.get.del);
})

app.run('#/');