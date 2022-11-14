function solve(arr) {
    let filler = new Map();
    let bottles = new Map();
    const capacity = 1000;

    for (let pair of arr) {
        let kvp = pair.split(" => ").filter(kvp => kvp);
        let key = kvp[0];
        let value = Number(kvp[1]);
        if (!filler.has(key)) {
            filler.set(key, 0);
        }
        filler.set(key,  filler.get(key)+ value);
        while (filler.get(key) >= capacity) {
            if (!bottles.has(key)) {
                bottles.set(key, 0);
            }
            bottles.set(key,  bottles.get(key) + 1);
            filler.set(key,  filler.get(key) - capacity);
        }
    }

    let result = [];
    bottles.forEach((v, k) => result.push(`${k} => ${v}`));
debugger
    return result.join("\n");
}

let result = solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']);

console.log(result);