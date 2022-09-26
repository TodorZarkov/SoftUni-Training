'use strict';
function solve(input = []) {
    let towns = [];
    for (let i = 0; i < input.length; i++) {
        let townData = input[i].split(' | ');
        let town = {};
        town.name = townData[0];
        town.product = {};
        town.product.name = townData[1];
        town.product.price = Number(townData[2]);
        town.entry = i;
        towns.push(town);
    }
    towns.sort((b, a) => {
        let result = a.product.price - b.product.price;
        if(result === 0 && a.product.name === b.product.name){
            result = a.entry - b.entry;
        }
        return result;
    }).sort((d, c) => {
        return c.product.name.localeCompare(d.product.name);
    })
    let result = [];
    for (let i = 0; i < towns.length-1; i++) {
        if (towns[i].product.name !== towns[i+1].product.name){
            result.push(towns[i]);
        }
    }
    result.push(towns[towns.length-1]);
    result.sort((a,b)=>a.entry - b.entry);

    for(let town of result){
        console.log(`${town.product.name} -> ${town.product.price} (${town.name})`)
    }
}

solve(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']);