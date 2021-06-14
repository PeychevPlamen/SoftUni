const sum = require('./sumNumbers');
const { assert } = require('chai');

describe('Test sum numbers', () => {

    it('check if it is one number array', () => {
        let arr = [1];
        let expectedResult = 1;
        let actualResult = sum(arr);

        assert.equal(actualResult, expectedResult);
    });
    it('check sum of numbers in arr', () => {
        let arr = [1, 2, 3];
        let expectedResult = 6;
        let actualResult = sum(arr);

        assert.equal(actualResult, expectedResult);
    });
});