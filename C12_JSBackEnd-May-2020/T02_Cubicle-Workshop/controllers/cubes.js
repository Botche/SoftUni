const Cube = require('../models/cude');
const Accessory = require('../models/accesory');

const getAllCubes =  async () => {
    const cubes = await Cube.find().lean();

    return cubes;
};

const getCube = async (id) => {
    const cube = await Cube.findById(id).lean();

    return cube;
}

const getCubeWithAccessories = async (id) => {
    const cube = await Cube.findById(id).populate('accessories').lean();

    return cube;
}

const updateCube = async (cubeId, accessoryId) => {
    await Cube.findByIdAndUpdate(cubeId, {
        $addToSet: {
            accessories: [accessoryId],
        },
    });

    await Accessory.findByIdAndUpdate(accessoryId, {
      $addToSet: {
        cubes: [cubeId],
      },
    });
}

const editCube = async (id, name, description, imageUrl, difficulty) => {
    try {
        await Cube.findByIdAndUpdate(id, {
            name: name,
            description: description,
            imageUrl: imageUrl,
            difficulty: difficulty
        });
    } catch (err) {
        return err;
    }
}

const deleteCube = async (id) => {
    await Cube.findByIdAndDelete(id);

    const accessories = await Accessory.find().lean();
    
    accessories
        .forEach(accessory => {
            accessory.cubes.forEach(cube => (async () => {
                if (cube.toString() === id) {
                    const cubeIndex = accessory.cubes.indexOf(cube);
                    accessory.cubes.splice(cubeIndex, 1);
                    
                    await Accessory.findByIdAndUpdate(accessory._id, {
                        cubes: accessory.cubes
                    });
                }
            })())
        });
}

module.exports = {
    getAllCubes,
    getCube,
    getCubeWithAccessories,
    updateCube,
    editCube,
    deleteCube,
};