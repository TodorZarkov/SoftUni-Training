'use strict';
function solve(arr) {
    arr.sort((a, b) => a.localeCompare(b));
    for (let i = 1; i <= arr.length; i++) {
        console.log(`${i}.${arr[i-1]}`);
    }
}
solve(["John", "Bob", "Christina", "Ema"]);