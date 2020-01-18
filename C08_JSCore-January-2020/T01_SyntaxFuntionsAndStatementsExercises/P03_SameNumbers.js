function checkIfAreSame(numbers) {
    let number = String(numbers)[0];
    let isValid = true;
    let sum = Number(number);

    for (let i = 1; i < String(numbers).length; i++) {
        const element = String(numbers)[i];

        if (element != number) {
            isValid = false;
        }

        sum += Number(element);
    }

    console.log(isValid);
    console.log(sum);
}

checkIfAreSame(2222222);