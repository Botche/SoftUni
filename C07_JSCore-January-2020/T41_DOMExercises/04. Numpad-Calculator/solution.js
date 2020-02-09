function solve() {
    let keys = document.getElementsByClassName('keys')[0];
    let clearButton = document.getElementsByClassName('clear')[0];
    let expressionSigns = ['+', '-', '*', '/'];

    let resultElement = document.getElementById('resultOutput');
    let input = document.getElementById('expressionOutput');

    clearButton.addEventListener('click', () => {
        input.textContent = '';
        resultElement.textContent = '';
    })

    keys.addEventListener('click', (e) => {
        let value = e.target.value;


        if (expressionSigns.includes(value)) {
            input.textContent += ` ${value} `;
        } else if (value == '=') {
            let [firstOperand, sign, secondOperand] = input.textContent.split(' ');

            if (secondOperand == '') {
                resultElement.textContent = 'NaN';
                return;
            }

            resultElement.textContent = expressions[sign](firstOperand, secondOperand);
        } else {
            input.textContent += value;
        }
    });

    let expressions = {
        '+': (firstOperand, secondOperand) => +firstOperand + +secondOperand,
        '-': (firstOperand, secondOperand) => firstOperand - secondOperand,
        '*': (firstOperand, secondOperand) => firstOperand * secondOperand,
        '/': (firstOperand, secondOperand) => firstOperand / secondOperand
    }
}