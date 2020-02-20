class Kitchen {
    menu = [];
    productsInStock = [];
    actionsHistory = [];

    constructor(budget) {
        this.budget = budget;
    }

    loadProducts(products) {
        for (const product of products) {
            let [productName, quantity, price] = product.split(' ');

            if (this.budget < +price) {
                this.actionsHistory.push(`There was not enough money to load ${+quantity} ${productName}`);

                continue;
            }

            if (!this.productsInStock[productName]) {
                this.productsInStock[productName] = 0;
            }

            this.productsInStock[productName] += +quantity;
            this.budget -= +price;

            this.actionsHistory.push(`Successfully loaded ${+quantity} ${productName}`);
        }

        return this.actionsHistory.join('\n');
    }

    addToMenu(meal, neededProducts, price) {
        if (this.menu[meal]) {
            return `The ${meal} is already in our menu, try something different.`;
        }

        this.menu.push(meal);

        this.menu[meal] = {
            products: neededProducts,
            price: Number(price)
        };

        return `Great idea! Now with the ${meal} we have ${this.menu.length} meals in the menu, other ideas?`;
    }

    showTheMenu() {
        if (!this.menu.length) {
            return 'Our menu is not ready yet, please come later...';
        }

        return this.menu.map(meal => `${meal} - $ ${this.menu[meal].price}`).join('\n') + '\n';
    }

    makeTheOrder(meal) {
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let canBeCooked = this.menu[meal].products
            .map(product => product. split(' '))
            .every(product => this.productsInStock[product[0]] >= +product[1]);

        if (!canBeCooked) {
            return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
        }
        
        this.menu[meal].products
            .map(product => product. split(' '))
            .forEach(([productName, quantity]) => this.productsInStock[productName] -= +quantity);

        this.budget += this.menu[meal].price;

        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
    }
}

let kitchen = new Kitchen(1000);

console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));

console.log(kitchen.showTheMenu());

console.log(kitchen.makeTheOrder('frozenYogurt'));
console.log(kitchen.productsInStock);