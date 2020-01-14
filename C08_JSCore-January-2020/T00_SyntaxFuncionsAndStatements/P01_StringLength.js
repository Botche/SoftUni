function getStringLength(firstWord, secondWord, thirdWord){
    let sumOfLengthOfWords = firstWord.length + secondWord.length + thirdWord.length;
    let averageLengthOfWords = Math.floor(sumOfLengthOfWords / 3);

    console.log(sumOfLengthOfWords);
    console.log(averageLengthOfWords);
}

getStringLength('asd', 'as', 'asdasf2');

