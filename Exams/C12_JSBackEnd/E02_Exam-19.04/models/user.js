const mogoose = require('mongoose');
const { String, ObjectId } = mogoose.Schema.Types;

const UserSchema = new mogoose.Schema({
    username: {
        type: String,
        required: true,
        unique: true,
        minlength: 5,
        match: [/^[A-Za-z0-9]+$/, 'Username is not valid']
    }, 
    password: {
        type: String,
        required: true
    },
    enrolledCourses: [{
        type: ObjectId,
        ref: 'Course'
    }]
});

module.exports = mogoose.model('User', UserSchema);