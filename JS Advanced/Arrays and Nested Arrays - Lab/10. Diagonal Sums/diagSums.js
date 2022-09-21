'use strict';
function solve(matrix) {
    let mainSum = 0;
    let secSum = 0;
    for (let i = 0; i < matrix.length; i++) {
        mainSum += matrix[i][i];
        secSum += matrix[i][matrix.length - 1 - i];
    }
    console.log(`${mainSum} ${secSum}`);
}
solve([[3, 5, 17],
[-1, 7, 14],
[1, -8, 89]]);