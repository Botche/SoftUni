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
    
    app.use('/js', express.static(__dirname + '/../node_modules/bootstrap/dist/js')); // redirect bootstrap JS
    app.use('/js', express.static(__dirname + '/../node_modules/jquery/dist')); // redirect JS jQuery
    app.use('/css', express.static(__dirname + '/../node_modules/bootstrap/dist/css')); // redirect CSS bootstrap
};