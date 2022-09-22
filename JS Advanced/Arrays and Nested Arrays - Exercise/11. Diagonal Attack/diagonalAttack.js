'use strict';
function solve(semiMatrix) {
    let matrix = parseToMatrix(semiMatrix);
    let sum = sumMainDiagonal(matrix);
    if (sum === sumSecDiagonal(matrix)) {
        fillExceptDiagonals(matrix,sum);
        printState(matrix);
    } else {
        printState(matrix);
    }

    function fillExceptDiagonals(matrix, filler) {
        for (let i = 0; i < matrix.length; i++) {
            for (let j = 0; j < matrix.length; j++) {
                if (i === j || i + j === matrix.length - 1)
                    continue;
                matrix[i][j] = filler;
            }
        }
    }

    function sumSecDiagonal(matrix) {
        let result = 0;
        let j = matrix.length - 1;
        for (let i = 0; i < matrix.length; i++) {
            result += matrix[j][i];
            j--;
        }
        return result;
    }

    function sumMainDiagonal(matrix) {
        let result = 0;
        for (let i = 0; i < matrix.length; i++) {
            result += matrix[i][i];
        }
        return result;
    }

    function printState(matrix, separator = ' ') {
        matrix.forEach(row => console.log(row.join(separator)));
    }

    function parseToMatrix(semiMatrix, separator = ' ') {
        let matrix = new Array(semiMatrix.length);
        for (let i = 0; i < matrix.length; i++) {
            matrix[i] = semiMatrix[i].split(separator).map(Number);
        }
        return matrix
    }
}

solve(['1 1 1',
'1 1 1',
'1 1 0']);