import * as usr from "../user.js";


//const section = document.getElementById("details");
let ctx = {};

export function logout(inCtx) {
    ctx = inCtx;

    usr.logout();
    sessionStorage.removeItem("user");
    ctx.goTo(undefined, "/dashboard");

}