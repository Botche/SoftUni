let Parser = require("./solution.js");
let assert = require("chai").assert;
let beforeEach = require('chai').beforeEach;

describe('Testing info parser', function () {
    describe('Test constructor', function () {
        it('with valid information', function () {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');

            assert.deepEqual(parser.data, JSON.parse('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]'));
            assert.deepEqual(parser._log, ["0: getData"]);
        })
    })

    describe('Test get data()', function () {
        it('with valid information', function () {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');

            assert.deepEqual(parser.data, [{ "Nancy": "architect" }, { "John": "developer" }, { "Kate": "HR" }]);
            assert.deepEqual(parser._log, ['0: getData']);
        })

        it('filther deleted valid information', function () {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            parser.removeEntry('Kate')

            assert.deepEqual(parser.data, [{ "Nancy": "architect" }, { "John": "developer" }]);
            assert.deepEqual(parser._log, ["0: removeEntry", '1: getData']);
        })
    })

    describe('Test print()', function () {
        it('with valid information', function () {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');

            assert.deepEqual(parser.print(), `id|name|position
0|Nancy|architect
1|John|developer
2|Kate|HR`);
            assert.deepEqual(parser._log, ['0: print']);
        })
        it('with valid information, when delete', function () {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            parser.removeEntry('Kate')

            assert.deepEqual(parser.print(), `id|name|position
0|Nancy|architect
1|John|developer`);
            assert.deepEqual(parser._log, ["0: removeEntry", '1: print']);
        })
    })
})