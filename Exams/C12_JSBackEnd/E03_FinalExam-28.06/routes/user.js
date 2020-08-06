const { Router } = require('express');
const router = Router();

const { verifyUser, saveUser, getUserStatus, guestAccess, authAccess } = require('../controllers/user');

router.get('/login', guestAccess, getUserStatus, (req, res) => {
    res.render('login', {
        title: 'Login',
        isLoggedIn: req.isLoggedIn
    });
});

router.post('/login', guestAccess, async (req, res) => {

    const { error } = await verifyUser(req, res)

    if (error) {
        return res.render('login', {
            error: 'Username or password is not correct'
        })
    }

    res.redirect('/');
});

router.get('/register', guestAccess, getUserStatus, (req, res) => {
    res.render('register', {
        title: 'Register',
        isLoggedIn: req.isLoggedIn
    });
});

router.post('/register', guestAccess, async (req, res) => {

    const { 
        username,
        password,
        repeatPassword 
    } = req.body; 
    
    if (!password || !repeatPassword) {
        return res.render('register', {
            error: 'Not all fields are filled!',
            username
        });
    } else if (password !== repeatPassword) {
        return res.render('register', {
            error: "Passwords doesn't match!",
            username
        });
    } else if (password.length < 3) {
        return res.render('register', {
            error: 'Password must be more than 3 symbols.',
            username
        });
    } else if (!password.match(/^[A-Za-z0-9]+$/)) {
        return res.render('register', {
            error: 'Password should contains only english letters and numbers.',
            username
        });
    }

    const { error } = await saveUser(req, res);

    if (error) {
        console.log(error)
        return res.render('register', {
            error: 'Username or password is not valid.'
        })
    }

    res.redirect('/');
});

router.get('/logout', authAccess, (req, res) => {
    res.clearCookie('aid');

    res.redirect('/');
});

module.exports = router;