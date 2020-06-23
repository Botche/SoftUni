const mogoose = require('mongoose');

const AccesorySchema = new mogoose.Schema({
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
    cubes: [{
        type: mogoose.Types.ObjectId,
        ref: 'Cube'
    }]
});

AccesorySchema.path('imageUrl').validate(function (url) {
    return url.startsWith('http') || url.startsWith('https');
}, 'Image url is not valid!');

module.exports = mogoose.model('Accesory', AccesorySchema);