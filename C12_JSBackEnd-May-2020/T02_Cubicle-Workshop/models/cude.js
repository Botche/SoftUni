const mogoose = require('mongoose');

const CubeSchema = new mogoose.Schema({
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
    difficulty: {
        type: Number,
        required: true,
        min: 1,
        max: 6
    },
    accessories: [{
        type: mogoose.Types.ObjectId,
        ref: 'Accesory'
    }]
});

module.exports = mogoose.model('Cube', CubeSchema);