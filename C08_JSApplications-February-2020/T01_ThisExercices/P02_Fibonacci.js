function getFibonator() {
    let firstNumber = 0;
    let secondNumber = 1;
    let temp = 0;

    function fib() {
        temp = firstNumber + secondNumber;

        firstNumber = secondNumber;
        secondNumber = temp;

        return firstNumber;
    }

    return fib;
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
