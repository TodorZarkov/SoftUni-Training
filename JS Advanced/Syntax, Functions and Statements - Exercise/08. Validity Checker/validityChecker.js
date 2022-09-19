'use strict';
function validityChecker(qx = 0, qy = 0, px = 0, py = 0) {

    function isIntegerDist(qx, qy, px, py) {
        let dist = Math.sqrt(Math.pow((px - qx), 2) + Math.pow((py - qy), 2));

        return dist % 1 === 0 ? 'valid' : 'invalid';
    }
    console.log(`{${qx}, ${qy}} to {0, 0} is ${isIntegerDist(qx, qy, 0, 0)}`);
    console.log(`{${px}, ${py}} to {0, 0} is ${isIntegerDist(px, py, 0, 0)}`);
    console.log(`{${qx}, ${qy}} to {${px}, ${py}} is ${isIntegerDist(qx, qy, px, py)}`);
}

validityChecker(3, 0, 0, 4)