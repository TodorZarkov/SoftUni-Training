'use strict';
function solve(arr) {
    let arrAsc = arr.sort((a, b) => a - b);
    let arrDes = arr.sort((a, b) => b - a);
    let result = [];
    for (let i = 0; i < arr.length / 2; i++) {
        result.push(arrAsc[i]);
        result.push(arrDes[i]);

    }
    return result;
}