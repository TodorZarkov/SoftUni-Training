'use strict';
function solve(commands) {
    let currValue = 1;
    let result = [];
    commands.forEach(command => {
        switch (command) {
            case 'add':
                result.push(currValue);
                break;

            case 'remove':
                result.pop();
                break;
        }
        currValue++
    });
    if (result.length !== 0)
        result.forEach(x => console.log(x));
    else
        console.log('Empty');
}
solve(['remove',
    'remove',
    'remove']);