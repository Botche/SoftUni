function cappyJuice(input) {
    let juices = [];

    input.reduce((acc, element) => {
        let [juice, quantity] = element.split('=>').map(x => x.trim());

        if (!acc[juice]) {
            acc[juice] = 0;
        }

        acc[juice] += +quantity;

        if (acc[juice] / 1000 >= 1) {
            if (!juices[juice]) {
                juices[juice] = 0;
            }

            juices[juice] += Math.floor(acc[juice] / 1000);
            acc[juice] %= 1000;
        }
        
        return acc;
    }, {});

    for (const juice in juices) {
        console.log(`${juice} => ${juices[juice]}`)
    }
}

cappyJuice(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
);