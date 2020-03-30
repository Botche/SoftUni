import { monkeys } from './monkeys.js';

(() => {
    loadMonkeys();

    async function loadMonkeys(){
        const tempateFromFile = await getTemplate('./templates/monkeys-template.hbs');
        
        Handlebars.registerPartial('monkey', await getTemplate('./templates/monkey-template.hbs'));

        const template = Handlebars.compile(tempateFromFile);
        
        const content = template({monkeys});

        document.getElementsByTagName('section')[0].innerHTML += content;

        const infoBtns = document.querySelectorAll('section button');

        Array.from(infoBtns)
            .forEach(infoBtn => infoBtn.addEventListener('click', showInfo));
    }

    function showInfo(){
        const paragraphToShow = this.parentNode.getElementsByTagName('p')[0];

        if (paragraphToShow.style.display === 'none') {
            paragraphToShow.style.display = 'block';
        } else {
            paragraphToShow.style.display = 'none';
        }
    }

    function getTemplate(url) {
        return fetch(url)
            .then(response => response.text())
            .catch(error => console.dir(error));
    }
})()