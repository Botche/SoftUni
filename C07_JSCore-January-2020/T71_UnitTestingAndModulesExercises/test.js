let assert = require('chai').assert;

let isOddOrEven = require('./P02_EvenOrOdd');

describe('everOrOdd()', function () {

    it('test with valid input, expected odd', function () {
        let inputValue = 'cat';
        let expectedValue = 'odd';

        assert.equal(isOddOrEven(inputValue), expectedValue, 'The result should be odd.');
    });

    it('test with valid input, expected even', function () {
        let inputValue = 'cat1';
        let expectedValue = 'even';

        assert.equal(isOddOrEven(inputValue), expectedValue, 'The result should be even.');
    });

    it('test with invalid input', function () {
        let inputValue = 1.2;
        let expectedValue = undefined;

        assert.equal(isOddOrEven(inputValue), expectedValue, 'The result should be undefined.');
    });
});

let lookupChar = require('./P03_CharLookup');

describe('lookupChar()', function () {

    it('Check if first argument is string', function () {
        let actualResult = lookupChar(123.123, 0);
        let expectedResult = undefined;

        assert.equal(actualResult, expectedResult, 'The result should be undefined')
    });

    it('Check if second argument is number, tested with string', function () {
        let actualResult = lookupChar('random string', '0');
        let expectedResult = undefined;

        assert.equal(actualResult, expectedResult, 'The result should be undefined')
    });

    it('Check if second argument is number, tested with double number', function () {
        let actualResult = lookupChar('random string', 3.14);
        let expectedResult = undefined;

        assert.equal(actualResult, expectedResult, 'The result should be undefined')
    });

    it('Check if index is in the given range, tested with negative index', function () {
        let actualResult = lookupChar('random string', -1);
        let expectedResult = "Incorrect index";

        assert.equal(actualResult, expectedResult, 'The result should be "Incorrect index"')
    });

    it('Check if index is in the given range, tested with index bigger than string length', function () {
        let actualResult = lookupChar('random string', 100);
        let expectedResult = "Incorrect index";

        assert.equal(actualResult, expectedResult, 'The result should be "Incorrect index"')
    });

    it('Check with valid input', function () {
        let actualResult = lookupChar('random string', 1);
        let expectedResult = "a";

        assert.equal(actualResult, expectedResult, 'The result should be "a"')
    });
});

let mathEnforcer = require('./P04_MathEnforcer');

describe('mathEnforcer()', function () {

    describe('addFive()', function () {

        it('Check with correct input, with integers', function () {
            let actualResult = mathEnforcer.addFive(3);
            let expectedResult = 8;

            assert.equal(actualResult, expectedResult, 'The result should be 8');
        });

        it('Check with correct input, with negative', function () {
            let actualResult = mathEnforcer.addFive(-8);
            let expectedResult = -3;

            assert.equal(actualResult, expectedResult, 'The result should be -3');
        });

        it('Check with correct input, with negative', function () {
            let actualResult = mathEnforcer.addFive(-2.5);
            let expectedResult = 2.5;

            assert.closeTo(actualResult, expectedResult, 0.01, 'The result should be -3');
        });

        it('Check with correct input, with floating', function () {
            let actualResult = mathEnforcer.addFive(3.5);
            let expectedResult = 8.5;

            assert.closeTo(actualResult, expectedResult, 0.01, 'The result should be 8.5');
        });

        it('Check with invalid input, string', function () {
            let actualResult = mathEnforcer.addFive('3');
            let expectedResult = undefined;

            assert.equal(actualResult, expectedResult, 'The result should be undefined');
        });

    })

    describe('subtractTen()', function () {

        it('Check with correct input, with integers', function () {
            let actualResult = mathEnforcer.subtractTen(18);
            let expectedResult = 8;

            assert.equal(actualResult, expectedResult, 'The result should be 8');
        });

        it('Check with correct input, with negative', function () {
            let actualResult = mathEnforcer.subtractTen(-3);
            let expectedResult = -13;

            assert.equal(actualResult, expectedResult, 'The result should be -13');
        });

        it('Check with correct input, with negative', function () {
            let actualResult = mathEnforcer.subtractTen(-3.6);
            let expectedResult = -13.6;

            assert.closeTo(actualResult, expectedResult, 0.01, 'The result should be -13');
        });

        it('Check with correct input, with floating', function () {
            let actualResult = mathEnforcer.subtractTen(13.5);
            let expectedResult = 3.5;

            assert.closeTo(actualResult, expectedResult, 0.01, 'The result should be 3.5');
        });

        it('Check with invalid input, string', function () {
            let actualResult = mathEnforcer.addFive('3');
            let expectedResult = undefined;

            assert.equal(actualResult, expectedResult, 'The result should be undefined');
        });

    })

    describe('sum()', function () {

        it('Check with correct input, with integers', function () {
            let actualResult = mathEnforcer.sum(3, 5);
            let expectedResult = 8;

            assert.equal(actualResult, expectedResult, 'The result should be 8');
        });

        it('Check with correct input, with negative', function () {
            let actualResult = mathEnforcer.sum(-3.5, 10.7);
            let expectedResult = 7.2;

            assert.closeTo(actualResult, expectedResult, 0.01, 'The result should be 7.1');
        });

        it('Check with correct input, with negative', function () {
            let actualResult = mathEnforcer.sum(-3.5, -10.7);
            let expectedResult = -14.2;

            assert.closeTo(actualResult, expectedResult, 0.01, 'The result should be 7.1');
        });

        it('Check with correct input, with floating', function () {
            let actualResult = mathEnforcer.sum(3.5, 17.6);
            let expectedResult = 21.1;

            assert.closeTo(actualResult, expectedResult, 0.01, 'The result should be 21.1');
        });

        it('Check with invalid input, string', function () {
            let actualResult = mathEnforcer.sum('3', 2);
            let expectedResult = undefined;

            assert.equal(actualResult, expectedResult, 'The result should be undefined');
        });

        it('Check with invalid input, string', function () {
            let actualResult = mathEnforcer.sum(3, '2');
            let expectedResult = undefined;

            assert.equal(actualResult, expectedResult, 'The result should be undefined');
        });

    });
});

let StringBuilder = require('./P05_StringBuilder');

describe('Testing class stringBuilder', function () {
    describe('Testing constructor', function () {

        it('with empty constructor', function () {

            let actualResult = new StringBuilder();
            let expectedResult = [];

            assert.deepEqual(actualResult._stringArray, expectedResult);
        });

        it('with invalid parameter', function () {

            let expectedResult = 'Argument must be string';

            assert.throws(() => { new StringBuilder(123) }, expectedResult);
        });

        it('with invalid parameter', function () {

            let expectedResult = 'Argument must be string';

            assert.throws(() => { new StringBuilder([]) }, expectedResult);
        });

        it('with valid parameter', function () {
            let actualResult = new StringBuilder('string');
            let expectedResult = 'string';

            assert.equal(actualResult.toString(), expectedResult);
        });
    });

    describe('Testing append()', function () {

        it('with valid string', function () {

            let actualResult = new StringBuilder('string');
            let expectedResult = 'stringstr';

            actualResult.append('str');

            assert.equal(actualResult.toString(), expectedResult);
        });

        it('with empty string', function () {

            let actualResult = new StringBuilder('string');
            let expectedResult = 'string';

            actualResult.append('');

            assert.equal(actualResult.toString(), expectedResult);
        });

        it('with invalid parameter', function () {

            let actualResult = new StringBuilder('string');
            let expectedResult = 'Argument must be string';

            assert.throws(() => actualResult.append(123), expectedResult);
        });
    });

    describe('Testing prepend()', function () {

        it('with valid parameter', function () {

            let actualResult = new StringBuilder('string');
            let expectedResult = 'strstring';

            actualResult.prepend('str');

            assert.equal(actualResult.toString(), expectedResult);
        });

        it('with invalid parameter', function () {

            let actualResult = new StringBuilder('string');
            let expectedResult = 'Argument must be string';

            assert.throws(() => actualResult.prepend(123), expectedResult);
        });
    });

    describe('Testing insertAt()', function () {

        it('with valid parameters', function () {

            let actualResult = new StringBuilder('string');
            let expectedResult = 'ststrring';

            actualResult.insertAt('str', 2);

            assert.equal(actualResult.toString(), expectedResult);
        });

        it('with invalid first parameter', function () {

            let actualResult = new StringBuilder('string');
            let expectedResult = 'Argument must be string';

            assert.throws(() => actualResult.insertAt(123, 2), expectedResult);
        });
    });

    describe('Testing remove()', function () {

        it('with valid parameters', function () {

            let actualResult = new StringBuilder('string');
            let expectedResult = 'ing';

            actualResult.remove(0, 3);

            assert.equal(actualResult.toString(), expectedResult);
        });
    });

    describe('Testing toString()', function () {

        it('with empty constructor', function () {

            let actualResult = new StringBuilder();
            let expectedResult = '';

            assert.deepEqual(actualResult.toString(), expectedResult);
        });
    });

    describe('Type of StringBuilder', function () {

        it('StringBuilder exist', function () {
            assert.exists(StringBuilder);
        });

        it('StringBuilder type', function () {
            assert.equal(typeof StringBuilder, 'function');
        });

        it('should have the correct function properties', function () {
            assert.isFunction(StringBuilder.prototype.append);
            assert.isFunction(StringBuilder.prototype.prepend);
            assert.isFunction(StringBuilder.prototype.insertAt);
            assert.isFunction(StringBuilder.prototype.remove);
            assert.isFunction(StringBuilder.prototype.toString);
        });

        it('full test', function () {
            let str = new StringBuilder('hello');

            str.append(', there');
            str.prepend('User, ');
            str.insertAt('woop', 5);
            str.remove(6, 3);

            assert.equal(str.toString(), 'User,w hello, there');
        });
    });
});

let PaymentPackage = require('./P06_PaymentPackage');

describe('Testing class payment package', function () {

    describe('Testing constructor', function () {

        it('with valid parameters', function () {

            let paymentPackage = new PaymentPackage('name', 3);

            assert.property(paymentPackage, 'name');
            assert.property(paymentPackage, 'value');
            assert.property(paymentPackage, 'VAT');
            assert.property(paymentPackage, 'active');

            assert.equal(paymentPackage.VAT, 20);
            assert.equal(paymentPackage.active, true);
        });

        it('with valid parameters', function () {

            let paymentPackage = new PaymentPackage('name', 3);

            assert.isObject(paymentPackage);
            assert.isObject(paymentPackage);
        });
    });

    describe('Testing setters of properties', function () {

        it('Test name setter with non string value', function () {

            let paymentPackage = new PaymentPackage('name', 3);

            assert.throws(() => { paymentPackage.name = 3 });
        });

        it('Test name setter with empty string value', function () {

            let paymentPackage = new PaymentPackage('name', 3);

            assert.throws(() => { paymentPackage.name = '' });
        });

        it('Test value setter with not number value', function () {

            let paymentPackage = new PaymentPackage('name', 3);

            assert.throws(() => { paymentPackage.value = '3' });
        });

        it('Test value setter with negative number value', function () {

            let paymentPackage = new PaymentPackage('name', 3);

            assert.throws(() => { paymentPackage.value = -3 });
        });

        it('Test VAT setter with not number value', function () {

            let paymentPackage = new PaymentPackage('name', 3);

            assert.throws(() => { paymentPackage.VAT = '3' });
        });

        it('Test VAT setter with negative number value', function () {

            let paymentPackage = new PaymentPackage('name', 3);

            assert.throws(() => { paymentPackage.VAT = -3 });
        });

        it('Test active setter with not boolean value', function () {

            let paymentPackage = new PaymentPackage('name', 3);

            assert.throws(() => { paymentPackage.active = 'asd' });
        });
    });

    describe('Test toString()', function () {

        it('correct output', function () {

            let paymentPackage = new PaymentPackage('name', 3);

            const output = [
                `Package: ${paymentPackage.name}` + (paymentPackage.active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${paymentPackage.value}`,
                `- Value (VAT ${paymentPackage.VAT}%): ${paymentPackage.value * (1 + paymentPackage.VAT / 100)}`
            ];

            assert.equal(paymentPackage.toString(), output.join('\n'));
        });

        it('correct output', function () {

            let paymentPackage = new PaymentPackage('name', 3);

            paymentPackage.active = false;

            const output = [
                `Package: ${paymentPackage.name}` + (paymentPackage.active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${paymentPackage.value}`,
                `- Value (VAT ${paymentPackage.VAT}%): ${paymentPackage.value * (1 + paymentPackage.VAT / 100)}`
            ];

            assert.equal(paymentPackage.toString(), output.join('\n'));
        });

        it("test toString", () => {
            let newObj = new PaymentPackage('HR Services', 0);
            newObj.VAT = 0;

            assert.equal(newObj.toString(), 'Package: HR Services\n- Value (excl. VAT): 0\n- Value (VAT 0%): 0');
        });
    });
});

let Warehouse = require('./P07_Warehouse');

describe('Testing class Warehouse', function () {

    beforeEach(function () {
        warehouse = new Warehouse(28);
    });

    describe('Test Constructor', () => {
        it('Test properties', () => {
            assert.equal(warehouse.capacity, 28);
            assert.deepEqual(warehouse.availableProducts, {
                'Food': {},
                'Drink': {}
            });
        });

        it('Test error properties', () => {
            const result = () => new Warehouse('Error');
            assert.throws(result, `Invalid given warehouse space`);
        });
    });

    describe('Test addProduct() method', () => {
        it('Test error', () => {
            const result = () => warehouse.addProduct("Food", "Test", 123);
            assert.throws(result, `There is not enough space or the warehouse is already full`);
        });

        it('Test functionality', () => {
            let result = warehouse.addProduct("Food", "Test", 18);
            assert.equal(warehouse.availableProducts.Food["Test"], 18);
            assert.deepEqual(result, {
                Test: 18
            });
            
            result = warehouse.addProduct("Drink", "DrinkTest", 10);
            assert.equal(warehouse.availableProducts.Drink["DrinkTest"], 10);
            assert.deepEqual(result, {
                DrinkTest: 10
            });
        });
    });

    describe("Test orderProduct() method", function () {
        it("Test functionality with available products", function () {
            warehouse.addProduct("Drink", "A", 2);
            warehouse.addProduct("Drink", "B", 5);
            warehouse.addProduct("Food", "Z", 1);
            warehouse.addProduct("Food", "S", 2);

            const result = JSON.stringify(warehouse.orderProducts("Drink"));

            assert.equal(result,`{"B":5,"A":2}`);
        });

        it("Test functionality without available products", function () {
            const result = JSON.stringify(warehouse.orderProducts("Drink"));
            assert.equal(result, `{}`);
        });
    });

    describe('Test occupiedCapacity() method', () => {
        it('Test zero result', () => {
            const result = warehouse.occupiedCapacity();
            assert.equal(result, 0);
        });

        it('Test none-zero result', () => {
            warehouse.addProduct("Food", "Z", 1);
            warehouse.addProduct("Food", "A", 3);
            warehouse.addProduct("Drink", "B", 2);
            warehouse.addProduct("Drink", "E", 8);

            const result = warehouse.occupiedCapacity();

            assert.equal(result, 14);
        });
    });

    describe('Test revision() method', () => {
        it('Test empty output', () => {
            const result = warehouse.revision();
            assert.equal(result, "The warehouse is empty");
        });

        it('Test none-empty output', () => {
            warehouse.addProduct("Food", "Z", 1);
            warehouse.addProduct("Food", "A", 3);
            warehouse.addProduct("Drink", "B", 2);
            warehouse.addProduct("Drink", "E", 8);

            const result = warehouse.revision();

            assert.equal(result, "Product type - [Food]\n- Z 1\n- A 3\nProduct type - [Drink]\n- B 2\n- E 8");
        });
    });

    describe('Test scrapeAProduct() method', () => {
        it('Test error', () => {
            const result = () => warehouse.scrapeAProduct("Error", 12);
            assert.throws(result, `Error do not exists`);
        });

        it('Test more expected quantity functionality', () => {
            warehouse.addProduct("Food", "Z", 1);
            warehouse.addProduct("Food", "A", 3);
            warehouse.addProduct("Drink", "B", 2);
            warehouse.addProduct("Drink", "E", 8);

            const result = warehouse.scrapeAProduct("Z", 12);

            assert.deepEqual(result, {
                Z: 0,
                A: 3
            });
        });

        it('Test expected quantity functionality', () => {
            warehouse.addProduct("Food", "Z", 1);
            warehouse.addProduct("Food", "A", 3);
            warehouse.addProduct("Drink", "B", 2);
            warehouse.addProduct("Drink", "E", 8);

            const result = warehouse.scrapeAProduct("B", 1);

            assert.deepEqual(result, {
                B: 1,
                E: 8
            });
        });
    });
});