'use strict';
function solve(arr){
    arr.sort((a,b)=>a-b);
    let result = arr.slice(Math.floor(arr.length/2),arr.length);
    //console.log(result);
    return result;
}
solve([3, 19, 14, 7, 2, 19, 6]);