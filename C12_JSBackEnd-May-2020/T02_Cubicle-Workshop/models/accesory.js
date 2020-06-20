const mogoose = require('mongoose');

const AccesorySchema = new mogoose.Schema({
    name: {
        type: String,
        required: true
    },
    description: {
        type: String,
        required: true,
        maxlength: 2000
    },
    imageUrl: {
        type: String,
        required: true
    },
    cubes: [{
        type: mogoose.Types.ObjectId,
        ref: 'Cube'
    }]
});

module.exports = mogoose.model('Accesory', AccesorySchema);