function addItem() {
    let menuElement = document.getElementById('menu');

    let inputTextElement = document.getElementById('newItemText');
    let inputValueElement = document.getElementById('newItemValue');

    let selectElement = document.createElement('option');
    selectElement.value = inputValueElement.value;
    selectElement.textContent = inputTextElement.value;

    menuElement.appendChild(selectElement);

    inputTextElement.value = '';
    inputValueElement.value = '';
}