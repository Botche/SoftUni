function printLargestNumber(firstNumber, secondNumber, thridNumber){
    let arr = [firstNumber,secondNumber,thridNumber];

    let result =  Math.max(firstNumber,secondNumber,thridNumber);

    console.log(`The largest number is ${result}.`);
}

printLargestNumber(1,2,3)