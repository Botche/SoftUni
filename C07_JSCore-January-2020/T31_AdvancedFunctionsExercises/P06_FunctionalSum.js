let sum = (function functionSum() {
    let sum = 0;

    function add(num) {
        sum += num;

        return add;
    }

    add.toString = function () {
        return sum;
    }

    return add;
})();

console.log(sum(4)(3).toString());