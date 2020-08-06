const env = process.env.NODE_ENV;

const jwt = require('jsonwebtoken');
const config = require('../config/config')[env];
const { Router } = require('express');
const router = Router();

const { getUserStatus, authAccess, isOwner } = require('../controllers/user');
const { createPlay, getAllPlays, getPlayById, checkIfIsAlreadyJoined, likePlay, deletePlayById, editPlayById } = require('../controllers/plays');

router.get('/create', authAccess, getUserStatus, (req, res) => {
    res.render('create-theater', {
        title: 'Create',
        isLoggedIn: req.isLoggedIn,
    });
});

router.post('/create', authAccess, getUserStatus, async (req, res) => {
    const {
        playTitle,
        description,
        imageUrl,
        isPublic,
    } = req.body;

    if (!playTitle || !description || !imageUrl) {
        return res.render('create-theater', {
            title: 'Create',
            isLoggedIn: req.isLoggedIn,
            error: 'You cannot have empty fields!',
            playTitle,
            description,
            imageUrl,
            isPublic,
        });
    }

    const { error } = await createPlay(req, res);

    if (error) {
        return res.render('create-theater', {
            title: 'Create',
            isLoggedIn: req.isLoggedIn,
            error: 'Something went wrong!',
            playTitle,
            description,
            imageUrl,
            error: error
        });
    }

    res.redirect('/');
});

router.get('/details/:id', authAccess, getUserStatus, async (req, res) => {
    const playId = req.params.id;
    const play = await getPlayById(playId);

    const isOwnerBool = await isOwner(req, res);
    const isAlreadyLiked = await checkIfIsAlreadyJoined(req, res);

    res.render('theater-details', {
        title: 'Details',
        isLoggedIn: req.isLoggedIn,
        ...play,
        isCreator: isOwnerBool,
        isAlreadyLiked,
    })
});

router.get('/like/:id', authAccess, async (req, res) => {
    const playId = req.params.id;
    const token = req.cookies['aid'];
    const decodedObject = jwt.verify(token, config.privateKey);

    const { error } = await likePlay(playId, decodedObject.userId);

    if (error) {
        res.render(`/play/details/${playId}`, {
            title: 'Details',
            error
        });
    }

    res.redirect(`/play/details/${playId}`);
});

router.get('/delete/:id', authAccess, getUserStatus, async (req, res) => {
    const playId = req.params.id;

    const { error } = await deletePlayById(playId);

    if (error) {
        res.render(`/play/details/${playId}`, {
            title: 'Details',
            isLoggedIn: req.isLoggedIn,
            error
        });
    }

    res.redirect(`/`);
});

router.get('/edit/:id', authAccess, getUserStatus, async (req, res) => {
    const playId = req.params.id;
    const play = await getPlayById(playId);

    res.render(`edit-theater`, {
        title: 'Edit',
        isLoggedIn: req.isLoggedIn,
        ...play,
    });
});

router.post('/edit/:id', authAccess, getUserStatus, async (req, res) => {
    const {
        playTitle,
        description,
        imageUrl,
        isPublic
    } = req.body;

    if (!playTitle || !description || !imageUrl) {

        return res.render('create-theater', {
            title: 'Create',
            isLoggedIn: req.isLoggedIn,
            error: 'You cannot have empty fields!',
            playTitle,
            description,
            imageUrl,
            isPublic
        });
    }

    const playId = req.params.id;
    const { error } = await editPlayById(playId, playTitle, description, imageUrl, isPublic);

    if (error) {
        const playId = req.params.id;
        const play = await getPlayById(playId);

        return res.render(`edit-theater`, {
            title: 'Edit',
            isLoggedIn: req.isLoggedIn,
            ...play,
            error,
        })
    }

    res.redirect('/');
});

router.get('/sort', authAccess, getUserStatus, async (req, res) => {
    const plays = await getAllPlays();

    plays.forEach(play => {
        play.isLoggedIn = req.isLoggedIn;
        play.likes = play.userLiked.length;
    });

    const token = req.cookies['aid'];
    const decodedObject = jwt.verify(token, config.privateKey);
    let filteredPlays = plays.filter(play => play.creatorId.toString() === decodedObject.userId || play.isPublic === true)

    if (req.query.type === 'date') {
        filteredPlays = filteredPlays.sort((a, b) => new Date(b.createdAt) - new Date(a.createdAt));
    } else if (req.query.type === 'likes') {
        filteredPlays = filteredPlays.sort((a, b) => b.userLiked.length - a.userLiked.length);
    }
    
    res.render('home', {
        title: 'Home',
        isLoggedIn: req.isLoggedIn,
        plays: filteredPlays,
    });
});

module.exports = router;