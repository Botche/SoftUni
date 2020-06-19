const homeHandler = require('./home');
const staticFilesHandler = require('./static-files');
const catsHadler = require('./cat');

module.exports = [
    homeHandler,
    staticFilesHandler,
    catsHadler,
];