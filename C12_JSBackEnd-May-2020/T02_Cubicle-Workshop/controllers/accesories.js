const Accessory = require('../models/accesory');

const getAllAccessories =  async () => {
    const accesories = await Accessory.find().lean();

    return accesories;
};

const updateAccessory = async (accessoryId, cubeId) => {
    await Accessory.findByIdAndUpdate(accessoryId, {
        cubes: [cubeId]
    });
};

module.exports = {
    getAllAccessories,
    updateAccessory,
};