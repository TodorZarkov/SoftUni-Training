'use strict'
function solve(arr){
    arr.sort((a,b)=>a-b);
    console.log(`${arr[0]} ${arr[1]}`);
}
solve([3, 0, 10, 4, 7, 3])