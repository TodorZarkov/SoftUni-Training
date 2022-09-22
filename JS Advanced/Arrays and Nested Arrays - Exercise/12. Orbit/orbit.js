'use strict';
function solve(input) {//[width, height, x, y]
    let width = input[0];
    let height = input[1];
    let col = input[3];
    let row = input[2];

    let len = Math.max(height, width);
    let matrix = new Array(len);
    for (let row = 0; row < matrix.length; row++) {
        matrix[row] = new Array(len);
    }
    let matrixCols = new Array(len);
    for (let row = 0; row < matrixCols.length; row++) {
        matrixCols[row] = new Array(len);
    }


    for (let i = 0; i < len; i++) {
        for (let j = 0; j < len; j++) {
            matrix[i][j] = Math.abs(row - i) + 1;
        }
    }

    for (let i = 0; i < len; i++) {
        for (let j = 0; j < len; j++) {
            matrixCols[j][i] = Math.abs(col - i) + 1;
        }
    }
    transpMerge(matrix, matrixCols);
    printState(matrix, height, width);

    function transpMerge(matrix, secMatrix) {
        for (let i = 0; i < matrix.length; i++) {
            for (let j = 0; j < matrix.length; j++) {
                if (matrix[i][j] < secMatrix[i][j]) {
                    matrix[i][j] = secMatrix[i][j];
                }
            }

        }
    }

    function printState(matrix, height, width) {
        for (let i = 0; i < height; i++) {
            let line = '';
            for (let j = 0; j < width; j++) {
                line += `${matrix[i][j]} `;
            }
            console.log(line.trimEnd());
        }
    }

}

solve([5, 4, 1, 2]);