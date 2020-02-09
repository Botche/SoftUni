function biggestNumber(numbers){
    let result = (Math.max(...numbers.flat(1)));

    return result;
}

console.log(biggestNumber([[20, 50, 10],
    [8, 33, 145]]
   ));