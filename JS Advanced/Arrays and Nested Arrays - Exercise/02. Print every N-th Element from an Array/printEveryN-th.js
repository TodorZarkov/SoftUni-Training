'use strict';
function solve(arr, n) {
    let result = [];
    for (let i = 0; i < arr.length; i += n) {
        result.push(arr[i]);
    }
    //console.log(result);
    return result;
}

solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2);