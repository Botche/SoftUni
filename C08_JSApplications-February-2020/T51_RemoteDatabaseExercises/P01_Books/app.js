import { getAll, create, update, del } from './requester.js';

const html = {
    loadBtn: document.getElementById('loadBooks'),
    submitBtn: document.getElementById('submit'),
    tableBooks: document.querySelector('#books tbody'),
    title: document.getElementById('title'),
    author: document.getElementById('author'),
    isbn: document.getElementById('isbn'),
    tags: document.getElementById('tags'),
};

function attachedEvents() {
    html.loadBtn.addEventListener('click', loadBooks);
    html.submitBtn.addEventListener('click', createBook);
}

async function loadBooks() {
    disableAllButtons();
    html.tableBooks.innerHTML = '';

    const books = await getAll('books.json');

    for (const key in books) {
        const [author, isbn, tags, title] = Object.values(books[key]);

        const tableRow = createDomElement('tr');

        const titleData = createDomElement('td', title);
        const authorData = createDomElement('td', author);
        const isbnData = createDomElement('td', isbn);
        const tagsData = createDomElement('td', tags);
        const bookIdData = createDomElement('td', key, ['bookId']);
        bookIdData.style.display = 'none';

        const buttonsData = createDomElement('td');

        const editBtn = createDomElement('button', 'Edit', ['edit']);
        editBtn.type = 'submit';
        const deleteBtn = createDomElement('button', 'Delete', ['delete']);

        editBtn.addEventListener('click', editBook);
        deleteBtn.addEventListener('click', deleteBook);

        buttonsData.appendChild(editBtn);
        buttonsData.appendChild(deleteBtn);

        tableRow.appendChild(bookIdData);
        tableRow.appendChild(titleData);
        tableRow.appendChild(authorData);
        tableRow.appendChild(isbnData);
        tableRow.appendChild(tagsData);
        tableRow.appendChild(buttonsData);

        html.tableBooks.appendChild(tableRow);
    }

    disableAllButtons();
}

async function deleteBook() {
    disableAllButtons();

    const bookToDelete = this.parentNode.parentNode;
    const bookId = bookToDelete.querySelector('.bookId').innerText;

    await del(`books/${bookId}.json`);

    disableAllButtons();
    clearInputs();
    html.loadBtn.click();
}

async function editBook(e) {
    disableAllButtons();
    e.preventDefault();

    const bookToEdit = this.parentNode.parentNode;
    const targetRow = bookToEdit.children;

    const title = targetRow[1].innerText;
    const author = targetRow[2].innerText;
    const isbn = targetRow[3].innerText;
    const tags = targetRow[4].innerText;

    html.title.value = title;
    html.author.value = author;
    html.isbn.value = isbn;
    html.tags.value = tags;

    const editBtn = bookToEdit.querySelector('.edit');
    editBtn.removeEventListener('click', editBook);
    editBtn.addEventListener('click', submitEditBook);

    editBtn.disabled = false;
}

async function submitEditBook() {
    const updatedData = {
        title: html.title.value,
        author: html.author.value,
        isbn: html.isbn.value,
        tags: html.tags.value,
    };
    const bookToEdit = this.parentNode.parentNode;
    const bookId = bookToEdit.querySelector('.bookId').innerText;
    await update(`books/${bookId}.json`, updatedData);
    clearInputs();
    disableAllButtons();

    html.loadBtn.click();
}

async function createBook(e) {
    disableAllButtons();

    e.preventDefault();
    const title = html.title.value;
    const author = html.author.value;
    const isbn = html.isbn.value;
    const tags = html.tags.value;

    const book = {
        title: title,
        author: author,
        isbn: isbn,
        tags: tags,
    }

    const bookId = await create('books.json', book);

    if (!bookId) {
        alert('Something went wrong! Try again...');
    }

    clearInputs();

    disableAllButtons();

    html.loadBtn.click();
}

function clearInputs() {
    html.title.value = '';
    html.author.value = '';
    html.isbn.value = '';
    html.tags.value = '';
}

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

function disableAllButtons() {
    html.loadBtn.disabled = !html.loadBtn.disabled;
    html.submitBtn.disabled = !html.submitBtn.disabled;

    Array.from(html.tableBooks.children).forEach(element => {
        let editBtn = element.lastChild.firstElementChild;
        let deleteBtn = element.lastChild.lastElementChild;

        editBtn.disabled = html.loadBtn.disabled;
        deleteBtn.disabled = html.loadBtn.disabled;
    })
}

loadBooks();
attachedEvents();