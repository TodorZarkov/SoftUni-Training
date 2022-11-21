(function solve() {
    String.prototype.ensureStart = function (txt) {
        return this.startsWith(txt) ? this.toString() : txt + this.toString();
    };

    String.prototype.ensureEnd = function (str) {
        return this.endsWith(str) ? this.toString() : this.toString() + str;
    };

    String.prototype.isEmpty = function () {
        return this.length === 0 ? true : false;
    };

    String.prototype.truncate = function (n) {
        if (this.length <= n) return this.valueOf();
        if (n < 4) return ".".repeat(n);
        let words = this.split(' ');
        if (words.length === 1) return this.slice(0, n - 3) + "...";
        let charCount = 0;
        let stopIndex = 0;
        for (let i = 0; i < words.length; i++) {
            charCount += words[i].length;
            if (charCount > n - 3) {
                stopIndex = i - 1;
                break;
            }
            charCount++;
        }
        if (stopIndex === -1) {
            return words[0].slice(0, n - 3) + "...";
        }
        let result = words.slice(0, stopIndex + 1).join(' ') + "...";
        return result;
    };

    String.format = function (string, ...params) {
        const regexTokens = /\{|\}/gm;
        let tokens = string
            .split(regexTokens)
            .map(t => {
                if (isNaN(parseInt(t))) {
                    return t;
                }

                let position = parseInt(t);
                if (params.length > position) {
                    return params[position];
                }

                return '{' + position + '}';
            });

        return tokens.join('');
    };
})();


// let str = 'my string';
// str = str.ensureStart('my');
// str = str.ensureStart('');
// console.log(str);
// let str = ' string';
// console.log(str);

// str = str.ensureStart('my');
// console.log(str);

// str = str.ensureEnd("ala");
// console.log(str);

// console.log(str.isEmpty());
// str = '';
// console.log(str.isEmpty());

// str = 'aaaaa';
// str = str.truncate(3);
// console.log(str);

// str = '123456789';
// str = str.truncate(6);
// console.log(str)


// let str = String.format('{0}{2}', 'dog');
// console.log(str);

