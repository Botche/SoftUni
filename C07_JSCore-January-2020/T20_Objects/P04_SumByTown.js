function sumByTown(input) {
    const allCitiesWithIncomes = {};

    for (let i = 0; i < input.length; i += 2) {
        let city = input[i];
        let incomeForCity = +input[i + 1];

        if (allCitiesWithIncomes[city]) {
            allCitiesWithIncomes[city] += incomeForCity;
        } else {
            allCitiesWithIncomes[city] = incomeForCity;
        }
    }

    console.log(JSON.stringify(allCitiesWithIncomes));
}

sumByTown(['Sofia',
    '20',
    'Varna',
    '3',
    'Sofia',
    '5',
    'Varna',
    '4']
);

sumByTown(['Sofia',
    '20',
    'Varna',
    '3',
    'sofia',
    '5',
    'varna',
    '4']
)