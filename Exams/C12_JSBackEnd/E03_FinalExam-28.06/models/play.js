const mogoose = require('mongoose');
const { String, ObjectId, Boolean } = mogoose.Schema.Types;

const PlaySchema = new mogoose.Schema({
    title: {
        type: String,
        required: true,
        unique: true,
    }, 
    description: {
        type: String,
        required: true,
        maxlength: 50,
    },
    imageUrl: {
        type: String,
        required: true,
    },
    isPublic: {
        type: Boolean,
        default: false,
    },
    createdAt: {
        type: String,
        required: true,
    },
    creatorId: {
        type: ObjectId,
        ref: 'User',
        required: true,
    },
    userLiked: [{
        type: ObjectId,
        ref: 'User',
    }]
});

module.exports = mogoose.model('Play', PlaySchema);