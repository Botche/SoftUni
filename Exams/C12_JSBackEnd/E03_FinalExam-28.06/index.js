require('dotenv').config();

const env = process.env.NODE_ENV;

const mongoose = require('mongoose');
const config = require('./config/config')[env];
const app = require('express')();
const cookieParser = require('cookie-parser');
const routes = require('./routes');
const { getUserStatus } = require('./controllers/user');

mongoose.connect(config.databaseUrl, {
  useNewUrlParser: true,
  useUnifiedTopology: true,
  useFindAndModify: false,
}, (err) => {
  if (err) {
    console.log(err);
    throw err;
  }

  console.log('Database is setup and running');
});

require('./config/express')(app);

app.use(cookieParser());

app.use('/', routes.homeRouter);
app.use('/user', routes.userRouter);
app.use('/play', routes.playRouter);

app.get('*', getUserStatus, (req, res) => {
    res.render('404', {
      title: '404 Not found',
      isLoggedIn: req.isLoggedIn,
    });
});

app.listen(config.port, console.log(`Listening on port ${config.port}! Now its up to you...`));