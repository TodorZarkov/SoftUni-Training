'use strict';
function fromJSONToHTMLTable(input) {
    let students = JSON.parse(input);
    let tableRow = ['<table>'];

    let row = '<tr>';
    for (let key in students[0]) {
        row += `<th>${key}</th>`;
    }
    row += '</tr>';
    tableRow.push(row);

    for (let student of students) {
        row = '<tr>';
        for (let key in student) {
            row += `<td>${student[key]}</td>`;
        }
        row += '</tr>';
        tableRow.push(row);
    }
    tableRow.push('</table>')
    console.log(tableRow.join('\n'));

}

fromJSONToHTMLTable(`[{"Name":"Stamat",
"Score":5.5},
{"Name":"3",
"Score":6}]`)