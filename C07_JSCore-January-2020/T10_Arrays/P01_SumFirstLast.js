function sumFirstLast(arrayOfNumbers){
    let sum = 0;

    sum = +arrayOfNumbers[0] + +arrayOfNumbers[arrayOfNumbers.length - 1];

    return sum;
}

console.log(sumFirstLast(['20', '30', '40']))