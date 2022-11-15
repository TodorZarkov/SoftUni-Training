class Textbox {
    _elements;
    _invalidSymbols;

    constructor(selector, regex) {
        this._invalidSymbols = regex;
    }

    get elements() {
        return this._elements;
    }

    

    isValid()  {

        return true;
    }
}

let textbox = new Textbox(".textbox", /[^a-zA-Z0-9]/);
let inputs = document.getElementsByClassName('.textbox');

inputs.addEventListener('click', function () { console.log(textbox.value); });
