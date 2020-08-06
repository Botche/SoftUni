const mongoose = require('mongoose');

const { String, ObjectId, Boolean } = mongoose.Schema.Types;

const CourseSchema = new mongoose.Schema({
    title: {
        type: String,
        required: true,
        unique: true,
    },
    description: {
        type: String,
        maxlength: 50,
        required: true,
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
    usersEnrolled: [{
        type: ObjectId,
        ref: 'User'
    }],
    creatorId: {
        type: ObjectId,
        ref: 'User'
    }
});

module.exports = mongoose.model('Course', CourseSchema);