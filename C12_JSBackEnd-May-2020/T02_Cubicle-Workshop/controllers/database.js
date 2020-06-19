const fs = require('fs');
const path = require('path');

const databaseFile = path.join(__dirname, '..', '/config/database.json');

const getCube = (id, callback) => {
    getAllCubes((cubes) => {
        const cube = cubes.filter(model => model.id === id)[0];
        
        callback(cube);
    })
}

const getAllCubes = (callback) => {
    fs.readFile(databaseFile, (err, dbData) => {
        if (err) {
            throw err;
        }

        const cubes = JSON.parse(dbData);
        
        callback(cubes);
    })
}

const saveCube = (cube, callback) => {
    getAllCubes((cubes) => {
        cubes.push(cube);

        fs.writeFile(databaseFile, JSON.stringify(cubes), err => {
            if (err) {
                throw err;
            }
        });

        console.log('New cube is successfully stored');
        callback();
    })
}

module.exports = {
    getAllCubes,
    saveCube,
    getCube,
}