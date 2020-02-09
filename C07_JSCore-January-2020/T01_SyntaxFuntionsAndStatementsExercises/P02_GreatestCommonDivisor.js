function greatestCommonDivisor(firstNumber, secondNumber){
    let result = 0;
    if (firstNumber < secondNumber) {
        if (secondNumber % firstNumber == 0) {
            result = firstNumber;
        }
        else{
            while (secondNumber != 0) {
                [firstNumber, secondNumber] = [secondNumber, firstNumber % secondNumber];
            }
            
            result = firstNumber;
        }
    }
    else if(firstNumber > secondNumber){
        if (firstNumber % secondNumber == 0) {
            result = secondNumber;
        }
        else{
            while (secondNumber != 0) {
                [firstNumber, secondNumber] = [secondNumber, firstNumber % secondNumber];
            }

            result = firstNumber;
        }
    }
    else{
        result = firstNumber;
    }

    console.log(result);
}

greatestCommonDivisor(2154, 458);