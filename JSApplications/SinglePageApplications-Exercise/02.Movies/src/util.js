
export function getForm(event) {
    event.preventDefault();
    let form = event.target;
    return Object.fromEntries(new FormData(form));
}

export function setForm(formEl, data) {
    let inputs = Array.from(formEl.querySelectorAll("input, textarea, input"));

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

export function write(message) {
    alert(message);
}

export function isValidEmail(email) {
    return isEmptyInput(email);
}

export function isValidPassword(pass) {
    const passMinLength = 6;
    if (pass.length < passMinLength) {
        return false;
    }
    return true;
}
