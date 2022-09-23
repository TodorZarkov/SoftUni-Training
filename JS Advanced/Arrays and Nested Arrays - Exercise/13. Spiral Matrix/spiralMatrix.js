'use strict';
function solve(height, width) {
    let matrix = new Array(height);
    for (let row = 0; row < matrix.length; row++) {
        matrix[row] = new Array(width);
    }
    fillWith(matrix, 0);


    printState(matrix, height, width);

    function right(matrix, startRowCol = [0, 0], filler) {
        let startRow = startRowCol[0];
        let j = startRowCol[1];
        for (; j < matrix[startRow].length; j++) {
            if (matrix[startRow][j] === 0) {
                matrix[startRow][j] = filler;
                filler++;
            } else {
                break;
            }
        }
        startRowCol[0]++;
        startRowCol[1] = j--;
        return filler
    }

    // function down(matrix, startRowCol = [0, 0], filler) {
    //     let i = startRowCol[0];
    //     let startCol = startRowCol[1];
    //     for (; startCol < matrix[i].length; startCol++) {
    //         if (matrix[i][startCol] === 0) {
    //             matrix[i][startCol] = filler;
    //             filler++;
    //         } else {
    //             break;
    //         }
    //     }
    //     startRowCol[0]++;
    //     startRowCol[1] = startCol--;
    //     return filler
    // }

    function fillWith(matrix, filler) {
        for (let i = 0; i < matrix.length; i++) {
            for (let j = 0; j < matrix.length; j++) {
                matrix[i][j] = filler;
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
solve(5, 5);