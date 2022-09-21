'use strict';
function solve(matrix) {
    let result = 0;
    let oddRow = 0;
    for (let i = 0; i < Math.floor(matrix.length / 2); i++) {
        oddRow = 2 * i + 1;
        let oddCol = 0;
        for (let j = 0; j < Math.floor(matrix[i].length / 2); j++) {
            oddCol = 2 * j + 1;
            result += compareNeighbors(matrix,oddRow,oddCol);
        }
    }

    let evenRow = 0;
    for (let k = 0; k < Math.ceil(matrix.length / 2); k++) {
        evenRow = 2 * k;
        let evenCol = 0;
        for (let l = 0; l < Math.ceil(matrix[k].length / 2); l++) {
            evenCol = 2 * l;
            result += compareNeighbors(matrix,evenRow,evenCol);
        }
    }

    //console.log(result);
    return result;

    function compareNeighbors(matrix, row, col) {
        let up = row - 1;
        let down = row + 1;
        let right = col + 1;
        let left = col - 1;
        let result = 0;
        if (up >= 0) {
            if (matrix[row][col] === matrix[up][col]) {
                result++;
            }
        }
        if (down < matrix.length) {
            if (matrix[row][col] === matrix[down][col]) {
                result++;
            }
        }
        if (right < matrix[row].length) {
            if (matrix[row][col] === matrix[row][right]) {
                result++;
            }
        }
        if (left >= 0) {
            if (matrix[row][col] === matrix[row][left]) {
                result++;
            }
        }
        return result;
    }
}

solve([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]);