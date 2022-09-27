'use strict';
function solve(input){
    let result = [];
    for(let entry of input){
        let [name, product, price] = entry.split(' | ');
        price = Number(price);
        let currentTown = {name , product , price};
        let hasProperty = false;
        for(let town of result){
            if(town.product === currentTown.product){
                if(town.price > currentTown.price){
                    town.price = currentTown.price;
                    town.name = currentTown.name
                    hasProperty = true;
                    break;
                }else{
                    hasProperty = true;
                    break;
                }
            }
        }
        if(!hasProperty){
            result.push(currentTown);
        }
    }
    for(let town of result){
        console.log(`${town.product} -> ${town.price} (${town.name})`)
    }
}

solve(['Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 100000',
    'Mexico City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Washington City | Mercedes | 1000']);