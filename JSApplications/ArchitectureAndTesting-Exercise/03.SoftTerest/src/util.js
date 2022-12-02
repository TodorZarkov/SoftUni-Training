
export function getForm(event) {
    //if(typeof event.preventDefault === "function")
    event.preventDefault();
    let form = event.target;
    return Object.fromEntries(new FormData(form));
}

export function setForm(formElement, data) {
    let inputs = Array.from(formElement.querySelectorAll("[name]"));

    let length = inputs.length < data.length ? inputs.length : data.length
    
    for (let i = 0; i < length; i++){
        inputs[i].value = data[i];
    }
}



export function isEmptyInput(data) {
    if (Object.values(data).find(f => f === "") === "") {
        return true;
    };
    return false;
}

export function isValidEmail(email) {
    return isValidPassword(email);
}

export function isValidPassword(pass) {
    const passMinLength = 3;
    if (pass.length < passMinLength) {
        return false;
    }
    return true;
}



export function write(message) {
    alert(message);
}

