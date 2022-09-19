'use strict';
function speedLimit(speed, area) {
    let speedLimit = 0;
    switch (area) {
        case 'motorway':
            speedLimit = 130;
            break;
        case 'interstate':
            speedLimit = 90;
            break;
        case 'city':
            speedLimit = 50;
            break;
        case 'residential':
            speedLimit = 20;
            break;
    }
    console.log(speedEvaluation(speed, speedLimit))

    function speedEvaluation(speed, limit){
        let difference = speed-limit
        if (difference <= 0) {
            return `Driving ${speed} km/h in a ${limit} zone`
        }else if (difference <= 20) {
            return `The speed is ${difference} km/h faster than the allowed speed of ${limit} - speeding`
        }else if (difference <= 40) {
            return `The speed is ${difference} km/h faster than the allowed speed of ${limit} - excessive speeding`
        }else {
            return `The speed is ${difference} km/h faster than the allowed speed of ${limit} - reckless driving`
        }
    }

}



speedLimit(200, 'motorway');