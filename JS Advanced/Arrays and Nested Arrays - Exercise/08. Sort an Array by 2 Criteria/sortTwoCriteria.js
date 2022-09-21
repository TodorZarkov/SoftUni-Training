'use strict';
function solve(arr){
    arr.sort((a,b)=>a.localeCompare(b)).sort((c,d)=>c.length-d.length);
    arr.forEach(name => console.log(name));
}
solve(['test', 
'Deny', 
'omen', 
'Default']);