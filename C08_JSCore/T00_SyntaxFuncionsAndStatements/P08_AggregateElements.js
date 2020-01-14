function printResult(arr, func) {
    return func(arr);
}

function sumNumbersInArray(arr) {
    let sum = 0;
    for (let index = 0; index < arr.length; index++) {
        const element = arr[index];
        sum += element;
    }

    return sum;
}

function inverseSum(arr) {
    let sum = 0;
    for (let index = 0; index < arr.length; index++) {
        const element = 1 / arr[index];
        sum += element;
    }

    return sum;
}

function concat(arr) {
    let sum = '';
    for (let index = 0; index < arr.length; index++) {
        const element = arr[index];
        sum += element;
    }

    return sum;
}

// Softuni variant 100/100
function solve(array) {
    let sum1 = 0;
    let sum2 = 0;
    let concat = "";

    for (let i = 0; i < array.length; i++) {
        const element = array[i];
        sum1 += element;
        sum2 += 1 / element;
        concat += element
    }

    console.log(sum1);
    console.log(sum2);
    console.log(concat);
}

console.log(printResult([1, 2, 3], concat))