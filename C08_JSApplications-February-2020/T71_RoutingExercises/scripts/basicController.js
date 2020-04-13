async function applyCommon() {
    this.partials = {
        header: await this.load('../templates/common/header.hbs'),
        footer: await this.load('../templates/common/footer.hbs'),
    }

    this.email = sessionStorage.getItem('email');
    this.loggedIn = !!sessionStorage.getItem('token');
}

export async function homeViewHandler() {
    await applyCommon.call(this);

    await this.partial('../templates/home/home.hbs');
}

export async function aboutViewHandler() {
    await applyCommon.call(this);

    await this.partial('../templates/about/about.hbs');
}