'use strict';
function solve(arr) {
    arr.map(Number);
    let bigIndex = 0;
    let result = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[bigIndex] <= arr[i]) {
            result.push(arr[i]);
            bigIndex = i;
        }
    }
    //console.log(result);
    return result.map(Number);
}
solve([20, 
    3, 
    2, 
    20]);