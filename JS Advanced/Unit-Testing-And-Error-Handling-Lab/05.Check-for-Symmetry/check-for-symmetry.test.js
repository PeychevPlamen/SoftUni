const isSymmetric = require('./check-for-symmetry');
const { assert } = require('chai');

describe('Check for symmetry', () => {

    it('test for symmetry', () => {
        let arr = [1, 2, 3, 2, 1];
        let expectedResult = true;
        let actualResult = isSymmetric(arr);

        assert.equal(actualResult, expectedResult);
    })
    it('test input for correct type in array', () => {
        let arr = [1, '1'];
        let expectedResult = false;
        let actualResult = isSymmetric(arr);

        assert.equal(actualResult, expectedResult);
    })
    it('test if input is not array', () => {
        let arr = 'Pesho';
        let expectedResult = false;
        let actualResult = isSymmetric(Array.isArray(arr));

        assert.equal(actualResult, expectedResult);
    })
    it('test if input is string and it is symmetric', () => {
        let arr = ['45', '15', '45'];
        let expectedResult = true;
        let actualResult = isSymmetric(arr);

        assert.equal(actualResult, expectedResult);
    })
    it('test if input is string and it not symmetric', () => {
        let arr = ['45', '15', 'Pesho'];
        let expectedResult = false;
        let actualResult = isSymmetric(arr);

        assert.equal(actualResult, expectedResult);
    })
    it('test if input is a single number', () => {
        let arr = [1];
        let expectedResult = true;
        let actualResult = isSymmetric(arr);

        assert.equal(actualResult, expectedResult);
    })
    it('test if input is a number', () => {
        let arr = 1;
        let expectedResult = false;
        let actualResult = isSymmetric(arr);

        assert.equal(actualResult, expectedResult);
    })
});