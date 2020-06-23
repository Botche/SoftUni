const { Router } = require('express');
const router = Router();

const { verifyUser, saveUser, getUserStatus, guestAccess, authAccess } = require('../controllers/user');

router.get('/login', guestAccess, getUserStatus, (req, res) => {
    res.render('loginPage', {
        title: 'Login',
        isLoggedIn: req.isLoggedIn
    });
});

router.post('/login', guestAccess, async (req, res) => {
    
    const { error } = await verifyUser(req, res)

    if (error) {
        return res.render('loginPage', {
            error: 'Username or password is not correct'
        })
    }

    res.redirect('/');
});

router.get('/register', guestAccess, getUserStatus, (req, res) => {
    res.render('registerPage', {
        title: 'Register',
        isLoggedIn: req.isLoggedIn
    });
});

router.post('/register', guestAccess, async (req, res) => {
    await saveUser(req, res);

    res.redirect('/');
});

router.get('/logout', authAccess, (req, res) => {
    res.clearCookie('aid');

    res.redirect('/');
});

module.exports = router;