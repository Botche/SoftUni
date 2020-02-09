function solve() {
    let addBtn = document.getElementsByTagName('button')[0];
    let input = document.getElementsByTagName('input')[0];
    let letters = document.getElementsByTagName('li');

    addBtn.addEventListener('click', () => {
        let name = input.value;
        if (name != '') {
            let firstLetterToUpper = name[0].toUpperCase();
            let codeOfFirstLetter = firstLetterToUpper.charCodeAt(0) - 65;
            name = firstLetterToUpper + name.substring(1).toLowerCase();

            let listItemToAddName = letters[codeOfFirstLetter];
            let namesInCurrentListItem = listItemToAddName.textContent.split(',').filter(x => x != '');
            namesInCurrentListItem.push(name);

            listItemToAddName.textContent = namesInCurrentListItem.join(', ');

            input.value = '';
        }
    })
}