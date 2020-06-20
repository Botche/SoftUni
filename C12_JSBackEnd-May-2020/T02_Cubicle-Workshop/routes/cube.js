const env = process.env.NODE_ENV || 'development';

const { Router } = require('express');
const router = Router();
const Cube = require('../models/cude');
const { saveCube } = require('../controllers/cubes');
const { getCube } = require('../controllers/cubes');

router.get('/create-cube', (req, res) => {
    res.render('create', {
        title: 'Create Cube'
    });
});

router.post('/create-cube', (req, res) => {
    const {
        name,
        description,
        imageUrl,
        difficultyLevel
    } = req.body;

    const cube = new Cube(name, description, imageUrl, difficultyLevel);

    saveCube(cube, () => {
        res.redirect('/');
    });
});

router.get('/details/:id', (req, res) => {
    getCube(req.params.id, (cube) => {
        res.render('details', {
            title: 'Details',
            ...cube
        });
    });
})

module.exports = router;