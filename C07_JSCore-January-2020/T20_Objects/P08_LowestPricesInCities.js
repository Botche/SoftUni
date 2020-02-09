function lowestPricesInCities(input) {
    let products = input.reduce((acc, element) => {
        let [townName, productName, productPrice] = element.split('|').map(x => x.trim());

        if (!acc[productName]) {
            acc[productName] = {};
        }

        acc[productName][townName] = productPrice;

        return acc;
    }, {})

    for (const product in products) {

        let townWithLowestPrice = Object.keys(products[product]).sort((a, b) => {
            return products[product][a] - products[product][b];
        })[0];

        console.log(`${product} -> ${products[product][townWithLowestPrice]} (${townWithLowestPrice})`);
    }
}

lowestPricesInCities([
    'Sample Town | Peach | 3',
    'Sofia | Peach | 2',
    'Sofia | Peach | 1',
    'Sample Town | Peach | 1']
);