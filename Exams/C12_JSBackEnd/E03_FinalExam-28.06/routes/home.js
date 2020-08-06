const env = process.env.NODE_ENV;

const jwt = require('jsonwebtoken');
const config = require('../config/config')[env];
const { Router } = require('express');
const router = Router();

const { getUserStatus } = require('../controllers/user');
const { getAllPlays } = require('../controllers/plays');

router.get('/', getUserStatus, async (req, res) => {
    const plays = await getAllPlays();
    
    plays.forEach(play => {
        play.isLoggedIn = req.isLoggedIn;
        play.likes = play.userLiked.length;
    });

    let filteredPlays;
    if (req.isLoggedIn) {
        const token = req.cookies['aid'];
        const decodedObject = jwt.verify(token, config.privateKey);
        
        filteredPlays = plays
            .filter(play => play.creatorId.toString() === decodedObject.userId || play.isPublic === true)
            .sort((a, b) => new Date(b.createdAt) - new Date(a.createdAt));
    } else {
        filteredPlays = plays
            .filter(play => play.isPublic)
            .sort((a, b) => b.userLiked.length - a.userLiked.length)
            .slice(0, 3);
    }

    res.render('home', {
        title: 'Home',
        isLoggedIn: req.isLoggedIn,
        plays: filteredPlays,
    })
});

module.exports = router;