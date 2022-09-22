'use strict';
function solve(moves) {
    const dashboardSize = 3;
    const matrixSize = 9;
    let dashboard = new Array(dashboardSize);
    for (let i = 0; i < dashboard.length; i++) {
        dashboard[i] = new Array(dashboardSize).fill('false');
    }
    let player = 'X';
    let entries = 0;
    for(let move of moves){


        if (entries < matrixSize) {
            let row = Number(move[0]);
            let col = Number(move[2]);
            if (dashboard[row][col] === 'false') {
                dashboard[row][col] = player;
                player === 'X' ? player = 'O' : player = 'X';
                entries++;
                let winner = haveWinner(dashboard);
                if (winner) {
                    console.log(`Player ${winner} wins!`);
                    printState(dashboard);
                    return;
                }
            } else {
                console.log('This place is already taken. Please choose another!');
            }

        } else {
            console.log('The game ended! Nobody wins :(');
            printState(dashboard);
            return;
        }


    }




    function printState(dashboard) {
        dashboard.forEach(row => console.log(row.join('\t')));
    }

    function haveWinner(dashboard) {
        let result = false;
        for (let i = 0; i < dashboard.length; i++) {
            for (let j = 0; j < dashboard.length; j++) {
                if (dashboard[i][j] === 'false') {
                    result = false;
                    break;
                }
                if (dashboard[i][0] !== dashboard[i][j]) {
                    result = false;
                    break;
                } else {
                    result = dashboard[i][j]
                }
            }
            if (result !== false)
                return result;

            for (let j = 0; j < dashboard.length; j++) {
                if (dashboard[j][i] === 'false') {
                    result = false;
                    break;
                }
                if (dashboard[0][i] !== dashboard[j][i]) {
                    result = false;
                    break;
                } else {
                    result = dashboard[j][i]
                }
            }
            if (result !== false)
                return result;

        }



        let l = dashboard.length - 1;
        for (let k = 0; k < dashboard.length; k++) {

            if (dashboard[k][l] === 'false') {
                result = false;
                break;
            }
            if (dashboard[0][2] !== dashboard[k][l]) {
                result = false;
                break;
            } else {
                result = dashboard[k][l]
            }
            l--
        }
        if (result !== false)
            return result;

        
        for (let k = 0; k < dashboard.length; k++) {

            if (dashboard[k][k] === 'false') {
                result = false;
                break;
            }
            if (dashboard[0][0] !== dashboard[k][k]) {
                result = false;
                break;
            } else {
                result = dashboard[k][k]
            }
        }
        if (result !== false)
            return result;



        return result;
    }
}
solve(["0 0",
"0 0",
"1 1",
"0 1",
"1 2",
"0 2",
"2 2",
"1 2",
"2 2",
"2 1"]);