'use strict';
function solution(arr) {
    let calorie = {};
    for (let entry = 0; entry < arr.length/2; entry++) {
        calorie[arr[entry]] = Number(arr[entry+1]);
    }
    console.log(calorie);
}
solution(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);