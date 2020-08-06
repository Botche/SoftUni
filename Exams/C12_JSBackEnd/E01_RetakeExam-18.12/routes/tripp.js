const env = process.env.NODE_ENV || 'development';

const { Router } = require('express');
const router = Router();
const jwt = require('jsonwebtoken');
const config = require('../config/config')[env];

const Tripp = require('../models/tripp');

const { getUserStatus, authAccess } = require('../controllers/users');
const { getAllTripps, getTripp, getEmailsOfJoinedBuddiesByTrippId, caclulateFreeSeatsForTripp, getCreatorEmail, deleteTripp, joinTripp } = require('../controllers/tripps');

router.get('/tripp/all', authAccess, getUserStatus, async (req, res) => {
    const tripps = await getAllTripps();

    res.render('sharedTripps', {
        isLoggedIn: req.isLoggedIn,
        email: req.email,
        title: 'Shared tripps',
        sharedTripps: tripps,
    });
});

router.get('/tripp/offer', authAccess, getUserStatus, (req, res) => {
    res.render('offerTripp', {
        isLoggedIn: req.isLoggedIn,
        email: req.email,
        title: 'Offer tripp'
    });
});

router.post('/tripp/offer', authAccess, getUserStatus, async (req, res) => {
    const {
        startAndEndPoints,
        dateTime,
        carImage,
        seats,
        description
    } = req.body;

    const [startPoint, endPoint] = startAndEndPoints.split(' - ');

    if (!startPoint || !endPoint || startPoint.length < 4 || endPoint.length < 4) {
        return res.render('offerTripp', {
            isLoggedIn: req.isLoggedIn,
            email: req.email,
            title: 'Offer tripp',
            error: 'Tripp details are not valid'
        });
    }

    const [date, time] = dateTime.split(' - ');

    if (!startPoint || !endPoint || !seats || !description
        || startPoint.length < 6 
        || endPoint.length < 6 
        || seats < 1 
        || description.length < 10) {
        return res.render('offerTripp', {
            isLoggedIn: req.isLoggedIn,
            email: req.email,
            title: 'Offer tripp',
            error: 'Tripp details are not valid'
        });
    }

    try {
        new URL(carImage);
    } catch (_) {
        return res.render('offerTripp', {
            isLoggedIn: req.isLoggedIn,
            email: req.email,
            title: 'Offer tripp',
            error: 'Car image should be valid url address'
        });
    }

    const token = req.cookies['aid'];
    const decodedObject = jwt.verify(token, config.privateKey);

    const tripp = new Tripp({
        startPoint: startPoint,
        endPoint: endPoint,
        date: date,
        time: time,
        seats: seats,
        description: description,
        carImage: carImage,
        creatorId: decodedObject.userID,
    });

    try {
        await tripp.save();
        return res.redirect('/tripp/all');
    } catch (error) {
        return res.render('offerTripp', {
            isLoggedIn: req.isLoggedIn,
            email: req.email,
            title: 'Offer tripp',
            error: 'Tripp details are not valid'
        });
    }
});

router.get('/tripp/details/:id', authAccess, getUserStatus, async (req, res) => {
    const trippId = req.params.id;
    const tripp = await getTripp(trippId);

    const token = req.cookies['aid'];
    const decodedObject = jwt.verify(token, config.privateKey);

    const creatorEmail = await getCreatorEmail(trippId);

    let isOwner, alreadyJoined;

    if (tripp.creatorId.toString() === decodedObject.userID) {
        isOwner = true;
    } else {
        alreadyJoined = tripp.buddies
            .map(buddyId => buddyId.toString())
            .includes(decodedObject.userID);
    }

    const { areThereFreeSeats, freeSeats } = caclulateFreeSeatsForTripp(tripp);

    const joinedBuddies = await getEmailsOfJoinedBuddiesByTrippId(trippId);

    res.render('driverTrippDetails', {
        isLoggedIn: req.isLoggedIn,
        email: req.email,
        title: 'Shared tripps',
        ...tripp,
        isOwner,
        alreadyJoined,
        areThereFreeSeats,
        freeSeats,
        joinedBuddies,
        creatorEmail
    });
});

router.get('/tripp/close/:id', authAccess, getUserStatus, async (req, res) => {
    try {
        const trippId = req.params.id;

        const token = req.cookies['aid'];
        jwt.verify(token, config.privateKey);

        await deleteTripp(trippId);

        return res.redirect('/tripp/all');
    } catch (error) {

        return res.redirect('/tripp/all');
    }
});

router.get('/tripp/join/:id', authAccess, getUserStatus, async (req, res) => {
    const token = req.cookies['aid'];
    const decodedObject = jwt.verify(token, config.privateKey);
    const trippId = req.params.id;

    await joinTripp(trippId, decodedObject.userID);

    return res.redirect('/tripp/all');
});

module.exports = router;