const express = require('express');
const handlebars = require('express-handlebars');
const path = require('path');

module.exports = (app) => {

    app.use(express.json());
    
    app.use(express.urlencoded({ extended: true }));

    app.set('view engine', '.hbs');
    app.engine('hbs', handlebars({
      layoutsDir: path.join(__dirname, "../views/layouts"),
      partialsDir: path.join(__dirname, "../views/partials"),
      defaultLayout:'main.hbs',
      extname: 'hbs'
    }));

    app.use('/static', express.static('static'));
};