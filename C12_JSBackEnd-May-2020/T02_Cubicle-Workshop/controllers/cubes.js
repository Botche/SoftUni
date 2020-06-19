const Cube = require('../models/cude');
const database = require('./database')

const getAllCubes = (callback) => {
    database.getAllCubes((cubes) => {
        callback(cubes);
    });
};

const saveCube = (cube, callback) => {
    database.saveCube(cube, () => {
        callback();
    });
}

const getCube = (id, callback) => {
    database.getCube(id, (cube) => {
        callback(cube);
    })
}

module.exports = {
    getAllCubes,
    saveCube,
    getCube,
};