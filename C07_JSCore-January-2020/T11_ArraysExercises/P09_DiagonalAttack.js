function diagonalAttack(array) {
    let firstDiagonalSum = 0;
    let secondDiagonalSum = 0;

    for (let row = 0; row < array.length; row++) {

        const elements = array[row].split(' ').map(Number);

        for (let col = 0; col < elements.length; col++) {

            if (row === col) {
                firstDiagonalSum += elements[col];
            }

            if (row + col === array.length - 1) {
                secondDiagonalSum += elements[col];
            }
        }
    }

    const result = [];
    if (firstDiagonalSum === secondDiagonalSum) {
        for (let row = 0; row < array.length; row++) {

            const elements = array[row].split(' ').map(Number);
            result[row] = [];
            for (let col = 0; col < elements.length; col++) {
    
                if (row !== col && row + col !== array.length - 1) {
                    result[row][col] = firstDiagonalSum;
                } else {
                    result[row][col] = elements[col];
                }
            }
        }
    }

    printMatrix();


    function printMatrix(){
        for (let row = 0; row < result.length; row++) {
            console.log(result[row].join(' '));
        }
    }
}

diagonalAttack(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);