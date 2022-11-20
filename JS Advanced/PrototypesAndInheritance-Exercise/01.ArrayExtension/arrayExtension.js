(function iife() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    };

    Array.prototype.skip = function (n) {
        return this.slice(n, this.length);
    };

    Array.prototype.take = function (n) {
        return this.slice(0, n);
    };

    Array.prototype.sum = function () {
        return this.reduce(((prev, next) => prev += next), 0);
    }

    Array.prototype.average = function () {
        return this.sum()/(this.length);
    }

})();


let arr = [1, 2, 3, 4, 5, 6];

console.log(arr.last());

console.log(arr.take(2));

console.log(arr.skip(2));

console.log(arr.sum());

console.log(arr.avarage())