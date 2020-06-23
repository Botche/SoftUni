const mogoose = require('mongoose');

const UserSchema = new mogoose.Schema({
    username: {
        type: String,
        required: true
    }, 
    password: {
        type: String,
        required: true
    }
});

module.exports = mogoose.model('User', UserSchema);