function solve() {
    //GLOBAL
    let tableEl = document.querySelector('table');//suppose one table.
    let divCheckEl = document.getElementById('check');
    let tBodyEl = document.querySelector("tbody");//suppose one table.
    document.querySelector("tfoot").addEventListener('click', whereClick);
    //CONTROL
    function whereClick(event) {
        let btn = event.target;
        if (btn.nodeName !== "BUTTON") return;
        if (btn.textContent === "Quick Check") {
            let table = getElementsAsNumbers();
            let isSolved = check(table);
            if (isSolved) {
                solved();
            }
            else {
                unsolved();
            }
        }
        else if (btn.textContent === "Clear") {
            clear();
        }
    }

    //VIEW DOM
    function getElementsAsNumbers() {
        let rows = Array.from(tBodyEl.getElementsByTagName("tr"));
        let table = rows
            .map(tr => Array.from(tr.getElementsByTagName("td"))
                .map(td => parseInt(td.querySelector("input").value, 10)));
        return table;
    }

    function solved() {
        let p = document.createElement('p');
        divCheckEl.innerHTML = '';
        tableEl.style.border = "2px solid green";
        p.textContent = "You solve it! Congratulations!";
        p.style.color = "green";
        divCheckEl.appendChild(p);
    }

    function unsolved() {
        let p = document.createElement('p');
        divCheckEl.innerHTML = '';
        tableEl.style.border = "2px solid red";
        p.textContent = "NOP! You are not done yet...";
        p.style.color = "red";
        divCheckEl.appendChild(p);
    }

    function clear() {
        tableEl.style.border = "none";
        divCheckEl.innerHTML = '';

        let rows = Array.from(tBodyEl.getElementsByTagName("tr"));
        let table = rows
            .map(tr => Array.from(tr.getElementsByTagName("td"))
                .map(td => Number(td.querySelector("input").value = "")));
    }


    //MODEL
    function sumRow(row, table) {
        return table[row].reduce(((prev, cur) => prev += cur), 0);
    }

    function sumCol(col, table) {
        let result = 0;
        for (let j = 0; j < table.length; j++) {
            result += table[j][col];
        }
        return result;
    }

    function check(table) {
        let sum = sumRow(0, table);
        for (let i = 0; i < table.length; i++) {
            if (sum !== sumRow(i, table)) {
                return false;
            }
        }


        for (let i = 0; i < table.length; i++) {
            if (sum !== sumCol(i, table)) {
                return false;
            }
        }



        let singleElement = table[0][0];
        let gotDifferent = false;
        for (let i = 0; i < table.length; i++) {
            for (let j = 0; j < table[i].length; j++) {
                if (table[i][j] === NaN) return false;
                if (!gotDifferent) {
                    if (singleElement !== table[i][j]) {
                        gotDifferent = true;
                    }
                }
                if (table[i][j] < 1 || table[i][j] > 9) return false;
            }
        }
        if (!gotDifferent) return false;


        for (let i = 0; i < table.length; i++) {
            for (let j = 0; j < table[i].length; j++) {
                let equals = table[i].filter(e => e === table[i][j]);
                if (equals.length > 1) return false;
                equals = 0;
                for (let k = 0; k < table.length; k++) {
                    if (table[k][j] === table[i][j]) {
                        equals++;
                    }
                }
                if(equals > 1) return false;
            }
        }

        return true;
    }
}