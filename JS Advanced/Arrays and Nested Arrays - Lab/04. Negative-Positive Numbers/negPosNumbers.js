'use strict';
function solve(arr){
    let result = [];
    arr.forEach(element => {
        if (element >= 0) {
            result.push(element);
        }else{
            result.unshift(element);
        }
    });
    result.forEach(res=>console.log(res));
}
solve([3, -2, 0, -1])