function arenaTier(input) {
    const arena = new Map();

    for (const line of input) {
        if (line === 'Ave Cesar') {
            break;
        }

        let items = line.split('->').map(x => x.trim());
        if (items.length > 2) {
            let [gladiator, technique, skill] = [items[0], items[1], Number(items[2])];

            if (!arena.has(gladiator)) {
                arena.set(gladiator, new Map());
            }

            if (!arena.get(gladiator).has(technique)) {
                arena.get(gladiator).set(technique, skill);
            }

            if (arena.get(gladiator).get(technique) < skill) {
                arena.get(gladiator).set(technique, skill);
            }
        } else {
            let [firstGladiator, secondGladiator] = line.split('vs').map(x => x.trim());

            if (arena.has(firstGladiator) && arena.has(secondGladiator)) {
                let targetTechnique = [...arena.get(firstGladiator)]
                    .map(i => i[0])
                    .find(item => [...arena.get(secondGladiator)]
                        .map(i => i[0])
                        .includes(item));

                if (targetTechnique) {
                    let firstGladiatorPoints = arena.get(firstGladiator).get(targetTechnique);
                    let secondGladiatorPoints = arena.get(secondGladiator).get(targetTechnique);

                    if (firstGladiatorPoints > secondGladiatorPoints) {
                        arena.delete(secondGladiator);
                    } else {
                        arena.delete(firstGladiator);
                    }
                }
            }
        }
    }

    let result = [...arena]
        .filter(x => [...x[1]]
            .reduce((tot, arr) =>
                tot + arr[1], 0) > 0)
        .sort((a, b) => [...b[1]]
            .reduce((tot, arr) =>
                tot + arr[1], 0
            ) - [...a[1]]
                .reduce((tot, arr) =>
                    tot + arr[1], 0) ||
            a[0].localeCompare(b[0]));

    for (const gladiator of result) {
        console.log(`${gladiator[0]}: ${[...gladiator[1]].reduce((tot, arr) => tot + arr[1], 0)} skill`);

        for (const item of [...gladiator[1]].sort((a, b) => b[1] - a[1] || a[0].localeCompare(b[0]))) {
            console.log(`- ${item[0]} <!> ${item[1]}`);
        }
    }
}

arenaTier(['Pesho -> Duck -> 400',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Support -> 250',
    'Gladius -> Shield -> 250',
    'Pesho vs Gladius',
    'Gladius vs Julius',
    'Gladius vs Gosho',
    'Ave Cesar'
]);