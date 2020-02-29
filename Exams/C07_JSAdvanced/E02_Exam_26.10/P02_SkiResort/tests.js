let assert = require('chai').assert;
let beforeEach = require('mocha').beforeEach;

let SkiResort = require('./solution');

describe('SkiResort', function () {
    let skiResort;

    beforeEach(function () {
        skiResort = new SkiResort('Name');
    });

    describe('Testing constructor', function () {
        it('with proper string', function () {
            assert.equal(skiResort.name, 'Name');
            assert.equal(skiResort.voters, 0);
            assert.deepEqual(skiResort.hotels, []);
        })
    })

    describe('Testing get bestHotel', function () {
        it('with empty voters', function () {
            assert.equal(skiResort.bestHotel, 'No votes yet');
        })
        it('with empty voters', function () {
            skiResort.build('Hotel', 12);
            skiResort.build('Hotel1', 15);

            skiResort.leave('Hotel', 1, 10);
            skiResort.leave('Hotel1', 2, 4);

            assert.equal(skiResort.bestHotel, 'Best hotel is Hotel with grade 10. Available beds: 13');
        })
    })

    describe('Testing build()', function () {
        it('with empty name', function () {
            assert.throw(() => skiResort.build('', 12), 'Invalid input');
        })
        it('with beds lower than 1', function () {
            assert.throw(() => skiResort.build('FakeHotel', 0), 'Invalid input');
        })
        it('with correct input', function () {

            assert.equal(skiResort.build('Hotel', 12), 'Successfully built new hotel - Hotel');
            assert.equal(skiResort.hotels.length, 1);
        })
    })

    describe('Testing book()', function () {
        it('with empty name', function () {
            assert.throw(() => skiResort.book('', 12), 'Invalid input');
        })
        it('with beds lower than 1', function () {
            assert.throw(() => skiResort.book('FakeHotel', 0), 'Invalid input');
        })
        it('with not existing hotel', function () {
            assert.throw(() => skiResort.book('FakeHotel', 12), 'There is no such hotel');
        })
        it('with more beds than the hotel has', function () {
            skiResort.build('Hotel', 12);
            assert.throw(() => skiResort.book('Hotel', 13), 'There is no free space');
        })
        it('with correct input 2', function () {
            skiResort.build('Hotel', 12);
            skiResort.book('Hotel', 5);

            assert.equal(skiResort.book('Hotel', 6), 'Successfully booked');
            assert.equal(skiResort.hotels.find(hotel => hotel.name === 'Hotel').beds, 1);
        })
        it('with correct input 2', function () {
            skiResort.build('Hotel', 12);
            skiResort.book('Hotel', 7);

            assert.throws(() => skiResort.book('Hotel', 6), 'There is no free space');
            assert.equal(skiResort.hotels.find(hotel => hotel.name === 'Hotel').beds, 5);
        })
    })

    describe('Testing leave()', function () {
        it('with empty name', function () {
            assert.throw(() => skiResort.leave('', 12), 'Invalid input');
        })
        it('with beds lower than 1', function () {
            assert.throw(() => skiResort.leave('FakeHotel', 0), 'Invalid input');
        })
        it('with not existing hotel', function () {
            assert.throw(() => skiResort.leave('FakeHotel', 12), 'There is no such hotel');
        })
        it('with correct input', function () {
            skiResort.build('Hotel', 12);

            assert.equal(skiResort.leave('Hotel', 12, 3), '12 people left Hotel hotel');
            assert.equal(skiResort.hotels.find(hotel => hotel.name === 'Hotel').points, 36);
            assert.equal(skiResort.voters, 12);
        })
    })

    describe('Testing averageGrade()', function () {
        it('with empty voters', function () {
            assert.equal(skiResort.averageGrade(), 'No votes yet');
        })
        it('with correct input', function () {
            skiResort.build('Hotel', 12);
            skiResort.build('Hotel2', 12);

            skiResort.leave('Hotel', 12, 3)
            skiResort.leave('Hotel2', 6, 5)

            assert.equal(skiResort.averageGrade(), 'Average grade: 3.67');
        })
    })
});
