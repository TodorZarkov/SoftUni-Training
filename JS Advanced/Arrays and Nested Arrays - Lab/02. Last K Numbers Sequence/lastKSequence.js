'use strict';
function solve(n, k) {
    let arr = new Array(6);
    arr[0] = 1;
    let result = [];
    for (let i = 0; i < n; i++) {
        if(i-k < 0){
            result =arr.slice(0,i+1);
        }else{
            result =arr.slice(i-k,i+1);
        }
        arr[i] = result.reduce((prev,curr)=>prev+curr);
    }
    return arr;

}
solve(8, 2);