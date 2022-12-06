let { assert } = require('chai');
let { carService } = require("../03. Car Service_Resources");


describe("test carService object", () => {
    describe("test isItExpensive(issue)", () => {
        it("correct with Engine and Transmission", () => {
            assert.equal(carService.isItExpensive("Engine"), "The issue with the car is more severe and it will cost more money");
            assert.equal(carService.isItExpensive("Transmission"), "The issue with the car is more severe and it will cost more money");
        });
        it("correct with any other string input", () => {
            assert.equal(carService.isItExpensive("Gumi"), "The overall price will be a bit cheaper");
        });
        it("correct with empty string", () => {
            assert.equal(carService.isItExpensive(""), "The overall price will be a bit cheaper");
        });
    });

    describe("test discount (numberOfParts, totalPrice)", () => {
        it('correct with les than 2', () => {
            assert.equal(carService.discount(1, 50), "You cannot apply a discount")
        });
        it('correct with between (2-7]', () => {
            assert.equal(carService.discount(4, 50), "Discount applied! You saved 7.5$")
        });
        it('correct with above 7', () => {
            assert.equal(carService.discount(9, 50), "Discount applied! You saved 15$")
        });
        it('correct edge with 2', () => {
            assert.equal(carService.discount(2, 50), "You cannot apply a discount")
        });
        it('correct edge with 3', () => {
            assert.equal(carService.discount(3, 50), "Discount applied! You saved 7.5$")
        });
        it('correct edge with 7', () => {
            assert.equal(carService.discount(7, 50), "Discount applied! You saved 7.5$")
        });
        it('correct edge with 8', () => {
            assert.equal(carService.discount(8, 50), "Discount applied! You saved 15$")
        });
        it('correct edge with 7.5', () => {
            assert.equal(carService.discount(8, 50), "Discount applied! You saved 15$")
        });

        it('incorrect with string parts "10"', () => {
            assert.throws(() => { carService.discount("10", 50) }, "Invalid input");
        });
        it('incorrect with string price "50"', () => {
            assert.throws(() => { carService.discount(10, "50") }, "Invalid input");
        });
        it('incorrect with both strings', () => {
            assert.throws(() => { carService.discount("10", "50") }, "Invalid input");
        });
    });

    describe("test partsToBuy (partsCatalog, neededParts)", () => {
        const partsCatalog = [
            { part: "blowoff valve", price: 145 },
            { part: "coil springs", price: 230 },
            { part: "injectors", price: 230 }];

        const neededParts = ["blowoff valve", "injectors"];
        const overneededParts = ["blowoff valve", "injectors", "tyres"];

            it("correct with all parts available in catalog", ()=>{
                assert.equal(carService.partsToBuy(partsCatalog,neededParts), 375);
            });
            it("correct with part unavailable in catalog", ()=>{
                assert.equal(carService.partsToBuy(partsCatalog,overneededParts), 375);
            });
            it("correct with empty catalog", ()=>{
                assert.equal(carService.partsToBuy([],overneededParts), 0);
            });
            it("correct edge with empty catalog and parts", ()=>{
                assert.equal(carService.partsToBuy([],[]), 0);
            });
            it("correct edge with empty parts", ()=>{
                assert.equal(carService.partsToBuy(partsCatalog,[]), 0);
            });
            it("incorrect with object catalog", ()=>{
                assert.throws(()=>{carService.partsToBuy({ part: "blowoff valve", price: 145 },neededParts)},
                "Invalid input");
            });
            it("incorrect with object parts", ()=>{
                assert.throws(()=>{carService.partsToBuy(partsCatalog,{ part: "injectors" })},
                "Invalid input");
            });

    })
});


