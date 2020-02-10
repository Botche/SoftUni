function subtract() {
    let firstElement = document.getElementById('firstNumber');
    let secondElement = document.getElementById('secondNumber');

    let resultElement = document.getElementById('result');
    
    let result = +firstElement.value - +secondElement.value;

    resultElement.textContent = result;
}