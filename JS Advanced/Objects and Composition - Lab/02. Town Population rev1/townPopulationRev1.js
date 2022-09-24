'use strict';
function solve(inputTowns) {
    let registry = inputTowns.map(towns =>{
        let [name, population] = towns.split(' <-> ');
        return{
            name: name,
            population: Number(population)
        }
    }).reduce((result, town)=>{
        if(result[town.name] === undefined){
            result[town.name] = town.population;
        }else{
            result[town.name] += town.population;
        }
        return result;
    },{});
    
    for (let town in registry) {
        console.log(`${town} : ${registry[town]}`)
    }
}
solve(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']);