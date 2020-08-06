const env = process.env.NODE_ENV;

const User = require('../models/user');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const config = require('../config/config')[env];

const saltRounds = 10;

const generateToken = user => {
    const token = jwt.sign(user, config.privateKey);

    return token;
}

const saveUser = async (req, res) => {
    const { email, password } = req.body;

    const salt = await bcrypt.genSalt(saltRounds);
    const hashedPassword = await bcrypt.hash(password, salt);

    try {
        const user = new User({
            email,
            password: hashedPassword,
        });

        const userObject = await user.save();

        const token = generateToken({
            userID: userObject._id,
            email: userObject.email,
        });

        res.cookie('aid', token);

        return token;
    } catch (err) {
        
        return {
            error: true,
            message: err
        }
    }
};


const verifyUser = async (req, res) => {
    const {
        email,
        password
    } = req.body;

    try {
        const user = await User.findOne({ email });
        
        if (!user) {
            return {
                error: true,
                message: 'There is no such user'
            }
        }

        const status = await bcrypt.compare(password, user.password);
        if (status) {
            const token = generateToken({
                userID: user._id,
                email: user.email
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
        const decoded = jwt.verify(token, config.privateKey);
        req.isLoggedIn = true;
        req.email = decoded.email;
    } catch (e) {
        req.isLoggedIn = false;
    }

    next();
};

module.exports = {
    saveUser,
    authAccess,
    verifyUser,
    guestAccess,
    getUserStatus,
};