'use strict';
function solve(library, orders){
    let result = [];
    for(let order of orders){
        let obj = Object.assign({},order.template);
        for(let part of order.parts){
            obj[part] = library[part];
        }
        result.push(obj);
    }
    return result;
}