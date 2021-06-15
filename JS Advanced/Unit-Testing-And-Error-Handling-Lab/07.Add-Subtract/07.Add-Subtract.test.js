const createCalculator = require('./07.Add-Subtract');
const { assert, expect } = require('chai');

describe('Calculator tests', () => {
    it('Test add function with positiv number', () => {

        let calculator = createCalculator();
        calculator.add(5);
        let expectedResult = 5;
        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult);
    });
    it('Test add function with negativ number', () => {

        let calculator = createCalculator();
        calculator.add(-5);
        let expectedResult = -5;
        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult);
    });
    it('Test add function with zero', () => {

        let calculator = createCalculator();
        calculator.add(0);
        let expectedResult = 0;
        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult);
    });
    it('Test add function with not a number', () => {

        let calculator = createCalculator();
        calculator.add('1');
        let expectedResult = 1;
        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult);
    });
    it('Test subtract function with positiv number', () => {

        let calculator = createCalculator();
        calculator.subtract(5);
        let expectedResult = -5;
        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult);
    });
    it('Test subtract function with negative number', () => {

        let calculator = createCalculator();
        calculator.subtract(-5);
        let expectedResult = 5;
        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult);
    });
    it('Test subtract function with zero', () => {

        let calculator = createCalculator();
        calculator.subtract(0);
        let expectedResult = 0;
        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult);
    });
    it('Test subtract function with not a number', () => {

        let calculator = createCalculator();
        calculator.subtract([1]);
        let expectedResult = -1;
        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult);
    });
    it('Test subtract function with string', () => {

        let calculator = createCalculator();
        calculator.subtract('5');
        let expectedResult = -5;
        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult);
    });
    it('Test subtract function with string', () => {

        let calculator = createCalculator();
        calculator.subtract('Pesho');
       
        let actualResult = calculator.get();

        assert.isNaN(actualResult);
    });
    it('Test add function with string', () => {

        let calculator = createCalculator();
        calculator.add('Pesho');
       
        let actualResult = calculator.get();

        assert.isNaN(actualResult);
    });
    it('Test function with multiple nums', () => {

        let calculator = createCalculator();
        calculator.add(1);
        calculator.add(-1);
        calculator.subtract(2);

        let expectedResult = -2;
        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult);
    });
    it('Test calc is object', () => {

        let calculator = createCalculator();

        let expectedResult = true;

        assert.isObject(calculator, expectedResult);
    });
    it('Test numbers and string return NaN', () => {

        let calculator = createCalculator();
        calculator.add('pesho');
        calculator.add(7);
        calculator.subtract(-2);

        let actualResult = calculator.get();
        assert.isNaN(actualResult);
    });
    it('Test object has an add key', () => {

        let calculator = createCalculator();

        let expectedResult = 'add';
        let actualResult = Object.keys(calculator);
        assert.include(actualResult, expectedResult);
    });
    it('Test object has an subtract key', () => {

        let calculator = createCalculator();

        let expectedResult = 'subtract';
        let actualResult = Object.keys(calculator);
        assert.include(actualResult, expectedResult);
    });
    it('Test object has an get key', () => {

        let calculator = createCalculator();

        expectedResult = 'get';
        let actualResult = Object.keys(calculator);
        assert.include(actualResult, expectedResult);
    });
    it('Test add and substract multiple numbers and numbers as string should work', () => {
        let calculator = createCalculator();
        calculator.add('1');
        let expectedResult = 1;
        let actualResult = calculator.get();
        expect(actualResult).to.be.equal(expectedResult);
    });
});