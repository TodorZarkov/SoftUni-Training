'use strict';
function solve(input = []) {
    let headRow = input.shift().split(/[\s]*\|[\s]*/g).filter(x=>x);
    
    let result = input.map(entry=>{
        let town = {};
        let townData = entry.split(/[\s]*\|[\s]*/g).filter(x=>x);
        town[headRow[0]] = townData[0]; 
        town[headRow[1]] = Math.round(Number(townData[1])*100)/100; 
        town[headRow[2]] = Math.round(Number(townData[2])*100)/100; 
        return town;
    })
    result = JSON.stringify(result);

    
    //console.log(result);
    return result;

}

solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']);