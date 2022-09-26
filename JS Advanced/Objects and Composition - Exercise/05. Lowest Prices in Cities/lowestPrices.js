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
        town.entry = 0;
        for (let t of towns) {
            if (t.product.name === town.product.name)
                town.entry = t.entry;
            else
                town.entry = i;
        }
        towns.push(town);
    }
    towns.sort((b, a) => {
        let result = a.product.price - b.product.price;
        if (result === 0 && a.product.name === b.product.name) {
            result = a.entry - b.entry;
        }
        return result;
    }).sort((d, c) => {
        return c.product.name.localeCompare(d.product.name);
    })
    let result = [];
    for (let i = 0; i < towns.length - 1; i++) {
        if (towns[i].product.name !== towns[i + 1].product.name) {
            result.push(towns[i]);
        }
    }
    result.push(towns[towns.length - 1]);
    result.sort((a, b) => a.entry - b.entry);

    for (let town of result) {
        console.log(`${town.product.name} -> ${town.product.price} (${town.name})`)
    }
}

solve(['Sofia City | Audi | 100000',
'Sofia City | BMW | 100000',
'Sofia City | Mitsubishi | 10000',
'Sofia City | Mercedes | 10000',
'Sofia City | NoOffenseToCarLovers | 0',
'Mexico City | Audi | 1000',
'Mexico City | BMW | 99999',
'Mexico City | Mitsubishi | 10000',
'New York City | Mitsubishi | 1000',
'Washington City | Mercedes | 1000']);