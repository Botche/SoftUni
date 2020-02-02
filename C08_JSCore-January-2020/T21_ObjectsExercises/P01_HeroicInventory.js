function heroicInventory(input) {
    let result = [];

    result = input.reduce((acc, element) => {
        let splittedData = element.split('/').map(x => x.trim());

        let hero = { 
            name: splittedData[0], 
            level: + splittedData[1], 
            items: splittedData.length != 2 ? splittedData[2].split(', ') : new Array() 
        }

        acc = [...acc, hero];

        return acc;
    }, []);

    console.log(JSON.stringify(result));
}

heroicInventory(['Isacc / 25',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
);