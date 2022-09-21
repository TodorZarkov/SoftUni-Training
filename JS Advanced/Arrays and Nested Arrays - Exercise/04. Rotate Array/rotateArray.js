'use strict';
function solve(arr, rotations) {
    if (rotations > arr.length) {
        rotations = rotations % arr.length;
    }
    for (let i = 0; i < rotations; i++) {
        arr.unshift(arr.pop());
    }
    console.log(arr.join(' '));
}
solve(['Banana',
    'Orange',
    'Coconut',
    'Apple'],
    15);