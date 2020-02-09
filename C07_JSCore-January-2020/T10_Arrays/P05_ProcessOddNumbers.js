function processOddNumbers(numbers) {
    let result = numbers.filter((_, i) => i % 2 !== 0)
        .reverse()
        .map(i => i * 2)
        .join(' ');

    return result;
}

console.log(processOddNumbers([10, 15, 20, 25]));