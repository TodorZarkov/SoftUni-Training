const loginUrl = "http://localhost:3030/users/login";
const afterSuccessUrl = "./index.html"

loadListeners();

//control
function loadListeners() {
    document.getElementById("login-form").addEventListener('submit', onLogin);
}

async function onLogin(event) {
    event.preventDefault();
    let formEl = event.target;
    let form = new FormData(formEl);
    let email = form.get("email");
    let password = form.get("password");
    let user;
    try {
        user = await login(email, password);
    } catch (error) {
        //all errors
        window.alert(error);
        return;
    }
    
    sessionStorage.setItem("accessToken",user.accessToken);
    window.location.replace(afterSuccessUrl);
}

//view


//model
async function login(email, password) {
    let regObj = { email, password };
    let user = null;

    let response = await fetch(loginUrl, {
        method: "post",
        headers: { "content-type": "application/json" },
        body: JSON.stringify(regObj)
    });
    user = await response.json();
    if (response.ok === false || response.status !== 200) throw user.message;

    return user;
}