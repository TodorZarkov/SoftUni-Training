import { post } from "./serverApi.js";
import { getForm, isEmptyInput, write } from "./util.js";

const section = document.getElementById("form-login");
document.getElementById("login-form").addEventListener('submit', onSubmitLogin);

section.remove();
let ctx = null;

export function login(inCtx) {

    ctx = inCtx;

    ctx.render(section);

}



async function onSubmitLogin(event) {

    let data = getForm(event);
    if (isEmptyInput(data)) {
        write("All fields are mandatory.");
        return;
    }

    data.email = data.email.trim();

    let user = {};
    try {
        user = await post("/users/login", data);
    }
    catch (error) {
        write(error.message);
        event.target.reset();
        return;
    }

    event.target.reset();

    sessionStorage.setItem("email", user.email);
    sessionStorage.setItem("token", user.accessToken);
    sessionStorage.setItem("id", user._id);
    
    event.target.reset();

    ctx.goto("home-link");
}