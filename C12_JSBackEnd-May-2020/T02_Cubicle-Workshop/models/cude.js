const mogoose = require('mongoose');

const CubeSchema = new mogoose.Schema({
    name: {
        type: String,
        required: true,
        minlength: 5,
        match: [/^[A-Za-z0-9]+$/, 'Name is not valid']
    },
    description: {
        type: String,
        required: true,
        minlength: 20,
        maxlength: 2000,
        match: [/^[A-Za-z0-9 ]+$/, 'Description is not valid']
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
    }],
    creatorId: {
        type: String,
        required: true
    }
});

CubeSchema.path('imageUrl').validate(function (url) {
    return url.startsWith('http') || url.startsWith('https');
}, 'Image url is not valid!');

module.exports = mogoose.model('Cube', CubeSchema);