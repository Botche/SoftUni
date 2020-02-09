function ticTacToe(array = []){
    const gameField = [[false, false, false],
    [false, false, false],
    [false, false, false]];
    
    let player = 'X';

    for (let index = 0; index < array.length; index++) {
        const element = array[index];
        const tokens = element.split(' ');

        const currRow = +tokens[0];
        const currCol = +tokens[1];

        if (gameField[currRow][currCol] !== false) {
            console.log('This place is already taken. Please choose another!');
            continue;
        } 
        
        gameField[currRow][currCol] = player;

        for (let i = 0; i < 3; i++) {
            if (
                gameField[i][0] === player &&
                gameField[i][1] === player &&
                gameField[i][2] === player
            ) {
                console.log(`Player ${player} wins!`);
                printMatrix();
                return;
            } else if (
                gameField[0][i] === player &&
                gameField[1][i] === player &&
                gameField[2][i] === player
            ) {
                console.log(`Player ${player} wins!`);
                printMatrix();
                return;
            }
        }

        if (
            gameField[0][0] === player &&
            gameField[1][1] === player &&
            gameField[2][2] === player
        ) {
            console.log(`Player ${player} wins!`);
            printMatrix();
            return;
        } else if (
            gameField[0][2] === player &&
            gameField[1][1] === player &&
            gameField[2][0] === player
        ) {
            console.log(`Player ${player} wins!`);
            printMatrix();
            return;
        }

        let theresFalse = false;

        for (let row = 0; row < gameField.length; row++) {
            if (gameField[row].includes(false)) {
                theresFalse = true;
            }
        }

        if (!theresFalse) {
            console.log('The game ended! Nobody wins :(');
            printMatrix();
            return;
        }
        
        player = player === 'X' ? 'O' : 'X';
    };
    
    function printMatrix() {
        for (let row = 0; row < gameField.length; row++) {
            console.log(gameField[row].join('\t'));
        }
    }
}


ticTacToe(["0 1",
"0 0",
"0 2", 
"2 0",
"1 0",
"1 1",
"1 2",
"2 2",
"2 1",
"0 0"]
);