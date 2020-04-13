import {
    get,
    create,
    update,
    del,
} from './requester.js';

const tokenFromStorage = () => sessionStorage.getItem('token');

async function applyCommon() {
    this.partials = {
        header: await this.load('../templates/common/header.hbs'),
        footer: await this.load('../templates/common/footer.hbs'),
    }

    this.email = sessionStorage.getItem('email');
    this.loggedIn = !!sessionStorage.getItem('token');
}

export async function createTeamHandler() {
    await applyCommon.call(this);
    this.partials.createForm = await this.load('../templates/create/createForm.hbs')
    await this.partial('../templates/create/createPage.hbs');

    const createTeamBtn = document.getElementById('createTeam');
    createTeamBtn.addEventListener('click', async () => {
        const name = document.getElementById('name').value;
        const comment = document.getElementById('comment').value;

        clearAlert();
        if(!name){
            createAlert('Team name cannot be empty!', 'createForm', 'createContainer');
        }
        
        const team = {
            authorId: sessionStorage.getItem('userId'),
            name,
            comment,
            players: {
                [sessionStorage.getItem('userId')]: {
                    email: sessionStorage.getItem('email'),
                }
            }
        }

        const teamId = await create('teams.json?auth=' + tokenFromStorage(), team);

        sessionStorage.setItem('teamId', teamId.name)

        this.redirect('#/catalog')
    })
}

export async function teamDetailsViewHandler(ctx) {
    await applyCommon.call(this);
    const id = ctx.params.id;
    const team = await get(`teams/${id}.json?auth=${tokenFromStorage()}`);

    this.partials.teamMember = await this.load('../templates/catalog/teamMember.hbs');
    this.partials.teamControls = await this.load('../templates/catalog/teamControls.hbs');

    this.name = team.name;
    if (team.players) {
        this.members = Object.values(team.players);
    }
    this.comment = team.comment;

    this.isAuthor = team.authorId === sessionStorage.getItem('userId');
    this.isOnTeam = !!sessionStorage.getItem('teamId');
    this.isOnThisTeam = !!sessionStorage.getItem('teamId')
        && sessionStorage.getItem('teamId') == id
    this.teamId = id;

    await this.partial('../templates/catalog/details.hbs')
}

export async function editTeamHandler(ctx) {
    await applyCommon.call(this);
    const id = ctx.params.id;
    this.teamId = id;

    this.partials.editForm = await this.load('../templates/edit/editForm.hbs');
    await this.partial('../templates/edit/editPage.hbs');

    const team = await get(`teams/${id}.json?auth=${tokenFromStorage()}`);

    const name = document.getElementById('name');
    const comment = document.getElementById('comment');

    name.value = team.name;
    comment.value = team.comment;

    const updateTeamBtn = document.getElementById('updateTeam');

    updateTeamBtn.addEventListener('click', async function (e) {
        e.preventDefault();

        clearAlert('editContainer');

        if (!name.value) {
            createAlert('Team name cannot be empty!', 'editContainer', 'editForm');
            return;
        }

        await update(`teams/${id}.json?auth=${tokenFromStorage()}`, {
            name: name.value,
            comment: comment.value,
        });

        this.redirect(`#/catalog`)
    }.bind(this))
}

export async function joinTeamHandler(ctx) {
    await applyCommon.call(this);
    const id = ctx.params.id;

    await update(`teams/${id}/players.json?auth=${tokenFromStorage()}`, {
        [sessionStorage.getItem('userId')]: {
            email: sessionStorage.getItem('email'),
        }
    });

    sessionStorage.setItem('teamId', id);

    this.redirect(`#/catalog/${id}`);
}

export async function leaveTeamHandler(ctx) {
    await applyCommon.call(this);
    const id = sessionStorage.getItem('teamId');
    const playerId = sessionStorage.getItem('userId');

    await del(`teams/${id}/players/${playerId}.json?auth=${tokenFromStorage()}`);

    sessionStorage.removeItem('teamId');

    this.redirect(`#/catalog/${id}`);
}

export async function deleteTeamHadler(ctx) {
    await applyCommon.call(this);
    const id = ctx.params.id;

    await del(`teams/${id}.json?auth=${tokenFromStorage()}`);

    if (sessionStorage.getItem('teamId') === id) {
        sessionStorage.removeItem('teamId');
    }

    this.redirect(`#/catalog`);
}

function createAlert(message, parentNodeId, nodeToInsertBeforeId) {
    const errorMessage = document.createElement('div');
    errorMessage.classList.add('alert', 'alert-danger');
    errorMessage.role = 'alert';
    errorMessage.textContent = message;

    document.getElementById(parentNodeId)
        .insertBefore(errorMessage, document.getElementById(nodeToInsertBeforeId));
}

function clearAlert(parentNodeId) {
    const alert = document.getElementsByClassName('alert')[0];

    if (alert) {
        document.getElementById(parentNodeId).removeChild(alert);
    }
}