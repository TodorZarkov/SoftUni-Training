function solve(...params) {
    let countTypes = [];
    for (let param of params) {
        type = typeof (param);
        if(type==="object"){
            
        }
        console.log(`${type}: ${param}`);
        let element = countTypes.find(e => e[0] === type);
        if (element === undefined){
            countTypes.push([type,1]);
        }
        else{
            element[1]++;
        }
    }
    countTypes.sort((a,b)=>b[1]-a[1]).
    forEach(e=>console.log(`${e[0]} = ${e[1]}`));
}

solve({ name: 'bob'}, 3.333, 9.999);
