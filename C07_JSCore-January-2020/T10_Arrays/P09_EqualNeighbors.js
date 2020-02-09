function equalNeighbors(neighborhood) {
    let count = 0;

    for (let i = 0; i < neighborhood.length - 1; i++) {
        for (let j = 0; j < neighborhood[i].length; j++) {
            const element = neighborhood[i][j];
            if (element === neighborhood[i + 1][j]) {
                count++;
            }
        }
    }
    
    for (let i = 0; i < neighborhood.length; i++) {
        for (let j = 0; j < neighborhood[i].length - 1; j++) {
            const element = neighborhood[i][j];
            if (element === neighborhood[i][j + 1]) {
                count++;
            }
        }
    }
    return count;
}

console.log(equalNeighbors([['2', '2', '5', '7', '4'],
['4', '2', '5', '3', '4'],
['2', '5', '5', '4', '2']]
));

console.log(equalNeighbors([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
));