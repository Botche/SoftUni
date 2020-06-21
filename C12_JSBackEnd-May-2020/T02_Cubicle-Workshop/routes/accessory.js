const { Router } = require('express');
const router = Router();

const Accessory = require('../models/accesory');

const { getCube, updateCube } = require('../controllers/cubes');

const { getAllAccessories, updateAccessory } = require('../controllers/accesories');

router.get('/create/accessory', (req, res) => {
    res.render('createAccessory', {
        title: 'Create accesory'
    })
});

router.post('/create/accessory', (req, res) => {
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

    accessory.save((err) => {
        if (err) {
            console.log(err);

            res.redirect('/create/accessory')
        } else {
            res.redirect('/');
        }
    });
});

router.get('/attach/accessory/:id', async (req, res) => {
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
        accessories: fileredAccessories
    })
});

router.post('/attach/accessory/:id', async (req, res) => {
    const {
        accessory
    } = req.body;
 
    await updateCube(req.params.id, accessory);
    await updateAccessory(accessory, req.params.id);

    res.redirect(`/details/${req.params.id}`);
});

module.exports = router;