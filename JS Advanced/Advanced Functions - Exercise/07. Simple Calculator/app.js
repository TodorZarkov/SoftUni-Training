function calculator() {
    return {
        num1Element : {},
        num2Element : {},
        resElement  : {},
        init(selector1, selector2, resultSelector) {
            this.num1Element = document.querySelector(selector1);
            this.num2Element = document.querySelector(selector2);
            this.resElement = document.querySelector(resultSelector);
        },

        add() {
            let n1 = Number(this.num1Element.value);
            let n2 = Number(this.num2Element.value);
            let result = n1 + n2;
            this.resElement.value = result;
        },

        subtract() {
            let n1 = Number(this.num1Element.value);
            let n2 = Number(this.num2Element.value);
            let result = n1 - n2;
            this.resElement.value = result;
        }
    }
}

let calculate = calculator();
calculate.init('num1','num2','result');





