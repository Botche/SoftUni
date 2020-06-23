const { Router } = require('express');
const router = Router();

const Accessory = require('../models/accesory');

const { getCube, updateCube } = require('../controllers/cubes');

const { getAllAccessories, updateAccessory } = require('../controllers/accesories');
const { getUserStatus, authAccess } = require('../controllers/user');

router.get('/create/accessory', authAccess, getUserStatus, (req, res) => {
    res.render('createAccessory', {
        title: 'Create accesory',
        isLoggedIn: req.isLoggedIn
    })
});

router.post('/create/accessory', authAccess, getUserStatus, async (req, res) => {
    const {
        name,
        description,
        imageUrl
    } = req.body;

    const accessory = new Accessory({
        name,
        description,
        imageUrl
    });

    try {
        await accessory.save();

        res.redirect('/');
    } catch (error) {
        return res.render('createAccessory', {
            title: 'Create accesory',
            isLoggedIn: req.isLoggedIn,
            error: 'Accessory details are not valid'
        });
    }
});

router.get('/attach/accessory/:id', authAccess, getUserStatus, async (req, res) => {
    const cube = await getCube(req.params.id);
    const accessories = await getAllAccessories();

    const fileredAccessories = accessories.filter(accessory => {
        return !cube.accessories
            .map(accessory => accessory.toString())
            .includes(accessory._id.toString());
    });

    res.render('attachAccessory', {
        title: 'Attach accesory',
        ...cube,
        accessories: fileredAccessories,
        isLoggedIn: req.isLoggedIn
    })
});

router.post('/attach/accessory/:id', authAccess, getUserStatus, async (req, res) => {
    const cubeId = req.params.id;
    const {
        accessory
    } = req.body;

    try {
        await updateCube(cubeId, accessory);
        await updateAccessory(accessory, cubeId);
    } catch (error) {
        const cube = await getCube(cubeId);

        return res.render('attachAccessory', {
            title: 'Attach accesory',
            ...cube,
            accessories: fileredAccessories,
            isLoggedIn: req.isLoggedIn,
            error: error
        });
    }

    res.redirect(`/details/${cubeId}`);
});

module.exports = router;