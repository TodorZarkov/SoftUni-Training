'use strict';
function solution(arr) {
    let calorie = {};
    let evenEntry;
    let oddEntry;
    for (let entry = 0; entry < arr.length/2; entry++) {
        evenEntry = 2*entry;
        oddEntry = 2*entry + 1;
        calorie[arr[evenEntry]] = Number(arr[oddEntry]);
    }
    console.log(calorie);
}
solution(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);