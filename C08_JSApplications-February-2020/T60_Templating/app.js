import contacts from './contacts.js';

const html = {
    contactsData: () => document.getElementById("contacts"),
    contactDiv: (n) => document.getElementById(n)
};

function attachedEvents() {
    fetch(`./contact.hbs`)
        .then(resources => resources.text())
        .then(data => {
            const template = Handlebars.compile(data);
            html.contactsData().innerHTML = template({ contacts });

            const detailsBtns = document.getElementsByClassName('detailsBtn');
            Array.from(detailsBtns).forEach(detailsBtn => detailsBtn.addEventListener('click', showDetails));
        });
}

function showDetails() {
    const parentElement = this.parentNode.querySelector('.details');

    if (parentElement.style.display === "none") {
        parentElement.style.display = "block";
        this.innerText = "LESS";
    } else {
        parentElement.style.display = "none";
        this.innerText = "DETAILS";
    }
}

attachedEvents();