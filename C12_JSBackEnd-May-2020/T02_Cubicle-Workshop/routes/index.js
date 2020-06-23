const { Router } = require('express');

const { getAllCubes } = require('../controllers/cubes');
const { getUserStatus } = require('../controllers/user');

const router = Router();

router.get('/', getUserStatus, async (req, res) => {
    const allCubes = await getAllCubes();

    res.render('index', {
        title: 'Home',
        cubes: allCubes,
        isLoggedIn: req.isLoggedIn
    });
});

router.get('/about', getUserStatus, (req, res) => {
    res.render('about', {
        title: 'About',
        isLoggedIn: req.isLoggedIn
    });
});

module.exports = router;