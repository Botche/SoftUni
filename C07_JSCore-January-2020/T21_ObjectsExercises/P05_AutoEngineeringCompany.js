function autoEngineeringCompany(input) {
    let result = input.reduce((acc, element) => {
        let [make, model, quantity] = element.split('|').map(x => x.trim());

        if (!acc[make]) {
            acc[make] = {};
        } 
        
        if (!acc[make][model]) {
            acc[make][model] = +quantity;
        } else{
            acc[make][model] += +quantity;
        }

        return acc;
    }, {});

    for (const make in result) {
        console.log(make);

        for (const model in result[make]) {
            console.log(`###${model} -> ${result[make][model]}`)
        }
    }
}

autoEngineeringCompany(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
);