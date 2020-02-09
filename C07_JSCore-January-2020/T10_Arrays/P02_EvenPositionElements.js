function evenPositionElements(numbers){
    let result = numbers
        .filter((_, i) => i % 2 === 0)
        .join(" ")

    return result;
}

console.log(evenPositionElements(['20', '30', '40']))