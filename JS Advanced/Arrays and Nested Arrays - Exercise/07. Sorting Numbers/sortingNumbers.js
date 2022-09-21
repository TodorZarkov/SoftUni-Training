'use strict';
function solve(arr) {
    let arrAsc = [];
    let arrDes = [];

    arrAsc = arr.sort((a, b) => a - b).map(x => x);
    arrDes = arr.reverse().map(x => x);
    let result = [];
    for (let i = 0; i < arr.length / 2; i++) {
        result.push(arrAsc[i]);
        if (result.length < arr.length)
            result.push(arrDes[i]);

    }
    //console.log(result);
    return result;
}
solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56, 20]);