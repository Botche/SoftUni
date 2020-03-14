function carFactory(input) {
    const powerEngine = [
        { power: 90, volume: 1800 },
        { power: 120, volume: 2400 },
        { power: 200, volume: 3500 }
    ];

    const engine = powerEngine.find(engine => input.power <= engine.power);
    const carriage = { type: input.carriage, color: input.color }

    const wheelsDiameter = input.wheelsize % 2 == 0
        ? input.wheelsize - 1
        : input.wheelsize;

    
    const wheels = new Array(4);
    wheels.fill(wheelsDiameter, 0, wheels.length);

    return {
        model: input.model,
        engine: engine,
        carriage: carriage,
        wheels: wheels
    }
}

console.log(carFactory({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));

console.log(carFactory({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}
));