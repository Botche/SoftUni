const url = require('url');
const fs = require('fs');
const path = require('path');
const formidable = require('formidable');
const qs = require('querystring');
const breeds = require('../data/breeds.json');
const cats = require('../data/cats.json');
const catImageUrl = 'https://icatcare.org/app/uploads/2018/07/Thinking-of-getting-a-cat.png';

module.exports = (req, res) => {
    
    const pathname = url.parse(req.url).pathname;

    if (pathname === '/cats/add-cat' && req.method === 'GET') {
        
        const filePath = path.normalize(path.join(__dirname, '../views/addCat.html'))
        
        const index = fs.createReadStream(filePath);

        index.on('data', (data) => {
            const catBreedPlaceholder = breeds
                                       .map((breed) => `<option value="${breed}">${breed}</option>`)
            const modifiedData = data
                                 .toString()
                                 .replace('{{catBreeds}}', catBreedPlaceholder);

            res.write(modifiedData); 
        });

        index.on('end', () => {
            res.end();
        });

        index.on('error', (err) => {
            console.log(err);
        });

    } else if (pathname === '/cats/add-cat' && req.method === 'POST') {
        const form = new formidable.IncomingForm();

        form.parse(req, (err, fields, files) => {
            if (err) {
                console.log(err);
                throw err;
            }

            // const oldpath = files.upload.path;
            // const newPath = path.normalize(path.join(__dirname, '../content/images/' + files.upload.name));

            // fs.rename(oldpath, newPath, function (err) {
            //     if (err) {
            //         console.log(err);
            //         throw err;
            //     }

            //     console.log('Files was uploaded successfully!');
            // });
            
            fs.readFile('./data/cats.json', 'utf-8', (err, data) => {
                if (err) {
                    console.log(err);
                    throw err;
                }
                
                const allCats = JSON.parse(data);
                allCats.push({ id: allCats.length + 1, ...fields, image: catImageUrl });
                const json = JSON.stringify(allCats);

                fs.writeFile('./data/cats.json', json, () => {
                    res.writeHead(301, { location: '/' });
                    res.end();
                });
            });
        });
    } else if (pathname === '/cats/add-breed' && req.method === 'GET') {
        
        const filePath = path.normalize(path.join(__dirname, '../views/addBreed.html'))
        
        const index = fs.createReadStream(filePath);

        index.on('data', (data) => {
            res.write(data);
        });

        index.on('end', () => {
            res.end();
        });

        index.on('error', (err) => {
            console.log(err);
        });
    } else if (pathname === '/cats/add-breed' && req.method === 'POST') {
        let formData = '';

        req.on('data', (data) => {
            formData += data;
        });

        req.on('end', () => {
            const body = qs.parse(formData);

            fs.readFile('./data/breeds.json', (err, data) => {
                if (err) {
                    console.log(err);
                    throw err;
                }

                const breeds = JSON.parse(data);
                breeds.push(body.breed);
                const json = JSON.stringify(breeds);

                fs.writeFile('./data/breeds.json', json, 'utf-8', () => {
                    console.log('The breed was added successfully!');
                });
            });

            res.writeHead(301, { location: '/' });
            res.end();
        });
    } else if (pathname.includes('/cats-edit') && req.method === 'GET') {
        const filePath = path.normalize(path.join(__filename, '../../views/editCat.html'));

        const index = fs.createReadStream(filePath);

        index.on('data', (data) => {
            const lastSlashIndex = pathname.lastIndexOf('/');
            const catId = parseInt(pathname.substr(lastSlashIndex + 1));
            const currentCat = cats.find(x => x.id === catId);
            let modifiedData = data.toString().replace('{{id}}', catId);
            modifiedData = modifiedData
                                .replace('{{name}}', currentCat.name)
                                .replace('{{description}}', currentCat.description)
                                .replace('{{breed}}', currentCat.breed);

            const breedsAsOptions = breeds.map((breed) => `<option value="${breed}">${breed}</option>`);
            modifiedData = modifiedData.replace('{{catBreeds}}', breedsAsOptions.join('/'));

            res.write(modifiedData);
        });

        index.on('end', () => {
            res.end();
        });

        index.on('error', (err) => {
            console.log(err);
        });

    } else if (pathname.includes('/cats-edit') && req.method === 'POST') {
        const form = new formidable.IncomingForm();

        form.parse(req, (err, fields, files) => {
            if (err) {
                console.log(err);
                throw err;
            }

            fs.readFile('./data/cats.json', 'utf-8', (err, data) => {
                if (err) {
                    console.log(err);
                    throw err;
                }
                
                const allCats = JSON.parse(data);
                const catId = req.url.split('/')[2];
                let currentCat = allCats.filter((cat) => cat.id == catId)[0];

                currentCat.breed = fields.breed;
                currentCat.name = fields.name;
                currentCat.description = fields.description;

                const json = JSON.stringify(allCats);

                fs.writeFile('./data/cats.json', json, () => {
                    res.writeHead(301, { location: '/' });
                    res.end();
                });
            });
        })
    } else if (pathname.includes('/cats-find-new-home') && req.method === 'GET') {
        const filePath = path.normalize(path.join(__filename, '../../views/catShelter.html'));

        const index = fs.createReadStream(filePath);

        index.on('data', (data) => {
            const lastSlashIndex = pathname.lastIndexOf('/');
            const catId = parseInt(pathname.substr(lastSlashIndex + 1));
            const currentCat = cats.find(x => x.id === catId);
            let modifiedData = data.toString().replace('{{id}}', catId);
            modifiedData = modifiedData.replace('{{name}}', currentCat.name);
            modifiedData = modifiedData.replace('{{image}}', currentCat.image);
            modifiedData = modifiedData.replace('{{description}}', currentCat.description);
            modifiedData = modifiedData.replace('{{breed}}', `<option value="${currentCat.breed}">${currentCat.breed}</option>`);

            res.write(modifiedData);
        });

        index.on('end', () => {
            res.end();
        });

        index.on('error', (err) => {
            console.log(err);
        });
    } else if (pathname.includes('/cats-find-new-home') && req.method === 'POST') {
        fs.readFile('./data/cats.json', 'utf-8', (err, data) => {
            if (err) {
                console.log(err);
                throw err;
            }

            let currentCats = JSON.parse(data);
            const catId = req.url.split('/')[2];

            currentCats = currentCats.filter((cat) => cat.id != catId);

            const json = JSON.stringify(currentCats);
            fs.writeFile('./data/cats.json', json , 'utf8', () => {
                res.writeHead(301, { 'location': '/' });
                res.end();
            })
        });
    } else {
        return true;
    }
};