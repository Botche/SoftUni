function storeCatalogue(input){
    let result = input.sort((a,b) => {
        let [firstProduct, items] = a.split(':').map(x=>x.trim());
        let [secondProduct, otherItems] = b.split(':').map(x=>x.trim());

        return firstProduct.localeCompare(secondProduct);
    }).reduce((acc, element) => {
        let [product, price] = element.split(':').map(x=>x.trim());
        let firstLetter = product[0];

        if (!acc[firstLetter]) {
            acc[firstLetter] = [];
        }

        acc[firstLetter].push(`${product}: ${price}`);

        return acc;
    }, {});

   for (const letter in result) {
       console.log(letter);
       result[letter].forEach(element => {
           console.log(`  ${element}`);
       });
   }
}

storeCatalogue(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);