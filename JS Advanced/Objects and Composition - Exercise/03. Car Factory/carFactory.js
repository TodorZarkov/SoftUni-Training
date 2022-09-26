'use strict';
function solve(requirements = {}) {
    let car = {
        model: '',
        engine: {
            power: 0,
            volume: 0
        },
        carriage: {
            type: '',
            color: ''
        },
        wheels: [0, 0, 0, 0]
    }

    car.model = requirements.model;
    if (requirements.power <= 90) {
        car.engine.power = 90;
        car.engine.volume = 1800;
    } else if (requirements.power <= 120) {
        car.engine.power = 120;
        car.engine.volume = 2400;
    } else {
        car.engine.power = 200;
        car.engine.volume = 3500;
    }

    car.carriage.color = requirements.color;
    car.carriage.type = requirements.carriage;

    let availWheelSize = requirements.wheelsize;
    if (availWheelSize % 2 === 0) {
        availWheelSize-- ;
    }
    car.wheels.fill(availWheelSize);
    
    console.log(car.carriage);
    return car;
}

solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
});

