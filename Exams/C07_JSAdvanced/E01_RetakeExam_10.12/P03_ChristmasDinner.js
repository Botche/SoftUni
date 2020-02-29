class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget() {
        return this._budget;
    }

    set budget(value) {
        if (value < 0) {
            throw new Error('The budget cannot be a negative number');
        }

        this._budget = value;
    }

    shopping(products = []) {
        let [productName, price] = products;

        if (this.budget < price) {
            throw new Error('Not enough money to buy this product');
        }

        this.budget -= price;
        this.products.push(productName);
        return `You have successfully bought ${productName}!`;
    }

    recipes(recipe) {
        let name = recipe['recipeName'];
        let productList = recipe['productsList'];

        let canBeCooked = productList.every(product => this.products.includes(product));

        if (!canBeCooked) {
            throw new Error('We do not have this product');
        }

        this.dishes.push(recipe);

        return `${name} has been successfully cooked!`
    }

    inviteGuests(name, dish) {
        if (!this.dishes.find(d => d.recipeName === dish)) {
            throw new Error('We do not have this dish');
        }

        if (this.guests[name]) {
            throw new Error('This guest has already been invited');
        }

        this.guests[`${name}`] = dish;

        return `You have successfully invited ${name}!`;
    }

    showAttendance() {
        let output = [];

        Object.keys(this.guests).forEach(guest => {
            let name = guest;
            let dish = this.guests[guest];
            let products = this.dishes
                .find(dish => dish.recipeName === this.guests[guest])
                .productsList
                .join(', ');

            output.push(`${name} will eat ${dish}, which consists of ${products}`);
        });

        return output.join('\n');
    }
}


let dinner = new ChristmasDinner(300);

console.log(dinner.shopping(['Salt', 1]));
console.log(dinner.shopping(['Beans', 3]));
console.log(dinner.shopping(['Cabbage', 4]));
console.log(dinner.shopping(['Rice', 2]));
console.log(dinner.shopping(['Savory', 1]));
console.log(dinner.shopping(['Peppers', 1]));
console.log(dinner.shopping(['Fruits', 40]));
console.log(dinner.shopping(['Honey', 10]));

console.log(dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
}));
console.log(dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
}));
console.log(dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
}));

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());
