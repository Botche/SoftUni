const mogoose = require('mongoose');

const UserSchema = new mogoose.Schema({
    email: {
        type: String,
        required: true,
        unique: true,
    }, 
    password: {
        type: String,
        required: true
    },
    trippsHistory: [{
        type: mogoose.Types.ObjectId,
        ref: 'Tripp'
    }]
});

module.exports = mogoose.model('User', UserSchema);