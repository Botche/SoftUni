function negativePositiveNumbers(numbers) {
    let result = [];
    numbers.forEach(element => {
        element < 0 ?
            result.unshift(element) :
            result.push(element)
    });

    return result.join('\r\n');
}

console.log(negativePositiveNumbers([7, -2, 8, 9]))