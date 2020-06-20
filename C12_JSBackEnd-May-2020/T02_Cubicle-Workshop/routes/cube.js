const env = process.env.NODE_ENV || 'development';

const { Router } = require('express');
const router = Router();
const Cube = require('../models/cude');
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

    const cube = new Cube({ name, description, imageUrl, difficulty: difficultyLevel });

    cube.save((err) => {
        if (err) {
            console.log(err);
        } else {
            res.redirect('/');
        }
    });
});

router.get('/details/:id', async (req, res) => {
    const cube = await getCube(req.params.id);
    
    res.render('details', {
        title: 'Details',
        ...cube
    });
})

module.exports = router;