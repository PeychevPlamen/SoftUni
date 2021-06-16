const mathEnforcer = require('../04.Math-Enforcer');
const { assert, expect } = require('chai');

describe('Test math enforcer object', () => {
    describe('Test addFive func', () => {
        it('test if parameter is not a number', () => {
            assert.equal(mathEnforcer.addFive('string'), undefined);
        })
        it('test if parameter is a number and return plus 5', () => {
            assert.equal(mathEnforcer.addFive(0), 5);
            assert.equal(mathEnforcer.addFive(5), 10);
            assert.equal(mathEnforcer.addFive(-5), 0);
        })
        it('test if parameter is a float num', () => {
            assert.equal(mathEnforcer.addFive(1.11), 6.11);
            assert.equal(mathEnforcer.addFive(1.1), 6.1);
            assert.equal(mathEnforcer.addFive(-1.1), 3.9);
            assert.closeTo(mathEnforcer.addFive(-1.1), 3.89, 0.01);
        })
    })
    describe('Test subtractTen func', () => {
        it('parameter is not a number', () => {
            assert.equal(mathEnforcer.subtractTen('string'), undefined);
        })
        it('parameter is a number and return minus 10', () => {
            assert.equal(mathEnforcer.subtractTen(0), -10);
            assert.equal(mathEnforcer.subtractTen(5), -5);
            assert.equal(mathEnforcer.subtractTen(-5), -15);
        })
        it('parameter is a  float number', () => {
            assert.equal(mathEnforcer.subtractTen(1.1), -8.9);
            assert.equal(mathEnforcer.subtractTen(1.11), -8.89);
            assert.equal(mathEnforcer.subtractTen(-1.1), -11.1);
        })
    })
    describe('Test sum func', () => {
        it('parameters are not a number', () => {
            assert.equal(mathEnforcer.sum('string', 'string'), undefined);
        })
        it('parameter is a number and second is not', () => {
            assert.equal(mathEnforcer.sum(5, 'string'), undefined);
            assert.equal(mathEnforcer.sum('string', 5), undefined);
        })
        it('parameter is a floating number', () => {
            assert.equal(mathEnforcer.sum(1.1, 1.11), 2.21);

        })
        it('return correct result', () => {

            assert.equal(mathEnforcer.sum(5, 10), 15);

        })
    })
});