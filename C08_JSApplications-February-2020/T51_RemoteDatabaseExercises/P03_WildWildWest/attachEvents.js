import { getAll, create, update, del } from './requester.js';
import { Player } from './player.js';
import {loadCanvas} from './loadCanvas.js'


const html = {
    players: document.getElementById('players'),
    canvas: document.getElementById('canvas'),
    playerNameInput: document.getElementById('addName'),
    addPlayerBtn: document.getElementById('addPlayer'),
    saveBtn: document.getElementById('save'),
    reloadBtn: document.getElementById('reload'),
}

async function loadPlayers() {
    html.players.innerHTML = '';

    const players = await getAll('players.json');

    let result = [];
    for (let playerKey in players) {
        const player = players[playerKey];
        player.id = playerKey;

        const templateFromFile = await getTemplate();
        const template = Handlebars.compile(templateFromFile);

        const content = template(player);

        result.push(content);
    }

    html.players.innerHTML = result.join('\n');

    const playBtns = document.getElementsByClassName('play');
    const deleteBtns = document.getElementsByClassName('delete');

    Array.from(playBtns).forEach(playBtn => {
        playBtn.addEventListener('click', prepareCanvas);
    });

    Array.from(deleteBtns).forEach(deleteBtn => {
        deleteBtn.addEventListener('click', deletePlayer);
    });
}

async function addPlayer() {
    const name = html.playerNameInput.value;
    const player = new Player(name);

    await create('players.json', player);

    html.playerNameInput.value = '';
    loadPlayers();
}

async function deletePlayer() {
    let playerId = this.parentNode.id;

    await del(`players/${playerId}.json`);

    loadPlayers();
}

function getTemplate() {
    return fetch('./templates/player-template.hbs')
        .then(response => response.text())
        .catch(error => console.log(error.message));
}

async function prepareCanvas() {
    let playerId = this.parentNode.id;

    const player = await getAll(`players/${playerId}.json`)
    player.id = playerId;

    html.canvas.style.display = 'block';
    html.saveBtn.style.display = 'inline-block';
    html.reloadBtn.style.display = 'inline-block';

    let fieldsets = document.getElementsByTagName('fieldset');
    Array.from(fieldsets).forEach(fieldset => fieldset.style.display = 'none');

    loadCanvas(player);
}

function attachEvents() {
    html.addPlayerBtn.addEventListener('click', addPlayer);

    loadPlayers();
};
attachEvents();
export { attachEvents };