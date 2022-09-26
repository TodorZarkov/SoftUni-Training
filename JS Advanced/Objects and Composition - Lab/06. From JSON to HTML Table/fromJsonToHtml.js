'use strict';
function fromJSONToHTMLTable(input) {
    //Write your code here
    let students = JSON.parse(input);
    let tableRow = [];
    let result = `<table>\n`;

    tableRow.push('\t<tr>');
    for (let key in students[0]) {
        tableRow.push(`<th>${key}</th>`);
    }
    tableRow.push('</tr>\n');

    for (let student of students) {
        tableRow.push('\t<tr>');
        for (let key in student) {
            tableRow.push(`<td>${student[key]}</td>`);

        }
        tableRow.push('</tr>\n');
    }
    result += tableRow.join('') + `</table>`;
    console.log(result);

//     return (`<table>
// ${result}
// </table>`);
}

fromJSONToHTMLTable(`[{"Name":"Stamat",
"Score":5.5},
{"Name":"Rumen",
"Score":6}]`)