const env = process.env.NODE_ENV || 'development';

const { Router } = require('express');
const router = Router();
const jwt = require('jsonwebtoken');
const config = require('../config/config')[env];

const { getUserStatus, authAccess } = require('../controllers/user');
const { saveCourse, getCourse, enrollInCourse } = require('../controllers/course');

router.get('/create', authAccess, getUserStatus, (req, res) => {
    res.render('course-create', {
        title: 'Create',
        username: req.username,
        isLoggedIn: req.isLoggedIn
    });
});

router.post('/create', authAccess, getUserStatus, async (req, res) => {

    const { error } = await saveCourse(req, res);

    if (error) {
        return res.render('course-create', {
            error: 'Course details are not valid.'
        })
    }

    res.redirect('/');
});

router.get('/details/:id', authAccess, getUserStatus, async (req, res) => {
    const courseId = req.params.id;
    const course = await getCourse(courseId);

    res.render('details', {
        title: 'Details',
        username: req.username,
        isLoggedIn: req.isLoggedIn,
        ...course,
    });
});

router.get('/enroll/:id', authAccess, getUserStatus, async (req, res) => {
    const courseId = req.params.id;
    const course = await getCourse(courseId);
    const token = req.cookies['aid'];
    const decodedObject = jwt.verify(token, config.privateKey);

    const { error } = await enrollInCourse(decodedObject.userId, courseId);
    
    res.render('details', {
        title: 'Details',
        username: req.username,
        isLoggedIn: req.isLoggedIn,
        ...course,
        error
    });
});

module.exports = router;