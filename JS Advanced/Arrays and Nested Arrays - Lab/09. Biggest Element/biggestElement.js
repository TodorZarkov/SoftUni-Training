'use strict';
function solve(matrix) {
    let arr = [];
    matrix.forEach(element => {
        arr.push(element.sort((a,b)=>b-a)[0]);
    });
    let result = arr.sort((a,b)=>b-a)[0];
    //console.log(result);
    return result;
}
solve([[20, 50, 10],
[8, 33, 145]])