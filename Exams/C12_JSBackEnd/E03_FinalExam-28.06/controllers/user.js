const env = process.env.NODE_ENV;

const User = require('../models/user');
const Play = require('../models/play');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const config = require('../config/config')[env];

const saltRounds = 10;

const generateToken = user => {
    const token = jwt.sign(user, config.privateKey);

    return token;
}

const saveUser = async (req, res) => {
    const { username, password } = req.body;

    const salt = await bcrypt.genSalt(saltRounds);
    const hashedPassword = await bcrypt.hash(password, salt);

    try {
        const user = new User({
            username,
            password: hashedPassword,
        });

        const userObject = await user.save();

        const token = generateToken({
            userId: userObject._id,
            username: userObject.username,
        });

        res.cookie('aid', token);

        return token;
    } catch (err) {
        
        return {
            error: err
        }
    }
};


const verifyUser = async (req, res) => {
    const {
        username,
        password
    } = req.body;

    try {
        const user = await User.findOne({ username });

        if (!user) {
            return {
                error: true,
                message: 'There is no such user'
            }
        }

        const status = await bcrypt.compare(password, user.password);
        if (status) {
            const token = generateToken({
                userId: user._id,
                username: user.username
            });

            res.cookie('aid', token);
        }

        return {
            error: !status,
            message: status || 'Wrong password'
        }
    } catch (err) {

        return {
            error: true,
            message: 'There is no such user',
            status
        };
    }

}

const authAccess = (req, res, next) => {
    const token = req.cookies['aid'];
    if (!token) {
        return res.redirect('/');
    }

    try {
        jwt.verify(token, config.privateKey);
        next();
    } catch (e) {
        return res.redirect('/');
    }
}

const guestAccess = (req, res, next) => {
    const token = req.cookies['aid'];
    if (token) {
        return res.redirect('/');
    }
    next();
}

const getUserStatus = (req, res, next) => {
    const token = req.cookies['aid'];
    if (!token) {
        req.isLoggedIn = false;
    }

    try {
        jwt.verify(token, config.privateKey)
        req.isLoggedIn = true;
    } catch (e) {
        req.isLoggedIn = false;
    }

    next();
};

const isOwner = async (req, res) => {
    const playId = req.params.id;
    const play = await Play.findById(playId).lean();

    const token = req.cookies['aid'];
    const decodedObject = jwt.verify(token, config.privateKey);

    return play.creatorId.toString() === decodedObject.userId;
}


module.exports = {
    saveUser,
    authAccess,
    verifyUser,
    guestAccess,
    getUserStatus,
    isOwner,
};