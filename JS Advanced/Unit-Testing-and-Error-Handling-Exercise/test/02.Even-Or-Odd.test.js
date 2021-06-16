const isOddOrEven = require('../02.Even-Or-Odd');
const { assert, expect } = require('chai');

describe('isOddEven Func Test', () => {
    it('test input is a string', () => {
        assert.isString(isOddOrEven('pesho'), true);
    });
    it('test input is not a string return undefined', () => {
        assert.equal(isOddOrEven(15), undefined);
    });
    it('test input is even', () => {
        assert.equal(isOddOrEven('mimi'), 'even');
    });
    it('test input is odd', () => {
        assert.equal(isOddOrEven('pesho'), 'odd');
    });
});