class Stringer {

    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    decrease(length) {
        if (isNaN(length) || length % 1 !== 0) {
            throw 'Length must be integer number.';
        }
        if (this.innerLength - length < 0) {
            this.innerLength = 0;
        }
        else {
            this.innerLength -= length;
        }
    }

    increase(length) {
        if (isNaN(length) || length % 1 !== 0) {
            throw 'Length must be integer number.';
        }
        this.innerLength += length;
    }

    toString() {
        let result = '';
        let length = this.innerString.length <= this.innerLength ? this.innerString.length : this.innerLength;
        for (let i = 0; i < length; i++) {
            result += this.innerString[i];
        }
        if (length<this.innerString.length){
            result += "...";
        }
        return result;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test