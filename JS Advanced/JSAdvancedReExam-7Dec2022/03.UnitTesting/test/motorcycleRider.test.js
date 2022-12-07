let {assert} = require("chai");
let {motorcycleRider} = require("../Motorcycle Rider")

describe("Test motorcycleRider object", ()=>{
    describe("Test licenseRestriction(category)", ()=>{
        it("correct 'AM'", ()=>{
            assert.equal(motorcycleRider.licenseRestriction("AM"),
            "Mopeds with a maximum design speed of 45 km. per hour, engine volume is no more than 50 cubic centimeters, and the minimum age is 16.")
        });
        it("correct 'A1'", ()=>{
            assert.equal(motorcycleRider.licenseRestriction("A1"),
            "Motorcycles with engine volume is no more than 125 cubic centimeters, maximum power of 11KW. and the minimum age is 16.")
        });
        it("correct 'A2'", ()=>{
            assert.equal(motorcycleRider.licenseRestriction("A2"),
            "Motorcycles with maximum power of 35KW. and the minimum age is 18.")
        });
        it("correct 'A'", ()=>{
            assert.equal(motorcycleRider.licenseRestriction("A"),
            "No motorcycle restrictions, and the minimum age is 24.")
        });
        it("correct different string e.g 'C'", ()=>{
            assert.throws(()=>motorcycleRider.licenseRestriction("C"),
            "Invalid Information!")
        }); 

        it("incorrect no string e.g 5", ()=>{
            assert.throws(()=>motorcycleRider.licenseRestriction(5),
            "Invalid Information!")
        }); 
        it("incorrect no string e.g ['A']", ()=>{
            assert.throws(()=>motorcycleRider.licenseRestriction(['A']),
            "Invalid Information!")
        }); 
     });


     describe("Test motorcycleShowroom(engineVolume, maximumEngineVolume)", ()=>{
        const engineVolume = ["125", "250", "600", "800"]

        it("correct  less or equal volume", ()=>{
            assert.equal(motorcycleRider.motorcycleShowroom(engineVolume,600),
            "There are 3 available motorcycles matching your criteria!")
        });
        it("correct  greater volume", ()=>{
            assert.equal(motorcycleRider.motorcycleShowroom(engineVolume,100),
            "There are 0 available motorcycles matching your criteria!")
        });
        it("correct edge  less volume", ()=>{
            assert.equal(motorcycleRider.motorcycleShowroom(engineVolume,668),
            "There are 3 available motorcycles matching your criteria!")
        });
        it("correct edge  less and fractional volume", ()=>{
            assert.equal(motorcycleRider.motorcycleShowroom(engineVolume,668.556),
            "There are 3 available motorcycles matching your criteria!")
        });
        it("correct edge  greater and fractional volume", ()=>{
            assert.equal(motorcycleRider.motorcycleShowroom(engineVolume,124.999),
            "There are 0 available motorcycles matching your criteria!")
        });
        it("correct edge  50cc", ()=>{
            assert.equal(motorcycleRider.motorcycleShowroom(engineVolume,50),
            "There are 0 available motorcycles matching your criteria!")
        });


        it("incorrect les than  50cc", ()=>{
            assert.throws(()=>motorcycleRider.motorcycleShowroom(engineVolume,45),
            "Invalid Information!")
        });
        it("incorrect NaN  maximumEngineVolume e.g. '600'", ()=>{
            assert.throws(()=>motorcycleRider.motorcycleShowroom(engineVolume,"600"),
            "Invalid Information!")
        });
        it("incorrect not array engineVolume e.g. {'250':250,'600':600}", ()=>{
            assert.throws(()=>motorcycleRider.motorcycleShowroom({'250':250,'600':600},600),
            "Invalid Information!")
        });
        it("incorrect both incorrect e.g. {'250':250,'600':600},'600'", ()=>{
            assert.throws(()=>motorcycleRider.motorcycleShowroom({'250':250,'600':600},'600'),
            "Invalid Information!")
        });
        it("incorrect empty arr engineVolume", ()=>{
            assert.throws(()=>motorcycleRider.motorcycleShowroom([],600),
            "Invalid Information!")
        });
        it("incorrect edge negative maximumEngineVolume", ()=>{
            assert.throws(()=>motorcycleRider.motorcycleShowroom(engineVolume,-600),
            "Invalid Information!")
        });
     });

     describe("Test otherSpendings(equipment, consumables, discount))", ()=>{
        const equipment = ["helmet", "jacked", "helmet"];
        const consumables = ["engine oil", "engine oil", "oil filter"];

        it("correct mixed and repeating + discount", ()=>{
            assert.equal(motorcycleRider.otherSpendings(equipment,consumables,true),
            "You spend $783.00 for equipment and consumables with 10% discount!")
        });
        it("correct mixed and repeating no discount", ()=>{
            assert.equal(motorcycleRider.otherSpendings(equipment,consumables,false),
            "You spend $870.00 for equipment and consumables!")
        });
        it("correct edge equipment empty arr  no discount", ()=>{
            assert.equal(motorcycleRider.otherSpendings([],consumables,false),
            "You spend $170.00 for equipment and consumables!")
        });
        it("correct edge consumables empty arr  no discount", ()=>{
            assert.equal(motorcycleRider.otherSpendings(equipment,[],false),
            "You spend $700.00 for equipment and consumables!")
        });


        it("incorrect mixed and repeating NO boolean discount e.g. 0", ()=>{
            assert.throws(()=>motorcycleRider.otherSpendings(equipment,consumables,0),
            "Invalid Information!")
        });
        it('incorrect equipment no arr e.g. {"helmet":"helmet", "jacked":"jacked"}', ()=>{
            assert.throws(()=>motorcycleRider.otherSpendings({"helmet":"helmet", "jacked":"jacked"},consumables,true),
            "Invalid Information!")
        });
        it('incorrect consumables no arr e.g. {}', ()=>{
            assert.throws(()=>motorcycleRider.otherSpendings(equipment,{},true),
            "Invalid Information!")
        });
     });
    
});