'use strict';
function solve(input = []) {
    let result = input.map(x => {
        let [name, price] = x.split(' : ');
        price = Number(price);
        let product = { name, price };
        return product;
    }).sort((a, b) => a.name.localeCompare(b.name))

    print(result);


    function print(result) {
        console.log(result[0].name[0]);
        console.log(`  ${result[0].name}: ${result[0].price}`);
        for (let i = 0; i < result.length - 1; i++) {
            if (result[i].name[0] === result[i + 1].name[0]) {
                console.log(`  ${result[i + 1].name}: ${result[i + 1].price}`);
            }
            else {
                console.log(result[i + 1].name[0]);
                console.log(`  ${result[i + 1].name}: ${result[i + 1].price}`);
            }
        }
    }
}

solve(['Banana : 2',
    "Rubic's Cube : 5",
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']);