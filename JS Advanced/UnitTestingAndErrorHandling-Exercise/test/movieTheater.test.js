let {assert} = require("chai");
let {movieTheater} = require("../../Exercise-On-Exams/JSAdvancedRetakeExam-10Aug2022/03.MovieTheater/03. Movie Theater _Resources");

describe("Test movieTheater", ()=>{
    describe("Test ageRestrictions (movieRating)", ()=> {
        it("Should return 'All ages admitted to watch the movie' with argument 'G'", ()=>{
            assert.equal(movieTheater.ageRestrictions("G"),"All ages admitted to watch the movie");
        });   
        
        it("Should return 'Parental guidance suggested! Some material may not be suitable for pre-teenagers' with argument 'PG'", ()=>{
            assert.equal(movieTheater.ageRestrictions("PG"),"Parental guidance suggested! Some material may not be suitable for pre-teenagers");
        });

        it("Should return 'Restricted! Under 17 requires accompanying parent or adult guardian' with argument 'R'", ()=>{
            assert.equal(movieTheater.ageRestrictions("R"),"Restricted! Under 17 requires accompanying parent or adult guardian");
        });

        it("Should return 'No one under 17 admitted to watch the movie' with argument 'NC-17'", ()=>{
            assert.equal(movieTheater.ageRestrictions("NC-17"),"No one under 17 admitted to watch the movie");
        });

        it("Should return 'There are no age restrictions for this movie' with any other string argument e.g. 'Pesho'", ()=>{
            assert.equal(movieTheater.ageRestrictions("Pesho"),"There are no age restrictions for this movie");
        });

       
    });


    describe("Test moneySpent (tickets, food, drinks)", ()=>{
       

        it("Correct args + discount (5,[Nachos, Popcorn],[Soda, Water])", ()=>{
            assert.equal(movieTheater.moneySpent(5,["Nachos", "Popcorn"],["Soda", "Water"]),
            "The total cost for the purchase with applied discount is 71.60");
        });

        it("Correct args no discount (2,[Nachos, Popcorn],[Soda, Water])", ()=>{
            assert.equal(movieTheater.moneySpent(2,["Nachos", "Popcorn"],["Soda", "Water"]),
            "The total cost for the purchase is 44.50");
        });

        it("Correct args no discount edge case one arg per array (1,[Nachos],[Soda])", ()=>{
            assert.equal(movieTheater.moneySpent(1,["Nachos"],["Soda"]),
            "The total cost for the purchase is 23.50");
        });

        it("Correct args no discount edge case empty arr food (1,[],[Soda])", ()=>{
           assert.equal(movieTheater.moneySpent(1,[],["Soda"]),
            "The total cost for the purchase is 17.50");
        });

        it("Correct args no discount edge case empty arr drinks (1,[Popcorn],[])", ()=>{
            assert.equal(movieTheater.moneySpent(1,["Popcorn"],[]),
             "The total cost for the purchase is 19.50");
         });

         it("Correct args no discount edge case empty arrs (1,[],[])", ()=>{
            assert.equal(movieTheater.moneySpent(1,[],[]),
             "The total cost for the purchase is 15.00");
         });

         it("Correct args no discount edge case empty arrs (0,[],[])", ()=>{
            assert.equal(movieTheater.moneySpent(0,[],[]),
             "The total cost for the purchase is 0.00");
         });

         it("Incorrect args no discount edge case -1 tickets (-1,[],[])", ()=>{
            assert.equal(movieTheater.moneySpent(-1,[],[]),
             "The total cost for the purchase is -15.00");
         });

         it("throws error when (1,{'Nachos'},['Water'])", ()=>{
            assert.throws(()=>movieTheater.moneySpent(1,{nachos:"Nachos"},['Water']),"Invalid input");
         });

         it("throws error when (1,['Nachos'],{'Water'})", ()=>{
            assert.throws(()=>movieTheater.moneySpent(1,["Nachos"],{water:'Water'}),"Invalid input");
         });

         it("throws error when ('1',['Nachos'],['Water'])", ()=>{
            assert.throws(()=>movieTheater.moneySpent("1",["Nachos"],["Water"]),"Invalid input");
         });
    });


    describe("Test reservation (rowsArray, neededSeatsCount)", ()=>{
        const rowsArray = [
            { rowNumber: 1, freeSeats: 7 }, 
            { rowNumber: 2, freeSeats: 5 }, 
            { rowNumber: 5, freeSeats: 8 }
        ];

        it("get correct answer with  common input", ()=>{
            assert.equal(movieTheater.reservation(rowsArray,6),"5");
        });

        it("throws error when no array", ()=>{
            assert.throws(()=>movieTheater.reservation(5,6),"Invalid input");
        });
        
        it("throws error when number ", ()=>{
            assert.throws(()=>movieTheater.reservation(rowsArray,"6"),"Invalid input");
        });
    });
});