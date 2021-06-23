const dealership = require('../03.Dealership');
const { assert } = require('chai');

describe("Tests dealership", function () {
    describe("newCarCost tests", function () {

        it("test return correct newCarPrice if no exist discount", function () {

            assert.equal(dealership.newCarCost('Audi', 10000), 10000);

        });
        it("test return correct finalPrice if exist model", function () {

            assert.equal(dealership.newCarCost('Audi A4 B8', 20000), 5000);

        });

    });
    describe("newCarCost tests", function () {

        it("test car equipment", function () {

            assert.deepEqual(dealership.carEquipment(['ac', 'brake'], [0, 1]), ['ac', 'brake']);
            assert.deepEqual(dealership.carEquipment(['ac', 'brake'], [0]), ['ac']);
        });

    });
    describe("euroCategory tests", function () {

        it("test if category >= 4", function () {

            let price = 30000 - 15000;
            let total = price - (price * 0.05);

            assert.equal(dealership.euroCategory(4), `We have added 5% discount to the final price: ${total}.`);
            assert.equal(dealership.euroCategory(99), `We have added 5% discount to the final price: ${total}.`);

        });

        it("test if category is < 4", function () {

            assert.equal(dealership.euroCategory(0), 'Your euro category is low, so there is no discount from the final price!');
            assert.equal(dealership.euroCategory(3), 'Your euro category is low, so there is no discount from the final price!');

        });

    });

});
