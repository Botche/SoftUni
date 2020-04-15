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

    // Ideas
    this.get('#/ideas/create', controllers.ideas.get.create);
    this.post('#/ideas/create', controllers.ideas.post.create);

    this.get('#/ideas/:id', controllers.ideas.get.details);

    this.get('#/ideas/like/:id', controllers.ideas.get.like);
    this.get('#/ideas/delete/:id', controllers.ideas.get.del);

    this.post('#/ideas/comment/:id', controllers.ideas.post.comment);
})

app.run('#');