'use strict';

function circleArea(arg){
    let type = typeof(arg);
    if(type!== 'number'){
        console.log(`We can not calculate the circle area, because we receive a ${type}.`);
    }else{
        let area = Math.pow(arg,2)*Math.PI;
        console.log(area.toFixed(2));
    }
}
circleArea('3');