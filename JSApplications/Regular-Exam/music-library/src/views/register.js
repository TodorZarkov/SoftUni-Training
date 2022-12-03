import { post } from "../serverApi.js";
import { getForm, isEmptyInput, isValidPassword, write } from "../util.js";

const section = document.getElementById("register");
section.querySelector("form").addEventListener("submit", registerSubmit);

let ctx = {};

export function register(inCtx) {
    ctx = inCtx;
    ctx.render(section);
}

async function registerSubmit(event) {
        //"email" ; "password" ; "repeatPassword"
        let data = getForm(event);

        data.email = data.email.trim();
        
        if (isEmptyInput(data)) {
            write("All fields are mandatory.");
            return;
        }
        // if (!isValidPassword(data.password)) {
        //     write("Insufficient password.");
        //     return;
        // }
        if (data.password !== data['re-password']) {
            write("The Password and Repeat-Password field doesn't match.");
            return;
        }
        
        delete data['re-password'];
    
        let user = {};
        try {
    
            user = await post("/users/register", data);
    
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