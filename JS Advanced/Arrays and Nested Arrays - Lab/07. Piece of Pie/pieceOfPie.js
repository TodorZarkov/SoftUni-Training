'use strict';
function solve(arr, startFlav, endFlav){
    let result = arr.slice(arr.indexOf(startFlav), arr.indexOf(endFlav)+1);
    //console.log(result);
    return result;
}
solve(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie');