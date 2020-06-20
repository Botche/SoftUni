const { Router } = require('express');
const { getAllCubes } = require('../controllers/cubes');

const router = Router();

router.get('/', async (req, res) => {
    res.render('index', {
        title: 'Home',
        cubes: await getAllCubes(),
    });
});

router.get('/about', (req, res) => {
    res.render('about', {
        title: 'About'
    });
});

module.exports = router;