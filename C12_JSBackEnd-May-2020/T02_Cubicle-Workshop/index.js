const env = process.env.NODE_ENV || 'development';

const mongoose = require('mongoose');
const config = require('./config/config')[env];
const app = require('express')();
const indexRouter = require('./routes/index');
const cubeRouter = require('./routes/cube');

mongoose.connect(config.databaseUrl, {
  useNewUrlParser: true,
  useUnifiedTopology: true
}, (err) => {
  if (err) {
    console.log(err);
    throw err;
  }

  console.log('Database is setup and running');
});

require('./config/express')(app);

app.use('/', indexRouter);
app.use('/', cubeRouter);

app.get('*', (req, res) => {
    res.render('404', {
      title: 'Error'
    })
});

app.listen(config.port, console.log(`Listening on port ${config.port}! Now its up to you...`));