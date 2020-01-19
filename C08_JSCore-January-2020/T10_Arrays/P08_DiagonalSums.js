function diagonalSums(numbers){
    let first = 0;
    let second = 0;

    for (let i = 0; i < numbers.length; i++) {
        first += numbers[i][i];
        second += numbers[i][numbers.length - 1 - i];
    }

    return `${first} ${second}`;
}

console.log(diagonalSums([[20, 40],
    [10, 60]]
));