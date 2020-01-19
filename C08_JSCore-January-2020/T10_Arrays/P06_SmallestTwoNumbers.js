function smallestTwoNumbers(numbers) {
    let result = numbers.sort()
        .slice(0, 2)
        .join(" ");

    return result;
}

console.log(smallestTwoNumbers([30, 15, 50, 5]));