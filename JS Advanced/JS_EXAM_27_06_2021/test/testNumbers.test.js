const testNumbers = require('../testNumbers');
const { assert, expect } = require('chai');

describe("Tests testNumbers", function () {
    describe("test sumNumbers", function () {
        it("test if return undefined", function () {
            assert.equal(testNumbers.sumNumbers('string', 'string2'), undefined);
        });

        it("test if return correct result", function () {
            let num1 = 5;
            let num2 = 5;
            let sum = (num1 + num2).toFixed(2);
            assert.strictEqual(testNumbers.sumNumbers(num1, num2), sum);
        });
        it("test if return correct result", function () {
            let num1 = 5.5;
            let num2 = 5.25;
            let sum = (num1 + num2).toFixed(2);
            assert.strictEqual(testNumbers.sumNumbers(num1, num2), sum);
        });
        it("test if return correct result", function () {
            let num1 = -5.5;
            let num2 = 5.25;
            let sum = (num1 + num2).toFixed(2);
            assert.strictEqual(testNumbers.sumNumbers(num1, num2), sum);
        });
    });
    describe("test numberChecker", function () {
        it("test if throw error", function () {
            assert.throw(() => testNumbers.numberChecker('string'), 'The input is not a number!');
            assert.throw(() => testNumbers.numberChecker(NaN), 'The input is not a number!');
        });
        it("test if return even num", function () {
            assert.equal(testNumbers.numberChecker(4), 'The number is even!');
            assert.equal(testNumbers.numberChecker(16), 'The number is even!');
        });
        it("test if return odd num", function () {
            assert.equal(testNumbers.numberChecker(7), 'The number is odd!');
            assert.equal(testNumbers.numberChecker(77), 'The number is odd!');
        });

    });
    describe("test averageSumArray", function () {
        it("test if return correct arrSum", function () {
            let arr1 = [1, 2, 3];
            let arrLength = arr1.length;
            let expectedResult = 6 / arrLength;

            assert.equal(testNumbers.averageSumArray(arr1), expectedResult);
        });


    });
});
