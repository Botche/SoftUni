const { Router } = require('express');
const router = Router();

const { getUserStatus } = require('../controllers/users');

router.get('/', getUserStatus, (req, res) => {
    res.render('home', {
        title: 'Home',
        isLoggedIn: req.isLoggedIn,
        email: req.email,
    });
});

module.exports = router;