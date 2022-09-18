function solve(fruit, quantity, price) {
    console.log(`I need $${(quantity*price/1000).toFixed(2)} to buy ${(quantity/1000).toFixed(2)} kilograms ${fruit}.`)
}
solve('orange', 2500, 1.80)