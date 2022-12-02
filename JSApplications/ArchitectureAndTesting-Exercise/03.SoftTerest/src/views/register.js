import { post } from "../serverApi.js";
import { getForm, isEmptyInput, isValidPassword, write } from "../util.js";

document.getElementById("submit-link").addEventListener("submit", registerSubmit);
const section = document.getElementById("register");
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
    
        sessionStorage.setItem("user", JSON.stringify(user));
    
        event.target.reset();
    
        let navHomeObj = {target : {id:"nav-home-link"}}
        ctx.goTo(navHomeObj);
}