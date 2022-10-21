let {assert} = require('chai')
let {lookupChar} = require('../03.CharLookup/charLookup');

describe('lookupChar with incorrect first argument',()=>{
    it('Should return undefined with NUMBER 56454 first argument',()=>{
        assert.equal(lookupChar(56454,0),undefined);
    });
    it('Should return undefined with empty object first argument',()=>{
        assert.equal(lookupChar({},0),undefined);
    });
    it('Should return undefined with empty array first argument',()=>{
        assert.equal(lookupChar([],0),undefined);
    });
    it('Should return undefined with ["gosho"] array first argument',()=>{
        assert.equal(lookupChar(['gosho'],0),undefined);
    });

});

describe('lookupChar with incorrect second argument',()=>{
    it('Should return undefined with -1 as a second argument',()=>{
        assert.equal(lookupChar('56454',-1),"Incorrect index");
    });
    it('Should return Incorrect index with 6 as a second argument over "pesho" as second argument',()=>{
        assert.equal(lookupChar('pesho',6),'Incorrect index');
    });
    it('Should return undefined with 2.2 as a second argument',()=>{
        assert.equal(lookupChar('pesho',2.2),undefined);
    });
});

describe('lookupChar with correct arguments',()=>{
    it('should return a with first argument Pontiac, and second arg.  5',()=>{
        assert.equal(lookupChar('Pontiac',5),'a');
    });
});