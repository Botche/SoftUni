function solve() {
    let selectMenuTo = document.getElementById('selectMenuTo');

    let binaryElement = document.createElement('option');
    binaryElement.setAttribute('value', 'binary');
    binaryElement.textContent = 'Binary';

    let hexadecimalElement = document.createElement('option');
    hexadecimalElement.setAttribute('value', 'hexadecimal');
    hexadecimalElement.textContent = 'Hexadecimal';

    selectMenuTo.appendChild(binaryElement);
    selectMenuTo.appendChild(hexadecimalElement);


    let btn = document.getElementsByTagName('button')[0];

    btn.addEventListener('click', () => {
        let input = document.getElementById('input');
        let base = document.getElementById('selectMenuTo').value;
        

        let result = base === 'binary' ? (+input.value).toString(2) : (+input.value).toString(16).toUpperCase();

        let resultInput = document.getElementById('result');
        resultInput.value = result;
    });
}