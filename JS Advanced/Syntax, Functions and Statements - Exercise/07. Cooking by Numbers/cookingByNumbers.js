'use strict';
function cookingByNumbers(numberAsAny, ...commands) {
    let number = Number(numberAsAny);
    commands.forEach(x=>console.log(number = operation(number,x)))
    function operation(number, command) {
        switch (command) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number = number - number*0.2;
                break;
        }
        return number;
    }
}

cookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop')