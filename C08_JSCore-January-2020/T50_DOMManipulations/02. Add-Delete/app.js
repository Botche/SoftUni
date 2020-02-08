function addItem() {
    let list = document.getElementById('items');

    let input = document.getElementById('newText');
    let textToAppend = input.value;
    
    let deleteLink = document.createElement('a');
    deleteLink.innerHTML = '[Delete]';
    deleteLink.href = '#'; 
    
    deleteLink.addEventListener('click', function (e) {
        e.preventDefault();

        this.parentNode.parentNode.removeChild(this.parentNode);
    })

    let listItem = document.createElement('li');
    listItem.innerHTML = textToAppend;

    listItem.appendChild(deleteLink);
    list.appendChild(listItem);

    input.value = '';
}