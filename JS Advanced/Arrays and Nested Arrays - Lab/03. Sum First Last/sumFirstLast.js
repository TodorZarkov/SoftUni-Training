'use strict';
function solve(arr){
    let firstElement = Number(arr[0]);
    let lastElement = Number(arr[arr.length-1])
    //console.log(firstElement + lastElement);
    return firstElement + lastElement;
}
solve(['20', '30', '40']);