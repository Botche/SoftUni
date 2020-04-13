import {
    get,
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

export async function cataglogViewHandler(ctx) {
    await applyCommon.call(this);
    this.hasNoTeam = !sessionStorage['teamId'];

    this.partials.team = await this.load('../templates/catalog/team.hbs');
    const result = await get(`teams.json?auth=` + tokenFromStorage())

    for (const key in result) {
        result[key].id = key;
    }

    if (result) {
        this.teams = Object.values(result);
    }

    await this.partial('../templates/catalog/teamCatalog.hbs');
}