const { Router } = require('express');
const router = Router();

const { getUserStatus } = require('../controllers/user');
const { getAllCourses } = require('../controllers/course');

router.get('/', getUserStatus, async (req, res) => {
    const courses = await getAllCourses();

    res.render('home', {
        title: 'Home',
        isLoggedIn: req.isLoggedIn,
        username: req.username,
        courses,
    });
});

module.exports = router;