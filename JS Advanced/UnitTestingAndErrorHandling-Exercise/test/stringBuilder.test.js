
const { assert } = require("chai");
const StringBuilder = require("../../ClassesandAttributes-Exercise/13.StringBuilder/stringBuilder");



describe("Test StringBuilder class", () => {
    const wrongParam = [
        1,
        0,
        -1,
        true,
        false,
        { name: "Jhon" },
        ['stringInArray'],
        undefined,
        null,
        415654354,
        [],
        {}
    ];
    const correctConstrParam = "Pesho";
    const correctConstrInterv = " ,  Pesho Peshov  ,, {}. "
    const correctParam =
        [''
            , ' '
            , '   '
            , 'neshto'
            , ' prepInterv'
            , 'appInterv '
            , '\n'
            , '\t'
            , 'neshto drugo'
            , '5485'
        ];

    let emptySb;
    let noemptySb;
    let sbWithInterval;
    beforeEach(() => {
        emptySb = new StringBuilder();
        noemptySb = new StringBuilder(correctConstrParam);
        sbWithInterval = new StringBuilder(correctConstrInterv);
    });



    describe("Test all methods with wrong input:", () => {

        for (let param of wrongParam) {
            if (param !== undefined) {
                it(`Should throw error when passed non string (${param}) to constructor.`, () => {
                    assert
                        .throws(() => { new StringBuilder(param) }
                            , 'Argument must be a string'
                            , `passed param = ${param}.`);
                });
            }

            it(`Should throw error when passed non string (${param}) to append(string).`, () => {
                assert
                    .throws(() => { emptySb.append(param) }
                        , 'Argument must be a string'
                        , `passed param = ${param}.`);
            });

            it(`Should throw error when passed non string (${param}) to prepend(string).`, () => {
                assert
                    .throws(() => { emptySb.prepend(param) }
                        , 'Argument must be a string'
                        , `passed param = ${param}.`);
            });

            it(`Should throw error when passed non string (${param}) to insertAt(string, startIndex).`, () => {
                assert
                    .throws(() => { emptySb.insertAt(param) }
                        , 'Argument must be a string'
                        , `passed param = ${param}.`);
            });

        }
    });


    describe("Test all with correct arguments:", () => {


        describe(`Test constructor:`, () => {
            it("Should create instance with no argumet", () => {
                assert.instanceOf(new StringBuilder(), StringBuilder, "passed no argument");
            });
            it("Should create instance with one parameter", () => {
                assert.instanceOf(new StringBuilder(correctConstrParam), StringBuilder, `passed one string argument(${correctConstrParam})`);
            });
            it("Should create instance with one parameter check length", () => {
                assert.equal((new StringBuilder(correctConstrParam)).toString().length, correctConstrParam.length);
            });
        });

        describe('test initializing', () => {
            it('initializing properly', () => {
                assert.isArray(noemptySb._stringArray);
                assert.equal(noemptySb._stringArray[0], 'P');
                assert.equal(noemptySb._stringArray.length, 5);
            });
            it('initializing with no parameter returns empty array', () => {
                const c = new StringBuilder();
                assert.equal(0, c._stringArray.length);
            });
        });


        describe(`Test append, prepend and insert wth no empty constructor`, () => {
            for (let param of correctParam) {
                it(`Should append ${param} to ${correctConstrParam}`, () => {
                    noemptySb.append(param);
                    assert.equal(noemptySb.toString(), correctConstrParam + param.toString());
                });


                it(`Should prepend ${param} to ${correctConstrParam}`, () => {
                    noemptySb.prepend(param);
                    assert.equal(noemptySb.toString(), param.toString() + correctConstrParam);
                });


                it(`Should insert ${param} at the start of ${correctConstrParam}`, () => {
                    noemptySb.insertAt(param, 0);
                    assert.equal(noemptySb.toString(), param.toString() + correctConstrParam);
                });


                it(`Should insert ${param} at the end of ${correctConstrParam}`, () => {
                    noemptySb.insertAt(param, correctConstrParam.length);
                    assert.equal(noemptySb.toString(), correctConstrParam + param.toString());
                });


                it(`Should insert ${param} at the mid of ${correctConstrParam}`, () => {
                    noemptySb.insertAt(param, 2);
                    assert.equal(noemptySb.toString(), "Pe" + param.toString() + "sho");
                });

                it(`inserts at negative position`, () => {
                    noemptySb.insertAt(param, -1);
                    assert.equal(noemptySb.toString(), "Pesh" + param.toString() + "o");
                });

                it("Insert consequently", () => {
                    noemptySb.insertAt("a", 2);
                    noemptySb.insertAt("b", 3);
                    assert.equal(noemptySb.toString(), "Peabsho");
                });
            }
        });



        describe(`Test append, prepend and insert with empty constructor.`, () => {
            for (let param of correctParam) {
                it(`Should append ${param} to ${""}`, () => {
                    emptySb.append(param);
                    assert.equal(emptySb.toString(), "" + param.toString());
                });


                it(`Should prepend ${param} to ${""}`, () => {
                    emptySb.prepend(param);
                    assert.equal(emptySb.toString(), param.toString() + "");
                });


                it(`Should insert ${param} at the start of ${""}`, () => {
                    emptySb.insertAt(param, 0);
                    assert.equal(emptySb.toString(), param.toString() + "");
                });


                it(`Should insert ${param} at the end of ${""}`, () => {
                    emptySb.insertAt(param, "".length);
                    assert.equal(emptySb.toString(), "" + param.toString());
                });


                it(`Should insert ${param} at the mid of ${""}`, () => {
                    emptySb.insertAt(param, 2);
                    assert.equal(emptySb.toString(), param.toString());
                });
            }
        });


        describe(`Test remove(startIndex, length)`, () => {
            it(`Should remove the symbol at the first index`, () => {
                noemptySb.remove(0, 1);
                assert.equal(noemptySb.toString(), "esho")
            });

            it(`Should remove the symbol at the end index`, () => {
                noemptySb.remove(correctConstrParam.length - 1, 1);
                assert.equal(noemptySb.toString(), "Pesh")
            });

            it(`Should remove the 2 symbols at a mid index`, () => {
                noemptySb.remove(2, 2);
                assert.equal(noemptySb.toString(), "Peo")
            });

            it("Should leave the text unchanged when negativ second argument", () => {
                noemptySb.remove(2, -5);
                assert.equal(noemptySb.toString(), correctConstrParam);
            })
        });

        describe(`Test toString()`, () => {
            it(`Should return the initial string unchanged.`, () => {

                assert.equal(noemptySb.toString(), correctConstrParam)
            });

            it(`Should return empty string with no argument constructor.`, () => {

                assert.equal(emptySb.toString(), '')
            });
        });


        describe(`Test append, prepend and insert with empty constructor.`, () => {
            for (let param of correctParam) {
                it(`Should append ${param} to ${correctConstrInterv}`, () => {
                    sbWithInterval.append(param);
                    assert.equal(sbWithInterval.toString(), correctConstrInterv + param.toString());
                });


                it(`Should prepend ${param} to ${correctConstrInterv}`, () => {
                    sbWithInterval.prepend(param);
                    assert.equal(sbWithInterval.toString(), param.toString() + correctConstrInterv);
                });


                it(`Should insert ${param} at the start of ${correctConstrInterv}`, () => {
                    sbWithInterval.insertAt(param, 0);
                    assert.equal(sbWithInterval.toString(), param.toString() + correctConstrInterv);
                });


                it(`Should insert ${param} at the end of ${correctConstrInterv}`, () => {
                    sbWithInterval.insertAt(param, correctConstrInterv.length);
                    assert.equal(sbWithInterval.toString(), correctConstrInterv + param.toString());
                });


                it(`Should insert ${param} at the mid of ${correctConstrInterv}`, () => {
                    sbWithInterval.insertAt(param, 2);
                    assert.equal(sbWithInterval.toString(), ` ,${param}  Pesho Peshov  ,, {}. `);
                });
            }
        });
    });

    describe('test _vrfyParam method', () => {
        it('_vrfyParam with non-string input throws', () => {
            assert.throws(() => StringBuilder._vrfyParam(2));
        });
        it('_vrfyParam with string input works', () => {
            assert.doesNotThrow(() => StringBuilder._vrfyParam('ddd'));
        });
    });

    describe('test toString method', () => {
        it('toString returns valid string output', () => {
            assert.equal('Pesho', noemptySb.toString());
            assert.equal(noemptySb._stringArray.join(''), noemptySb.toString());
            assert.equal('', new StringBuilder().toString());
        });
    });

    describe('test insertAt method', () => {
        it('inserting valid string input works', () => {
            noemptySb = new StringBuilder("aaa");
            noemptySb.insertAt('bb', 0);
            noemptySb.insertAt('h', 1);
            assert.equal('bhbaaa', noemptySb.toString());
        });
        // it('inserting at negative number index works',()=>{
        //     noemptySb = new StringBuilder("aaa");
        //     noemptySb.insertAt('b',-1);
        //     assert.equal('aaba',noemptySb.toString());
        // });
        // it('inserting non-string input throws', () => {
        //     noemptySb = new StringBuilder("aaa");
        //     assert.throws(() => noemptySb.insertAt(22, 2));
        // });
    });

});
