let manager = (function solution() {
    const products = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    };

    let storage = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    return function () {
        let [command, element, quantity] = arguments[0].split(' ');

        if (command === 'restock') {
            storage[element] += +quantity;

            return 'Success';
        } else if (command === 'prepare') {
            let result = 'Success';

            for (let microelement in products[element]) {
                let needed = products[element][microelement] * quantity;

                if (storage[microelement] < needed) {
                    result = `Error: not enough ${microelement} in stock`;
                    break;
                }
            }

            if (result   === 'Success') {
                for (let microelement in products[element]) {
                    let needed = products[element][microelement] * quantity;
                    storage[microelement] -= needed;
                }
            }

            return result;
        } else {
            return `protein=${storage['protein']} carbohydrate=${storage['carbohydrate']} fat=${storage['fat']} flavour=${storage['flavour']}`;
        }

    }
});

manager("restock flavour 50");  // Success
manager("prepare lemonade 4");  