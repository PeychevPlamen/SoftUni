const ChristmasMovies = require('../02. Christmas Movies_Resources');
const { assert, expect } = require('chai');

describe("Tests ChristmasMovies", function () {


    describe("Test buyMovie", function () {
        it("Test if movie is undefined", function () {

            let christmas = new ChristmasMovies();

            assert.equal(christmas.buyMovie('Harry Potter', ['Rupert Grint', 'Dilun Bed']),
                `You just got Harry Potter to your collection in which Rupert Grint, Dilun Bed are taking part!`);
        });
        it("Test if movie throw error", function () {

            let christmas = new ChristmasMovies();
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);

            assert.throw(() => christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']),
                `You already own Home Alone in your collection!`);
        });
        it("Test if movie has one actor", function () {

            let christmas = new ChristmasMovies();

            assert.equal(christmas.buyMovie('Home Alone 2', ['Macaulay Culkin', 'Macaulay Culkin']),
                `You just got Home Alone 2 to your collection in which Macaulay Culkin are taking part!`);
        });

    });

    describe("Test discardMovie", function () {
        it("Test if movie is not at your collection", function () {

            let christmas = new ChristmasMovies();
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);

            assert.throw(() => christmas.discardMovie('Home Alone2'), `Home Alone2 is not at your collection!`);
        });
        it("Test if movie is watched", function () {

            let christmas = new ChristmasMovies();
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.watchMovie('Home Alone');

            assert.equal(christmas.discardMovie('Home Alone'), `You just threw away Home Alone!`);
        });
        it("Test if movie is not watched", function () {

            let christmas = new ChristmasMovies();
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.buyMovie('Home Alone2', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.watchMovie('Home Alone');

            assert.throw(() => christmas.discardMovie('Home Alone2'), `Home Alone2 is not watched!`);
        });

    });
    describe("Test watchMovie", function () {
        it("Test if movie is not at your collection", function () {

            let christmas = new ChristmasMovies();
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);

            assert.throw(() => christmas.watchMovie('Home Alone2'), `No such movie in your collection!`);
        });
        it("Test if movie watched is increase", function () {

            let christmas = new ChristmasMovies();
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.watchMovie('Home Alone');

            assert.equal(christmas.watched['Home Alone'], 1);
        });
        it("Test if movie watched twice", function () {

            let christmas = new ChristmasMovies();
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.watchMovie('Home Alone');
            christmas.watchMovie('Home Alone');

            assert.equal(christmas.watched['Home Alone'], 2);
        });

    });
    describe("Test favouriteMovie", function () {
        it("Test if has favourite movie", function () {

            let christmas = new ChristmasMovies();
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.buyMovie('Home Alone 2', ['Macaulay Culkin']);
            christmas.watchMovie('Home Alone');
            christmas.watchMovie('Home Alone');

            assert.equal(christmas.favouriteMovie(), `Your favourite movie is Home Alone and you have watched it 2 times!`);
        });
        it("Test if has not favourite movie", function () {

            let christmas = new ChristmasMovies();
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);

            assert.throw(() => christmas.favouriteMovie(), `You have not watched a movie yet this year!`);
        });
        
        
    });
    describe("Test mostStarredActor", function () {
        it("Test mostStarredActor count", function () {

            let christmas = new ChristmasMovies();
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.buyMovie('Home Alone 2', ['Macaulay Culkin']);
           christmas.actors.push('Macaulay Culkin');

            assert.equal(christmas.mostStarredActor(), `The most starred actor is Macaulay Culkin and starred in 2 movies!`);
            assert.equal(christmas.actors.length, 1);
        });
        it("Test mostStarredActor throw error", function () {

            let christmas = new ChristmasMovies();
            
            assert.throw(() => christmas.mostStarredActor(), 'You have not watched a movie yet this year!');
        });
        it("Test mostStarredActor count", function () {

            let christmas = new ChristmasMovies();
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.buyMovie('Home Alone 2', ['Macaulay Culkin']);
           christmas.actors.push('Macaulay Culkin');

            
            assert.equal(christmas.actors.length, 1);
        });
        it("Test mostStarredActor count", function () {

            let christmas = new ChristmasMovies();
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.buyMovie('Home Alone 2', ['Macaulay Culkin']);
           christmas.actors.push('Macaulay Culkin');
           christmas.actors.push('Joe Pesci');

            
            assert.equal(christmas.actors.length, 2);
        });
    });

});
