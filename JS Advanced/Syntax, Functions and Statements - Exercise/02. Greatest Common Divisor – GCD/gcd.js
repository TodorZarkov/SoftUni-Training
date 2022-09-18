'use strict';
function gcd(n, m) {
    let divisor = Math.min(n, m);
    let min = divisor;
    let max = Math.max(n, m);
    let reminder = max % divisor + min % divisor;
    while (divisor !== 1) {
        if (reminder === 0)
            break;
        divisor--;
        reminder = max % divisor + min % divisor;
    }
    console.log(divisor);
}
gcd(2154, 458);