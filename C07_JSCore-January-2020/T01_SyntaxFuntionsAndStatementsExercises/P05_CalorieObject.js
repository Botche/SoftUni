function combineProductAndCalories(productsWithCalories){
    const result = [];
    let productResult = '';

    for (let index = 0; index < productsWithCalories.length; index+=2) {
        const product = productsWithCalories[index];
        const calories = productsWithCalories[index+1];

        productResult = `${product}: ${calories}`;
        result.push(productResult);
    }

    console.log(`{ ${result.join(', ')} }`)
}

combineProductAndCalories(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);