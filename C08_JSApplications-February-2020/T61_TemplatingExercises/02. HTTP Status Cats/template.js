(() => {
    renderCatTemplate();

    const hmtlElements = {
        catSection: () => document.getElementById('allCats'),
        showBtns: () => document.getElementsByClassName('showBtn'),

    }

    async function renderCatTemplate() {
        const data = this.cats;

        const templateFromFile = await getTemplate('./templates/cats-template.hbs');

        Handlebars.registerPartial("cat", await getTemplate('./templates/cat-template.hbs'));

        const template = Handlebars.compile(templateFromFile);
        const content = template({ cats: data });

        hmtlElements.catSection().innerHTML = content;

        Array.from(hmtlElements.showBtns())
            .forEach(showBtn => showBtn.addEventListener('click', showInfo));
    }

    function showInfo(){
        const status = this.parentNode.getElementsByClassName('status')[0];

        if (status.style.display === 'none') {
            status.style.display = 'block';
            this.innerText = 'Hide status code';
        } else{
            status.style.display = 'none';
            this.innerText = 'Show status code';
        }
    }

    function getTemplate(url) {
        return fetch(url)
            .then(response => response.text())
            .catch(error => console.log(error.message));
    }
})()
