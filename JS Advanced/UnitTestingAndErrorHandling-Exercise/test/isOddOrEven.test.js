let { assert } = require('chai');
let { isOddOrEven } = require('../02.EvenOrOdd/evenOrOdd');

describe("isOddOrEven functionality",()=>{
    describe('isOddOrEven cases with incorrect arguments', () => {
        it('Result Should Be Undefined With an array argument', () => {
            assert.equal(isOddOrEven([]), undefined);
        });

        it('Result Should Be Undefined With an empty object argument', () => {
            assert.equal(isOddOrEven({}), undefined);
        });

        it('Result Should Be Undefined With an object argument', () => {
            assert.equal(isOddOrEven({ name: 'gosho' }), undefined);
        });

        it('Result Should Be Undefined With bool argument', () => {
            assert.equal(isOddOrEven(true), undefined);
        });
        it('Result Should Be Undefined With number argument', () => {
            assert.equal(isOddOrEven(1), undefined);
        }); 
    });


    describe("isOddOrEven cases with correct arguments",()=>{
        it('Should return odd with string Pesho',()=>{
            assert.equal(isOddOrEven('Pesho'),'odd');
        });

        it('Should return odd with string Gosho',()=>{
            assert.equal(isOddOrEven('Gosho'),'odd');
        });

        it('Should return even with string love',()=>{
            assert.equal(isOddOrEven('love'),'even');
        });

        it('Should return even with string machines',()=>{
            assert.equal(isOddOrEven('machines'),'even'); 
        });
    });

});

