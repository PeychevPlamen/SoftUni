const rgbToHexColor = require('./rgb-to-hex');
const { assert } = require('chai');

describe('Rgb to Hex Color', () => {

    it('test if red value is > 255', () => {
        
        let expectedResult = undefined;

        assert.equal(rgbToHexColor(256, 123, 23), expectedResult);
    });
    it('test if red value is < 0', () => {
       
        let expectedResult = undefined;

        assert.equal(rgbToHexColor(-15, 123, 23), expectedResult);
    });
    it('test if red value is not a number', () => {
      
        let expectedResult = undefined;

        assert.equal(rgbToHexColor('gosho', 123, 23), expectedResult);
    });
    it('test if green value is not a number', () => {
        
        let expectedResult = undefined;

        assert.equal(rgbToHexColor(111, 'pesho', 23), expectedResult);
    });
    it('test if green value is < 0', () => {
       
        let expectedResult = undefined;

        assert.equal(rgbToHexColor(111, -15, 23), expectedResult);
    });
    it('test if green value is > 255', () => {
        let input = (111, 300, 23);
        let expectedResult = undefined;

        assert.equal(rgbToHexColor(input), expectedResult);
    });
    it('test if blue value is > 255', () => {
        
        let expectedResult = undefined;

        assert.equal(rgbToHexColor(111, 255, 299), expectedResult);
    });
    it('test if blue value is < 0', () => {
        
        let expectedResult = undefined;

        assert.equal(rgbToHexColor(111, 255, -5), expectedResult);
    });
    it('test if blue value is not a number', () => {
        
        let expectedResult = undefined;

        assert.equal(rgbToHexColor(111, 255, 'gosho'), expectedResult);
    });
    it('test if it is correct color in hex', () => {
        let expectedResult = '#FFFFFF';

        assert.equal(rgbToHexColor(255, 255, 255), expectedResult);
    });
    it('test if it is white color in hex', () => {
        let expectedResult = '#000000';

        assert.equal(rgbToHexColor(0, 0, 0), expectedResult);
    });
    it('test if return correct color in hex', () => {
        let expectedResult = '#9E9CFF';

        assert.equal(rgbToHexColor(158, 156, 255), expectedResult);
    });
});
