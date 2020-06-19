const { Router } = require('express');
const { getAllCubes } = require('../controllers/cubes');

const router = Router();

router.get('/', (req, res) => {
    getAllCubes((cubes) => {
        res.render('index', {
            title: 'Home',
            cubes: cubes,
        });
    });
});

router.get('/about', (req, res) => {
    res.render('about', {
        title: 'About'
    });
});

module.exports = router;