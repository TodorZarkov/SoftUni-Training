function solve(arr) {
    let data = arr.map(x => x.split(" | ")).map(x => [x[0], x[1], Number(x[2])]);
    let brands = new Map();

    for (let i = 0; i < data.length; i++) {
        let brand = data[i][0];
        let model = data[i][1];
        let quontity = data[i][2];

        if (!brands.has(brand)) {
            let models = new Map();
            brands.set(brand, models.set(model, 0));
        }
        else if (!brands.get(brand).has(model)) {
            brands.get(brand).set(model, 0);
        }

        let prevQuontity = brands.get(brand).get(model);
        brands.get(brand).set(model, quontity + prevQuontity);
    }

    let resultArr = Array.from(brands).map(b=>[b[0],Array.from(b[1])]);
    let result = '';
    for(let b of resultArr){
        result += `${b[0]}\n`;
        for(let m of b[1]){
            result += `###${m[0]} -> ${m[1]}\n`;
        }
    }
    result = result.trimEnd();
    console.log(result);
}


solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']);
