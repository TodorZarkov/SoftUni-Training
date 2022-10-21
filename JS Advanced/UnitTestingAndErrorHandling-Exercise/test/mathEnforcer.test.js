let { assert } = require('chai');
let mathEnforcer = require('../04.MathEnforcer/mathEnforcer');

describe('Test mathEnforcer functionality', () => {
    describe('addFive function cases', () => {
        it('should return undefined with NaN argument "five"', () => {
            assert.equal(mathEnforcer.addFive('five'), undefined);
        });
        it('should return 10 with argument 5', () => {
            assert.closeTo(mathEnforcer.addFive(5), 10, 0.01);
        });
        it('should return close to 10.0255 with argument 5.0255', () => {
            assert.closeTo(mathEnforcer.addFive(5.0255), 10.0255, 0.01);
        });
        it('should return -5 with argument -10', () => {
            assert.closeTo(mathEnforcer.addFive(-10), -5, 0.01);
        });
    });

    describe('subtractTen function cases', () => {
        it('should return undefined with NaN argument "five"', () => {
            assert.equal(mathEnforcer.subtractTen('five'), undefined);
        });
        it('should return 5 with argument 15', () => {
            assert.closeTo(mathEnforcer.subtractTen(15), 5, 0.01);
        });
        it('should return close to 5.558452 with argument 15.558452', () => {
            assert.closeTo(mathEnforcer.subtractTen(15.558452), 5.558452, 0.01);
        });
        it('should return -15 with argument -5', () => {
            assert.closeTo(mathEnforcer.subtractTen(-5), -15, 0.01);
        });
    });

    describe('sum function cases', () => {
        it('should return undefined if andy args are NaN', () => {
            assert.equal(mathEnforcer.sum('pesho', 1), undefined);
            assert.equal(mathEnforcer.sum(1, 'pesho'), undefined);
            assert.equal(mathEnforcer.sum('pesho', 'gosho'), undefined);
            assert.equal(mathEnforcer.sum({}, 1), undefined);
            assert.equal(mathEnforcer.sum(1, {}), undefined);
            assert.equal(mathEnforcer.sum([], 1), undefined);
            assert.equal(mathEnforcer.sum(1, []), undefined);
            assert.equal(mathEnforcer.sum(['5'], 1), undefined);
            assert.equal(mathEnforcer.sum(1, ['5']), undefined);
        });
        it('should return close to 2.258741 on arguments 1 and 1.258741', () => {
            assert.closeTo(mathEnforcer.sum(1, 1.258741), 2.258741, 0.01);
        });
        it('should return close to 2 on arguments 4 and -2', () => {
            assert.closeTo(mathEnforcer.sum(4, -2), 2, 0.01);
        });
        it('should return close to -6 on arguments -4 and -2', () => {
            assert.closeTo(mathEnforcer.sum(-4, -2), -6, 0.01);
        });
        it('should return close to -6.86501 on arguments -4 and -2.86501', () => {
            assert.closeTo(mathEnforcer.sum(-4, -2.86501), -6.86501, 0.01);
        });
        it('should return close to -6.97501 on arguments -4.11 and -2.86501', () => {
            assert.closeTo(mathEnforcer.sum(-4.11, -2.86501), -6.97501, 0.01);
        });
    })
});
