const env = process.env.NODE_ENV;

const User = require('../models/user');
const Play = require('../models/play');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const config = require('../config/config')[env];


const createPlay = async (req, res) => {
    const {
        playTitle,
        description,
        imageUrl,
        isPublic
    } = req.body;
    const isPublicBool = isPublic === 'on' ? true : false;

    try {
        const token = req.cookies['aid'];
        const decodedObject = jwt.verify(token, config.privateKey);

        const date = new Date();

        const play = new Play({
            title: playTitle,
            description,
            imageUrl,
            isPublic: isPublicBool,
            createdAt: date.toString().slice(0, 24),
            creatorId: decodedObject.userId
        })
        
        await play.save();

        return play;
    } catch (error) {
        return {
            error
        }
    }
}

const getAllPlays = async () => {
    const plays = await Play.find().lean();

    return plays;
}

const getPlayById = async (id) => {
    const play = await Play.findById(id).lean();

    return play;
}

const checkIfIsAlreadyJoined = async (req, res) => {
    const playId = req.params.id;
    const play = await Play.findById(playId).lean();

    const token = req.cookies['aid'];
    const decodedObject = jwt.verify(token, config.privateKey);

    return play.userLiked
        .map(userId => userId.toString())
        .includes(decodedObject.userId);;
};

const likePlay = async (playId, userId) => {
    try {
        await Play.findByIdAndUpdate(playId, {
            $addToSet: {
                userLiked: [userId]
            }
        });
    
        await User.findByIdAndUpdate(userId, {
            $addToSet: {
                likedPlays: [playId]
            }
        });

        return true;
    } catch (error) {
        return {
            error
        }
    }
};

const deletePlayById = async (playId) => {
    try {
        await Play.findByIdAndDelete(playId);

        const users = await User.find().lean();
        
        users
            .forEach(user => {
                user.likedPlays.forEach(play => (async () => {
                    if (play.toString() === playId) {
                        const cubeIndex = user.likedPlays.indexOf(play);
                        user.likedPlays.splice(cubeIndex, 1);
                        
                        await User.findByIdAndUpdate(user._id, {
                            likedPlays: user.likedPlays
                        });
                    }
                })())
            });

        return true;
    } catch (error) {
        return {
            error
        }
    }
};

const editPlayById = async (playId, playTitle, description, imageUrl, isPublic) => {
    try {
        const isPublicBool = isPublic === 'on' ? true : false;

        await Play.findByIdAndUpdate(playId, {
            title: playTitle,
            description,
            imageUrl,
            isPublic: isPublicBool
        });

        return true;
    } catch (error) {
        return {
            error
        }
    }
};

module.exports = {
    createPlay,
    getAllPlays,
    getPlayById,
    checkIfIsAlreadyJoined,
    likePlay,
    deletePlayById,
    editPlayById
}