require('dotenv').config();

const env = process.env.NODE_ENV;

const mongoose = require('mongoose');
const config = require('./config/config')[env];
const app = require('express')();
const cookieParser = require('cookie-parser');

const indexRouter = require('./routes');
const userRouter = require('./routes/user');
const trippRouter = require('./routes/tripp');

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

app.use('/', indexRouter);
app.use('/', userRouter);
app.use('/', trippRouter);

app.get('*', (req, res) => {
    res.render('404', {
      title: 'Error'
    })
});

app.listen(config.port, console.log(`Listening on port ${config.port}! Now its up to you...`));