import {getAll} from './requester.js'

const tableBody = document.getElementsByTagName('tbody')[0];
(async function displayStudents(){
    const students = await getAll('students.json');
    const sordetKeys = Object.keys(students).sort((a,b) => a.localeCompare(b));
    for (const key of sordetKeys) {
        const [facultyNumber, firstName, grade, lastName] = Object.values(students[key]);

        const tableRow = createDomElement('tr');

        const idData = createDomElement('td', key);
        const firstNameData = createDomElement('td', firstName);
        const lastNameData = createDomElement('td', lastName);
        const facultyNumberData = createDomElement('td', facultyNumber);
        const gradeData = createDomElement('td', grade);

        tableRow.appendChild(idData);
        tableRow.appendChild(firstNameData);
        tableRow.appendChild(lastNameData);
        tableRow.appendChild(facultyNumberData);
        tableRow.appendChild(gradeData);

        tableBody.appendChild(tableRow);
    }
})();

function createDomElement(element, text, classes, id) {
    const item = document.createElement(element);

    if (text) {
        item.innerHTML = text;
    }

    if (classes) {
        item.classList = [...classes];
    }

    if (id) {
        item.setAttribute('id', id);
    }

    return item;
}