import { post } from "./serverApi.js";
import { getForm, write, isEmptyInput, isValidPassword } from "./util.js";


const section = document.getElementById("form-sign-up");
document.getElementById("register-form").addEventListener("submit", onSubmit);
section.remove();
let ctx = null;

export function register(inCtx) {

    ctx = inCtx;
    ctx.render(section);

}


async function onSubmit(event) {
    //"email" ; "password" ; "repeatPassword"
    let data = getForm(event);

    data.email = data.email.trim();

    if (isEmptyInput(data)) {
        write("All fields are mandatory.");
        return;
    }
    if (!isValidPassword(data.password)) {
        write("Insufficient password.");
        return;
    }
    if (data.password !== data.repeatPassword) {
        write("The Password and Repeat-Password field doesn't match.");
        return;
    }

    delete data.repeatPassword;

    let user = {};
    try {

        user = await post("/users/register", data);

    }
    catch (error) {
        write(error.message);
        event.target.reset();
        return;
    }

    sessionStorage.setItem("email", user.email);
    sessionStorage.setItem("token", user.accessToken);
    sessionStorage.setItem("id", user._id);

    event.target.reset();

    ctx.goto("home-link");

}