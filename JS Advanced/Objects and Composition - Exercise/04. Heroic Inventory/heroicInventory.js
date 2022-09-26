'use strict';
function solve(input){
    let heroes = [];
    for(let heroStrData of input){
        let hero = {};
        let heroData = heroStrData.split(/\s\/\s|\,\s/gm);
        hero.name = heroData[0];
        hero.level = Number(heroData[1]);
        hero.items = [];
        for(let i = 2; i<heroData.length;i++){
            hero.items.push(heroData[i]);
        }
        heroes.push(hero);
    }
    console.log(JSON.stringify(heroes));
    
}

solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']);
