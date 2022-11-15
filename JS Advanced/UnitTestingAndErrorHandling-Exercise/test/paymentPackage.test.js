const { assert } = require('chai');
const PaymentPackage = require('../../ClassesandAttributes-Exercise/12.Payment-Package/paimentPackage');

describe("Testing PaymentPackage class", () => {

    const nameWrongParams = [1, -1, 0, "", null, undefined, false, true, { firstName: "John" }, {}, ["Doe"]];
    const valueWrongParams = ["256", - 1, "", null, undefined, false, true, { firstName: "John" }, {}, ["Doe"]];
    const vatWrongParams = ["256", - 1, "", null, undefined, false, true, { firstName: "John" }, {}, ["Doe"]];
    const activeWrongParams = [1, 0, "256", - 1, "", null, undefined, { firstName: "John" }, {}, ["Doe"]];
    const nameRightParams = ["somePakage", '125'];
    const valueRightParams = [0, 5];
    const vatRightParams = [0, 5];
    const activeRightParams = [true, false];


    describe("Creating instance of PaymentPackage with wrong values:", () => {
        it("Should throw error with zero parameters", () => {
            let expErrMsg = "Error: Name must be a non-empty string";
            let actualErrMsg = "";
            try {
                new PaymentPackage();
            } catch (error) {
                actualErrMsg = error;
            }
            assert.equal(actualErrMsg, expErrMsg);
        });

        it("Should throw error with one right parameter.", () => {
            let expErrMsg = "Error: Value must be a non-negative number";
            for (let param of nameRightParams) {
                let actualErrMsg = "";
                try {
                    new PaymentPackage(param);
                } catch (error) {
                    actualErrMsg = error;
                }
                assert.equal(actualErrMsg, expErrMsg, `firstParam: ${param}\nsecondParam:`);
            }

        });

        it("Should throw error with one wrong parameter.", () => {
            let expErrMsg = "Error: Name must be a non-empty string";
            for (let param of nameWrongParams) {
                let actualErrMsg = "";
                try {
                    new PaymentPackage(param);
                } catch (error) {
                    actualErrMsg = error;
                }
                assert.equal(actualErrMsg, expErrMsg, `firstParam: ${param}, secondParam:`);
            }

        });

        it("Should throw error with first string and second wrong parameter.", () => {
            let expErrMsg = "Error: Value must be a non-negative number";
            for (let fParam of nameRightParams) {
                for (let sParam of valueWrongParams) {
                    let actualErrMsg = "";
                    try {
                        new PaymentPackage(fParam, sParam);
                    } catch (error) {
                        actualErrMsg = error;
                    }
                    assert.equal(actualErrMsg, expErrMsg, `firstParam: ${fParam}, secondParam: ${sParam}`);
                }
            }

        });

        it("Should throw error with first wrong and second non negative number parameter.", () => {
            let expErrMsg = "Error: Name must be a non-empty string";
            for (let fParam of nameWrongParams) {
                for (let sParam of valueRightParams) {
                    let actualErrMsg = "";
                    try {
                        new PaymentPackage(fParam, sParam);
                    } catch (error) {
                        actualErrMsg = error;
                    }
                    assert.equal(actualErrMsg, expErrMsg, `firstParam: ${fParam}, secondParam: ${sParam}`);
                }
            }

        });


    });

    describe("Asigning wrong values to name, value, VAT, active:", () => {
        it("Should throw error when empty string or not string is assigned to name.", () => {
            let expErrMsg = "Error: Name must be a non-empty string";
            for (let param of nameWrongParams) {
                let actualErrMsg = "";
                try {
                    let pp = new PaymentPackage(nameRightParams[0], valueRightParams[0]);
                    pp.name = param;
                } catch (error) {
                    actualErrMsg = error;
                }
                assert.equal(actualErrMsg, expErrMsg, `name = ${param}`);
            }
        });

        it("Should throw error when NaN or negative is assigned to value.", () => {
            let expErrMsg = "Error: Value must be a non-negative number";
            for (let param of valueWrongParams) {
                let actualErrMsg = "";
                try {
                    let pp = new PaymentPackage(nameRightParams[0], valueRightParams[0]);
                    pp.value = param;
                } catch (error) {
                    actualErrMsg = error;
                }
                assert.equal(actualErrMsg, expErrMsg, `value = ${param}`);
            }
        });

        it("Should throw error when NaN or negative is assigned to VAT.", () => {
            let expErrMsg = "Error: VAT must be a non-negative number";
            for (let param of vatWrongParams) {
                let actualErrMsg = "";
                try {
                    let pp = new PaymentPackage(nameRightParams[0], valueRightParams[0]);
                    pp.VAT = param;
                } catch (error) {
                    actualErrMsg = error;
                }
                assert.equal(actualErrMsg, expErrMsg, `VAT = ${param}`);
            }
        });

        it("Should throw error when not boolean is assigned to active.", () => {
            let expErrMsg = "Error: Active status must be a boolean";
            for (let param of activeWrongParams) {
                let actualErrMsg = "";
                try {
                    let pp = new PaymentPackage(nameRightParams[0], valueRightParams[0]);
                    pp.active = param;
                } catch (error) {
                    actualErrMsg = error;
                }
                assert.equal(actualErrMsg, expErrMsg, `active = ${param}`);
            }
        });
    });

    describe("Asserting with correct parameters and correct assignings.", () => {
        it("Should create new instance when first param is string, second param is number", () => {
            let fParam = nameRightParams[0];
            let sParam = valueRightParams[0];
            let pp;
            try {
                pp = new PaymentPackage(fParam, sParam);
            } catch (error) {
                assert.equal(error, "", `Expected no error when assinged with (${fParam},${sParam})`);
            } finally {
                assert.equal(pp.name, fParam);
                assert.equal(pp.value, sParam);
            }
        });

        it("Should pass correctly the values of: name, value, VAT, active.", () => {
            let name = nameRightParams[0];
            let value = valueRightParams[0];
            let name1 = nameRightParams[1];
            let value1 = valueRightParams[1];
            let vat = vatRightParams[0];
            let active = activeRightParams[0];
            let active1 = activeRightParams[1];
            let pp;
            try {
                pp = new PaymentPackage(name, value);
                pp.name = name1;
                pp.value = value1;
                pp.VAT = vat;
                pp.active = active;
                pp.active = active1
            } catch (error) {
                assert.equal(error, "",
                    `Expected no exception error when assinged with (${fParam},${sParam});
            Assingments:
             name=${name1},
             value=${value1},
             VAT=${vat},
             active=${active},
             active=${active1}; 
             Error thrown:${error}`);
            } finally {
                assert.equal(pp.name, name1, `name=${name1}`);
                assert.equal(pp.value, value1, `value=${value1}`);
                assert.equal(pp.VAT, vat, `VAT=${vat}`);
                assert.equal(pp.active, active1, `active=${active1}`);
            }
        });

        it("Asserting toString()", () => {


            let name = nameRightParams[0];
            let value = valueRightParams[0];
            let name1 = nameRightParams[1];
            let value1 = valueRightParams[1];
            let vat = vatRightParams[0];
            let active = activeRightParams[0];
            let active1 = activeRightParams[1];
            let pp;

            const output = [
                `Package: ${name1}` + (active1 === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${value1}`,
                `- Value (VAT ${vat}%): ${value1 * (1 + vat / 100)}`
            ];

            let print = output.join('\n');

            try {
                pp = new PaymentPackage(name, value);
                pp.name = name1;
                pp.value = value1;
                pp.VAT = vat;
                pp.active = active;
                pp.active = active1
            } catch (error) {
                assert.equal(error, "",
                    `Expected no exception error when assinged with (${fParam},${sParam});
            Assingments:
             name=${name1},
             value=${value1},
             VAT=${vat},
             active=${active},
             active=${active1}; 
             Error thrown:${error}`);
            } finally {
                assert.equal(pp.toString(), print);
            }
        });

    });

    describe("Asserting inner params with correct parameters and correct assignings.",()=>{
        beforeEach(()=>{
            pPackage = new PaymentPackage("tosho",55);
        });

        it("assert correct _name",()=>{
            assert.equal(pPackage._name,"tosho");
        });

        it("assert correct _value",()=>{
            assert.equal(pPackage._value,55);
        });

        it("assert correct _VAT",()=>{
            assert.equal(pPackage._VAT,20);
        });

        it("assert correct _active",()=>{
            assert.equal(pPackage._active,true);
        });

        it("asserts toString()",()=>{
            const output = [
                `Package: ${pPackage._name}`,
                `- Value (excl. VAT): ${pPackage._value}`,
                `- Value (VAT ${pPackage._VAT}%): ${pPackage._value * (1 + pPackage._VAT / 100)}`
              ];
              let print = output.join('\n');

              assert.equal(pPackage.toString(),print);
             
        });
    })
});
