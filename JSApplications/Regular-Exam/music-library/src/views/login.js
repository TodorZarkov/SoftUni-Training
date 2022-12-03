import { post } from "../serverApi.js";
import { getForm, isEmptyInput, write } from "../util.js";

const section = document.getElementById("login");
section.querySelector("form").addEventListener("submit", loginSubmit);

let ctx = {};

export function login(inCtx) {
    ctx = inCtx;
    ctx.render(section);

}

async function loginSubmit(event) {
    //"email" ; "password" ; "repeatPassword"
    let data = getForm(event);

    data.email = data.email.trim();
    
    if (isEmptyInput(data)) {
        write("All fields are mandatory.");
        return;
    }
    
    
    let user = {};
    try {

        user = await post("/users/login", data);

    }
    catch (error) {
        write(error.message);
        event.target.reset();
        return;
    }

    sessionStorage.setItem("user", JSON.stringify(user));

    event.target.reset();

    
    ctx.goTo(undefined, "/dashboard");
}