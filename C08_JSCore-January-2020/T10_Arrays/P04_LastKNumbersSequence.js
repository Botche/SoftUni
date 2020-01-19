function lastKNumbers(lengthOfSequence, sumOfPreviousNumbers) {
    let result = [1];

    for (let i = 1; i < lengthOfSequence; i++) {
        let element = result.slice(sumOfPreviousNumbers * -1)
            .reduce((a, b) => a + b);

        result.push(element);
    }

    return result.join(' ');
}

console.log(lastKNumbers(6, 3)); 