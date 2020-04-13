import { homeViewHandler, aboutViewHandler } from './basicController.js';
import { loginViewHandler, registerViewHandler, logoutHandler } from './userController.js';
import { cataglogViewHandler } from './catalogController.js';
import { createTeamHandler, teamDetailsViewHandler, editTeamHandler, joinTeamHandler,leaveTeamHandler,deleteTeamHadler } from './teamController.js';

const app = new Sammy('#main', function (ctx) {
    this.use('Handlebars', 'hbs');

    this.get('/', homeViewHandler);
    this.get('/home', homeViewHandler);
    this.get('/about', aboutViewHandler);

    this.get('/login', loginViewHandler);
    this.post('/login', false);
    this.get('/register', registerViewHandler);
    this.post('/register', false);
    this.get('/logout', logoutHandler);

    this.get('/catalog', cataglogViewHandler);
    this.get('/create', createTeamHandler);
    this.post('/create', false);

    this.get('/catalog/:id', teamDetailsViewHandler);
    this.get('/edit/:id', editTeamHandler);

    this.get('/join/:id', joinTeamHandler);
    this.get('/leave', leaveTeamHandler);
    this.get('/delete/:id', deleteTeamHadler);
})

app.run('#/');