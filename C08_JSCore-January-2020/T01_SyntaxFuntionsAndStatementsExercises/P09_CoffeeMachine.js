function coffeeMachine(inputs) {
    let totalMoney = 0;

    for (let index = 0; index < inputs.length; index++) {
        let input = inputs[index].split(', ');

        let coins = Number(input[0]);
        let typeOfDrink = String(input[1]);
        let priceOfDrink = 0;

        if (typeOfDrink === 'coffee') {
            let typeOfCoffee = String(input[2]);

            if (typeOfCoffee == 'caffeine') {
                priceOfDrink = 0.80;
            } else {
                priceOfDrink = 0.90;
            }

            let milkOrSugar = input[3];
            if (milkOrSugar == "milk") {
                priceOfDrink += Math.round(priceOfDrink * 0.10 * 10) / 10;
                let sugar = input[4] == 0 ? 0 : 0.10;
                priceOfDrink += sugar;
            } else {
                let sugar = milkOrSugar == 0 ? 0 : 0.10;
                priceOfDrink += sugar;
            }

        } else {
            priceOfDrink = 0.80;

            let milkOrSugar = input[2];
            if (milkOrSugar == "milk") {
                priceOfDrink += Math.round(priceOfDrink * 0.10 * 10) / 10;
                let sugar = input[4] == 0 ? 0 : 0.10;
                priceOfDrink += sugar;
            } else {
                let sugar = milkOrSugar == 0 ? 0 : 0.10;
                priceOfDrink += sugar;
            }
        }

        let change = coins - priceOfDrink;
        if (change >= 0) {
            console.log(`You ordered ${typeOfDrink}. Price: $${priceOfDrink.toFixed(2)} Change: $${change.toFixed(2)}`)
            totalMoney += priceOfDrink;
        } else {
            console.log(`Not enough money for ${typeOfDrink}. Need $${Math.abs(change).toFixed(2)} more`);
        }
    }

    console.log(`Income Report: $${totalMoney.toFixed(2)}`);
}

coffeeMachine(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2', '1.00, coffee, decaf, 0']);
coffeeMachine(['8.00, coffee, decaf, 4', '1.00, tea, 2']);