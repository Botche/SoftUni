

const BASE_URL = 'https://remotedatabase-89b28.firebaseio.com/';

const htmlElements = {
    townsInput: document.getElementById('towns'),
    townsDiv: document.getElementById('root'),
    loadAllBtn: document.getElementById('btnLoadAllTowns'),
    createBtn: document.getElementById('btnCreateTown'),
}

function appendEvents() {
    htmlElements.loadAllBtn.addEventListener('click', loadAllTowns);
    htmlElements.createBtn.addEventListener('click', createTown);
}

async function loadAllTowns() {
    disableBtns();

    await fetch(BASE_URL + 'towns.json')
        .then(response => response.json())
        .then(json => async function () {
            const templateFromFile = await getTemplate('./templates/towns-template.hbs');
            
            Handlebars.registerPartial("town", await getTemplate('./templates/town-template.hbs'));

            const template = Handlebars.compile(templateFromFile);
            const content = template({ towns: json });

            htmlElements.townsDiv.innerHTML = content;
        }())
        .catch(error => console.dir(error));

    disableBtns();
}

function getTemplate(url) {
    return fetch(url)
        .then(response => response.text())
        .catch(error => console.log(error.message));
}

async function createTown() {
    disableBtns();

    const town = {
        name: htmlElements.townsInput.value
    };

    const headers = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(town)
    };

    await fetch(BASE_URL + 'towns.json', headers)
        .then(response => response.json())
        .then(json => console.log(json))
        .catch(error => console.dir(error));

    htmlElements.townsInput.value = '';

    disableBtns();
    htmlElements.loadAllBtn.click();
}

function disableBtns() {
    htmlElements.createBtn.disabled = !htmlElements.createBtn.disabled;
    htmlElements.loadAllBtn.disabled = !htmlElements.loadAllBtn.disabled;
}

appendEvents();