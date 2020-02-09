function personalBmi(name, age, weight, height) {
    let person = {
        name,
        personalInfo: {
            age,
            weight,
            height
        },
        BMI: Math.round(weight / ((height / 100) ** 2))
    };

    let status = '';

    if (person.BMI <= 18.5) {
        status = 'underweight';
    } else if (person.BMI < 25) {
        status = 'normal';
    } else if (person.BMI < 30) {
        status = 'overweight';
    } else {
        status = 'obese';
        person.recommendation = 'admission required';
    }

    person.status = status;
    return person;
}


console.log(personalBmi('Honey Boo Boo', 9, 57, 137));