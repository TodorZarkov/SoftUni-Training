'use strict';
function sameDigits(number) {
    let numberAsString = `${number}`;
    let sum = 0;
    let same = true;
    for (let i = 0; i < numberAsString.length; i++) {
        sum += Number(numberAsString[i]);
        if (numberAsString[0] !== numberAsString[i])
            same = false;
    }
    if (same) {
        console.log(true);
        console.log(sum);
    } else {
        console.log(false);
        console.log(sum);
    }
}
sameDigits(2222222);