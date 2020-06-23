const mogoose = require('mongoose');

const UserSchema = new mogoose.Schema({
    username: {
        type: String,
        required: true,
        minlength: 5,
        match: [/^[A-Za-z0-9]+$/, 'Username is not valid']
    }, 
    password: {
        type: String,
        required: true
    }
});

module.exports = mogoose.model('User', UserSchema);