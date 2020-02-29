let assert = require('chai').assert;
let beforeEach = require('mocha').beforeEach;

let ChristmasMovies = require('./02. Christmas Movies_Resources');

describe("Test chirstmas movies", function () {
    let movies;

    beforeEach(function () {
        movies = new ChristmasMovies();
    });

    describe("Test buyMovie()", function () {

        it("with incorrect information", function () {
            movies.buyMovie('Koleda', ['Pesho', 'Gosho', 'Pesho']);

            assert.throws(() => movies.buyMovie('Koleda', ['Pesho', 'Gosho', 'Pesho'])
                , 'You already own Koleda in your collection!');
            assert.equal(movies.movieCollection.length, 1);

            assert.deepEqual(movies.movieCollection[0], {
                name: 'Koleda',
                actors: ['Pesho', 'Gosho']
            });
        });
    });

    describe("Test discardMovie()", function () {
        it("with correct information", function () {
            movies.buyMovie('Koleda', ['Pesho', 'Gosho', 'Pesho']);
            movies.watchMovie('Koleda');
            movies.buyMovie('Koleda2', ['Pesho', 'Gosho', 'Pesho']);
            movies.watchMovie('Koleda2');

            assert.equal(movies.discardMovie('Koleda')
                , 'You just threw away Koleda!');
            assert.equal(Object.keys(movies.watched).length, 1);
            assert.equal(movies.movieCollection.length, 1);
        });

        it("with incorrect information, not exists", function () {
            assert.throws(() => movies.discardMovie('Koleda'));
            assert.equal(movies.movieCollection.length, 0);
        });

        it("with incorrect information, watched", function () {
            movies.buyMovie('Koleda', ['Pesho', 'Gosho', 'Pesho']);
            movies.buyMovie('Koleda2', ['Pesho', 'Gosho', 'Pesho']);
            movies.watchMovie('Koleda2');

            assert.throws(() => movies.discardMovie('Koleda'));
            assert.equal(movies.movieCollection.length, 1);
            assert.equal(Object.keys(movies.watched).length, 1);
        });
    });

    describe("Test watchMovie()", function () {

        it('Test watch movie multiply times', () => {
            movies.buyMovie("Name1", ["Actor1", "Actor2", "Actor1"]);
            movies.watchMovie("Name1");

            assert.equal(movies.watched["Name1"], 1);
        });

        it('Test watch movie multiply times', () => {
            movies.buyMovie("Name1", ["Actor1", "Actor2", "Actor1"]);
            movies.watchMovie("Name1");
            movies.watchMovie("Name1");

            assert.equal(movies.watched["Name1"], 2);
        });
        it("with incorrect information, not exists", function () {
            assert.throw(() => movies.watchMovie('Koleda3'), "No such movie in your collection!");
        });
    });

    describe("Test favouriteMovie()", function () {
        it("with correct information", function () {
            movies.buyMovie('Koleda', ['Pesho', 'Gosho', 'Pesho']);
            movies.watchMovie('Koleda');
            movies.watchMovie('Koleda');
            movies.watchMovie('Koleda');

            movies.buyMovie('Koleda2', ['Pesho', 'Gosho', 'Pesho']);
            movies.watchMovie('Koleda2');
            movies.watchMovie('Koleda2');

            assert.equal(movies.favouriteMovie()
                , 'Your favourite movie is Koleda and you have watched it 3 times!');
        });

        it("with incorrect information, not exists", function () {

            assert.throws(() => movies.favouriteMovie());
        });
    });

    describe("Test favouriteMovie()", function () {
        it("with correct information", function () {
            movies.buyMovie('Koleda', ['Pesho', 'Gosho']);
            movies.buyMovie('Koleda2', ['Pesho', 'Gosho']);
            movies.buyMovie('Koleda3', ['Pesho', 'Pesho']);

            assert.equal(movies.mostStarredActor()
                , 'The most starred actor is Pesho and starred in 3 movies!');
        });

        it("with incorrect information, not exists", function () {
            assert.throws(() => movies.mostStarredActor());
        });
    });
});