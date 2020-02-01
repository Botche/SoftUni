function toJson(input) {
    let towns = [];
    let regex = /\s*\|\s*/;

    for(let line of input.splice(1)) {
        let tokens = line.split(regex);
        let townObj = { Town: tokens[1], Latitude: +((+tokens[2]).toFixed(2)), Longitude: +((+tokens[3]).toFixed(2))};
        towns.push(townObj);
    }

    console.log(JSON.stringify(towns));
}

toJson(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'
]);

toJson(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |'
]);