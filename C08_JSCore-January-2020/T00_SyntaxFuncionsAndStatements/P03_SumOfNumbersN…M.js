function sumFromTo(firstString, secondString) {
    let lowerNumber = Number(firstString);
    let higherNumber = Number(secondString);

    let result = 0;
    for (let index = lowerNumber; index <= higherNumber; index++) {
        result += index;
    }

    console.log(result);
}

sumFromTo('1', '5');