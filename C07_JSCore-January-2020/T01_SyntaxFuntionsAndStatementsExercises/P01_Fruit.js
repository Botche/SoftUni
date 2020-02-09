function buyFruit(fruitName, fruitWeightInGrams, priceForKg){
    let fruitWeightInKg = fruitWeightInGrams / 1000;
    let moneyForFruit = fruitWeightInKg * priceForKg;

    console.log(`I need $${moneyForFruit.toFixed(2)} to buy ${fruitWeightInKg.toFixed(2)} kilograms ${fruitName}.`);
}

buyFruit('a', 2500, 1.80)