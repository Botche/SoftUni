function populationInTowns(towns){
    const result = towns.reduce((acc, element) => {
        let [city,population] = element.split('<->').map(x=>x.trim());

        if (acc[city]) {
            acc[city]+= +population;
        } else {
            acc[city] = +population;
        }

        return acc;
    }, {});

    for (const key in result) {
        console.log(`${key} : ${result[key]}`)
    }
}

populationInTowns(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
);

populationInTowns(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
);