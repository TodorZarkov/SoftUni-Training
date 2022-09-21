'use strict';
function solve(matrix) {
    let rowSum = matrix[0].reduce((prev, curr) => prev += curr);
    let result = true;
    for (let i = 1; i < matrix.length; i++) {
        if (rowSum !== matrix[i].reduce((prev, curr) => prev += curr))
            return false;
    }

    for (let i = 0; i < matrix.length; i++) {
        let tempSum = 0;
        for (let j = 0; j < matrix.length; j++) {
            tempSum += matrix[j][i];
        }
        if (tempSum !== rowSum)
            return false;
    }
    //console.log(result);
    return result;
}
solve([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]);