const env = process.env.NODE_ENV || 'development';

const { Router } = require('express');
const router = Router();
const jwt = require('jsonwebtoken');
const config = require('../config/config')[env];

const Cube = require('../models/cude');

const { getCubeWithAccessories, getCube, editCube, deleteCube } = require('../controllers/cubes');
const { guestAccess, authAccess, getUserStatus } = require('../controllers/user');

router.get('/create/cube', authAccess, getUserStatus, (req, res) => {
    res.render('create', {
        title: 'Create Cube',
        isLoggedIn: req.isLoggedIn
    });
});

router.post('/create/cube', authAccess, (req, res) => {
    const {
        name,
        description,
        imageUrl,
        difficultyLevel
    } = req.body;

    const token = req.cookies['aid']
    const decodedObject = jwt.verify(token, config.privateKey)

    const cube = new Cube({ 
        name, 
        description, 
        imageUrl, 
        difficulty: difficultyLevel,
        creatorId: decodedObject.userID
    });

    cube.save((err) => {
        if (err) {
            console.log(err);

            res.redirect('/create/cube')
        } else {
            res.redirect('/');
        }
    });
});

router.get('/details/:id', getUserStatus, async (req, res) => {
    const cube = await getCubeWithAccessories(req.params.id);
     
    res.render('details', {
        title: 'Details',
        ...cube,
        isLoggedIn: req.isLoggedIn
    });
});

router.get('/edit/cube/:id', authAccess, getUserStatus, async (req, res) => {
    const cubeId = req.params.id;
    const cube = await getCube(cubeId);
    
    res.render('editCubePage', {
        title: 'Edit',
        ...cube,
        isLoggedIn: req.isLoggedIn
    });
});

router.post('/edit/cube/:id', authAccess, async (req, res) => {
    const cubeId = req.params.id;
    const { 
        name,
        description,
        imageUrl,
        difficultyLevel,
    } = req.body;
    
    const cube = await editCube(cubeId, name, description, imageUrl, difficultyLevel);
    
    res.redirect('/');
});

router.get('/delete/cube/:id', authAccess, getUserStatus, async (req, res) => {
    const cubeId = req.params.id;
    const cube = await getCube(cubeId);
    
    res.render('deleteCubePage', {
        title: 'Delete',
        ...cube,
        isLoggedIn: req.isLoggedIn
    });
});

router.post('/delete/cube/:id', authAccess, async (req, res) => {
    const cubeId = req.params.id;
    
    await deleteCube(cubeId);
    
    res.redirect('/');
});

module.exports = router;