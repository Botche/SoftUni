let expect = require('chai').expect;

let sum = require('./P04_SumOfNumbers').sum;

describe('sum(arr) - sum array of numbers', function () {
    it('should return 3 for [1,2]', function () {
        expect(sum([1, 2])).to.be.equal(3);
    });
    it('should return 1 for [1]', function () {
        expect(sum([1])).to.be.equal(1);
    });
    it('should return 0 for empty array', function () {
        expect(sum([])).to.be.equal(0);
    });
    it('should return 3 for [1.5, 2.5, -1]', function () {
        expect(sum([1.5, 2.5, -1])).to.be.equal(3);
    });
    it('should return NaN for invalid data', function () {
        expect(sum("invalid data")).to.be.NaN;
    });
});

let isSymmetric = require('./P05_CheckForSymmetry').isSymmetric;

describe('isSymetric(arr) - checks if array si symetric', function () {
    it('should return true if array is symmetric', function () {
        expect(isSymmetric([1, 2, 1])).to.be.equal(true);
    });
    it('should return true if array is symmetric', function () {
        expect(isSymmetric(['cat', 'is', 'cat'])).to.be.equal(true);
    });
    it('should return false if array is not symmetric', function () {
        expect(isSymmetric([1, 2, 3])).to.be.equal(false);
    });
    it('should return false if array is not symmetric', function () {
        expect(isSymmetric(['cat', 'is', 'not', 'cat'])).to.be.equal(false);
    });
    it('should return false if input is not array', function () {
        expect(isSymmetric(2)).to.be.equal(false);
    });
    it('should return false if input is not array', function () {
        expect(isSymmetric('aasdfa')).to.be.equal(false);
    });
    it("should return true for [5,'hi',{a:5},new Date(),{a:5},'hi',5]", function () {
        expect(isSymmetric([5, 'hi', {
            a: 5
        }, new Date(), {
                a: 5
            }, 'hi', 5])).to.be.equal(true);
    });
})


let rgbToHex = require('./P06_RGBtoHEX').rgbToHexColor;
describe('convert a RGB color to HEX', function () {
    it('should return undefined if red color is string ("red", 125, 125)', function () {
        expect(rgbToHex("red", 125, 125)).to.be.equal(undefined);
    });
    it('should return undefined if red color is invalid number (-125, 125, 125)', function () {
        expect(rgbToHex(-125, 125, 125)).to.be.equal(undefined);
    });
    it('should return undefined if red color is invalid number (256, 125, 125)', function () {
        expect(rgbToHex(256, 125, 125)).to.be.equal(undefined);
    });

    it('should return undefined if green color is string (125, "green", 125)', function () {
        expect(rgbToHex(125, 'green', 125)).to.be.equal(undefined);
    });
    it('should return undefined if green color is invalid number (125, -125, 125)', function () {
        expect(rgbToHex(125, -125, 125)).to.be.equal(undefined);
    });
    it('should return undefined if green color is invalid number (125, 256, 125)', function () {
        expect(rgbToHex(125, 256, 125)).to.be.equal(undefined);
    });

    it('should return undefined if color is invalid number ([0], 256, 125)', function () {
        expect(rgbToHex([0], 256, 125)).to.be.equal(undefined);
    });

    it('should return undefined if blue color is string (125, 125, "blue")', function () {
        expect(rgbToHex(125, 125, 'blue')).to.be.equal(undefined);
    });
    it('should return undefined if blue color is invalid number (125, 125, -125)', function () {
        expect(rgbToHex(125, 125, -125)).to.be.equal(undefined);
    });
    it('should return undefined if blue color is invalid number (125, 125, 256)', function () {
        expect(rgbToHex(125, 125, 256)).to.be.equal(undefined);
    });

    it("should return #FF9EAA for (255, 158, 170)", function () {
        expect(rgbToHex(255, 158, 170)).to.be.equal("#FF9EAA");
    });
    it('should return #FFFFFF (255, 255, 255', function () {
        expect(rgbToHex(255, 255, 255)).to.be.equal('#FFFFFF');
    })
    it('should return #000000 (0, 0, 0', function () {
        expect(rgbToHex(0, 0, 0)).to.be.equal('#000000');
    })
    it("should return #0C0D0E for (12, 13, 14)", function () {
        expect(rgbToHex(12, 13, 14)).to.be.equal("#0C0D0E");
    });

    it("should return undefined for (3.14,0,0)", function () {
        expect(rgbToHexColor(3.14, 0, 0)).to.be.equal(undefined);
    });
    it("should return undefined for (0,3.14,0)", function () {
        expect(rgbToHexColor(0, 3.14, 0)).to.be.equal(undefined);
    });
    it("should return undefined for (0,0,3.14)", function () {
        expect(rgbToHexColor(0, 0, 3.14)).to.be.equal(undefined);
    });
});


let createCalculator = require('./P07_AddSubstract').createCalculator;

describe('testing calculator if works properly', function () {
    let calc;

    beforeEach(function () {
        calc = createCalculator();
    });

    describe('checks true cases', function () {
        it('sum should be 0 firstly', function () {
            let value = calc.get();

            expect(value).to.be.equal(0);
        });
        it('sum should be 5 after add 2, add 3', function () {
            calc.add(2);
            calc.add(3);
            let value = calc.get();

            expect(value).to.be.equal(5);
        });
        it('sum should be -3 after substact 3', function () {
            calc.subtract(3);
            let value = calc.get();

            expect(value).to.be.equal(-3);
        });
        it("should return 2 after add(10); subtract('7'); add('-2'); subtract(-1)", function () {
            calc.add(10);
            calc.subtract('7');
            calc.add('-2');
            calc.subtract(-1);
            let value = calc.get();
            expect(value).to.be.equal(2);
        });
    });
    describe('check for exceptions', function () {
        it('add should return NaN if input is a string', function () {
            calc.add('aadd');
            expect(calc.get()).to.be.NaN;
        });
        it('substract should return Nan if input is a string', function () {
            calc.subtract('asdas');
            expect(calc.get()).to.be.NaN;
        });
        it('substract should return Nan if input is an array', function () {
            calc.subtract([1, 2, 3]);
            expect(calc.get()).to.be.NaN;
        });
        it('substract should return Nan if input is an object', function () {
            calc.subtract({ name: 'Pesho' });
            expect(calc.get()).to.be.NaN;
        });
    })
});