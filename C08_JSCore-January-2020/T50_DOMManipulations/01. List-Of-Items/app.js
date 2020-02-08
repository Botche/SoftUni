function addItem() {
    let list = document.getElementById('items');

    let input = document.getElementById('newItemText');
    let textToAppend = input.value;

    let listItem = document.createElement('li');
    listItem.textContent = textToAppend;

    list.appendChild(listItem);

    input.value = ''; 
}