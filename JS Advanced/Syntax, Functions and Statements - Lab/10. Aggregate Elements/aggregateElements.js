'use strict';
function solve(input) {

    function func(aggregate, args) {
        let result = aggregate(args[0]);
        for (let i = 1; i < args.length; i++) {
            result += aggregate(args[i]);
        }
        return result;
    }
    console.log(func(x => x, input));
    console.log(func(x => 1 / x, input));
    console.log(func(x => `${x}`, input));

}
solve([2, 4, 8, 16]);