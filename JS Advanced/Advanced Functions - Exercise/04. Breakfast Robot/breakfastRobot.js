function solution() {
    let ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }
    let recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10,  carbohydrate: 10 ,fat: 10, flavour: 10,}

    }


    return (command) => {
        let commandData = command.split(' ').filter(s => s);
        if (commandData[0] === 'restock') {
            ingredients[commandData[1]] += Number(commandData[2]);
            return 'Success';
        }
        else if (commandData[0] == 'prepare') {
            let clonedIngr = JSON.parse(JSON.stringify(ingredients));
            let meal = recipes[commandData[1]];
            let repeats = Number(commandData[2]);
            for (let repeat = 0; repeat < repeats; repeat++) {
                for (let ingredient in meal) {
                    if (clonedIngr[ingredient] >= meal[ingredient]) {
                        clonedIngr[ingredient] -= meal[ingredient]
                    }
                    else {
                        return `Error: not enough ${ingredient} in stock`
                    }
                }
            }
            ingredients = clonedIngr;
            return 'Success';
        }
        else if (commandData[0] === 'report') {
            let result = [];
            for (let key in ingredients) {
                result.push(`${key}=${ingredients[key]}`)
            }
            return result.join(' ');
        }
    }
}

let manager = solution();
console.log(manager("prepare turkey 1"));
console.log(manager("restock protein 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("restock carbohydrate 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("report"));
