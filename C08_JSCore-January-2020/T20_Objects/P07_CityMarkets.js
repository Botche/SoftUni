function cityMarkets(input){
    let result = input.reduce((acc,element) => {
        let [city, product, quantityAndPrice] = element.split('->').map(x=>x.trim());
        let [quantity, price] = quantityAndPrice.split(':').map(x=>x.trim());

        if (!acc[city]) {
            acc[city] = {};
        }
        
        acc[city][product] = +quantity * +price;

        return acc;
    }, {});

    for (const city in result) {
        console.log(`Town - ${city}`);
        for (const product in result[city]) {
            console.log(`$$$${product} : ${result[city][product]}`);
        }
    }
}

cityMarkets(['Sofia -> Laptops HP -> 200 : 2000',
'Sofia -> Raspberry -> 200000 : 1500',
'Sofia -> Audi Q7 -> 200 : 100000',
'Montana -> Portokals -> 200000 : 1',
'Montana -> Qgodas -> 20000 : 0.2',
'Montana -> Chereshas -> 1000 : 0.3']
);