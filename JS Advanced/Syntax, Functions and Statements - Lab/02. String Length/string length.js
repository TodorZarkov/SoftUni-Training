'use strict';

function calcStrings(...params){
    let lenSum = 0;
    for (let i = 0; i < params.length; i++) {
        lenSum += params[i].length;
    }
    let lenAverage = Math.round(lenSum/params.length);
    console.log(lenSum);
    console.log(lenAverage);
}
calcStrings('pasta', '5', '22.3');
