function orbit(array){
    const width = array[0];
    const height = array[1];

    const y = array[2];
    const x = array[3];

    const createMatrix = () => new Array(width).fill(0);
    let matrix = Array(height)
        .fill()
        .map(createMatrix);
    

    matrix
        .map((arr, h) => arr
            .map((_, w) => {
                let sum = Math.max(Math.abs(x - w), Math.abs(y - h)) + 1;
                return matrix[h][w] = sum;
            }));

    console.log(matrix.map(arr => arr.join(' ')).join('\n'));
}


orbit([4,4,0,0]);