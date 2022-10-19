function add(num){
    let sum = num;
    
    function inAdd(inNum){
        sum+=inNum;
        console.log(sum);
        return inAdd;
    }
    inAdd.toString = ()=>sum;
    return inAdd;
}

console.log(add(1)(2).toString());