const regUrl = "http://localhost:3030/users/register";
const afterSuccessUrl = "./index.html"

loadListeners();

//control
function loadListeners() {
    document.getElementById("register-form").addEventListener('submit', onRegister);
}

async function onRegister(event) {
    event.preventDefault();
    let formEl = event.target;
    let form = new FormData(formEl);
    let email = form.get("email");
    let password = form.get("password");
    let rePass = form.get("rePass");
    if (password !== rePass) {
        window.alert("Repeat doesn't match Password");
        return;
    }
    let newUser;
    try {
        newUser = await register(email, password);
    } catch (error) {
        //all errors
        window.alert(error);
        return;
    }
    
    sessionStorage.setItem("accessToken",newUser.accessToken);
    window.location.replace(afterSuccessUrl);
}

//view


//model

async function register(email, password) {
    let regObj = { email, password };
    let newUser = null;

    let response = await fetch(regUrl, {
        method: "post",
        headers: { "content-type": "application/json" },
        body: JSON.stringify(regObj)
    });
    newUser = await response.json();
    if (response.ok === false || response.status !== 200) throw newUser.message;

    return newUser;
}