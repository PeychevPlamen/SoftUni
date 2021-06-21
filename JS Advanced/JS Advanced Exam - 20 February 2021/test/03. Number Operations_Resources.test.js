const numberOperations = require('../03. Number Operations_Resources');
const { assert, expect } = require('chai');

describe("Tests numberOperations", function () {
    describe("Test powNumber", function () {
        it("test if return correct result", function () {
            assert.equal(numberOperations.powNumber(5), 25);
            assert.equal(numberOperations.powNumber(2.2), 2.2 * 2.2);
        });
        it("test if input is not a number", function () {
            assert.equal(numberOperations.powNumber('5'), 25);
        });

    });
    describe("Test numberChecker", function () {
        it("test if input is not a number", function () {
            assert.throw(() => numberOperations.numberChecker('string'), 'The input is not a number!');
            assert.throw(() => numberOperations.numberChecker(NaN), 'The input is not a number!');
        });
        it("test if input is lower than 100", function () {
            assert.equal(numberOperations.numberChecker(99), 'The number is lower than 100!');
            assert.equal(numberOperations.numberChecker(-10), 'The number is lower than 100!');
        });
        it("test if input is >= 100", function () {
            assert.equal(numberOperations.numberChecker(101), 'The number is greater or equal to 100!');
            assert.equal(numberOperations.numberChecker(100), 'The number is greater or equal to 100!');
        });

    });
    describe("Test sumArrays", function () {
        it("test if return correct result of sum of arrays", function () {
            let arr1 = [1, 2, 3];
            let arr2 = [1, 2];

            const expectedArr = [2, 4, 3];

            assert.deepEqual(numberOperations.sumArrays(arr1, arr2), expectedArr);
        });
        it("test if return not correct result of sum of arrays", function () {
            let arr1 = [1, 2, 3];
            let arr2 = [1, 2];
                     
            const expectedArr = [2, 4];

            assert.notDeepEqual(numberOperations.sumArrays(arr1, arr2), expectedArr);
        });

    });
});
