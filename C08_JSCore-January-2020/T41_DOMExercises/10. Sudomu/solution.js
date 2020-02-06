function solve() {
    let inputs = document.getElementsByTagName('input');
    let buttons = document.getElementsByTagName('button');
    let resultContainer = document.getElementById('check');
    let resultContext = resultContainer.getElementsByTagName('p')[0];
    let gameTable = document.getElementsByTagName('table')[0];

    let checkBtn = buttons[0];
    let clearBtn = buttons[1];

    clearBtn.addEventListener('click', clear);

    function solvedRight() {
        gameTable.style.border = '2px solid green';
        resultContext.textContent = 'You solve it! Congratulations!';
        resultContext.style.color = 'green';
    }

    function solvedWrong() {
        gameTable.style.border = '2px solid red';
        resultContext.textContent = 'NOP! You are not done yet...';
        resultContext.style.color = 'red';
    }

    checkBtn.addEventListener('click', function (e) {
        e.preventDefault();

        let hasWon = true;

        let sudomu = new Array();
        let row = new Array();

        for (let i = 0; i < inputs.length; i++) {

            let value = inputs[i].value;

            if (value <= 0 || value > Math.sqrt(inputs.length)) {
                resultContext.textContent = 'Enter valid numbers';
                return;
            }

            if (i % Math.sqrt(inputs.length) === 0 && i !== 0) {
                sudomu.push(row);
                row = new Array();
            }

            row.push(value);
        }
        sudomu.push(row);

        for (let i = 0; i < sudomu.length; i++) {
            const element = sudomu[i];
            let rowSet = new Set();
            for (let j = 0; j < element.length; j++) {
                rowSet.add(element[j]);
            }

            if (rowSet.size !== element.length) {
                hasWon = false;
                break;
            }
        }

        if (hasWon) {
            for (let i = 0; i < sudomu.length; i++) {
                const element = sudomu[i];
                let rowSet = new Set();
                for (let j = 0; j < element.length; j++) {
                    rowSet.add(sudomu[j][i]);
                }

                if (rowSet.size !== element.length) {
                    hasWon = false;
                    break;
                }
            }
        }

        hasWon ? solvedRight() : solvedWrong();
    });

    function clear() {
        Array.from(inputs).forEach(input => input.value = '');
        gameTable.style.border = '';
        resultContext.textContent = '';
        resultContext.style.color = '';
    }
}