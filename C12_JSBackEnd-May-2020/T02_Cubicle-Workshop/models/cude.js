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

CubeSchema.path('imageUrl').validate(function (url) {
    return url.startsWith('http') || url.startsWith('https');
}, 'Image url is not valid!');

module.exports = mogoose.model('Cube', CubeSchema);