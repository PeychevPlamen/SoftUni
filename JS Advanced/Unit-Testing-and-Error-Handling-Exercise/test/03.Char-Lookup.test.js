const lookupChar = require('../03.Char-Lookup');
const { assert, expect } = require('chai');

describe('charLookUp tests', () => {
    it('test if input is a string and index is a number', () => {

        assert.isString(lookupChar('this is string', 2), true);

    });
    it('test if input is not a string and index is not a number', () => {

        assert.equal(lookupChar(5, '1'), undefined);
        assert.equal(lookupChar('string', '1'), undefined);

    });
    it('test if string length is smaller or equal than index', () => {

        assert.equal(lookupChar('string', 7), "Incorrect index");

    });
    it('test if index is smaller than zero', () => {

        assert.equal(lookupChar('string', -2), "Incorrect index");

    });
    it('test if return correct result', () => {

        assert.equal(lookupChar('string', 2), 'r');

    });
    it('test if not a string and index is negative number', () => {

        assert.equal(lookupChar(1, -1), undefined);

    });
    it('test if index is equal to string length', () => {

        assert.equal(lookupChar('joro', 4), "Incorrect index");

    });
    it('test if not a string and index is correct', () => {

        assert.equal(lookupChar(1, 0), undefined);

    });
    it('test if index is floating point', () => {

        assert.equal(lookupChar('string', 1.1), undefined);

    });

});