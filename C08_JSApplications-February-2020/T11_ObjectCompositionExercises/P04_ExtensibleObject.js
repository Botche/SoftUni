function solve() {
    let myObj = {
        extend: function (template) {
            for (const key in template) {
                if (typeof template[key] === 'function') {
                    this.__proto__[key] = template[key];

                    continue;
                }

                this[key] = template[key];
            }

            return this;
        }
    }

    return myObj;
}

console.log(solve().extend({
    extensionMethod: function () { },
    extensionProperty: 'someString'
}
))