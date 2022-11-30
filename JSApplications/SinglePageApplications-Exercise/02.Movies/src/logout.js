import { get } from "./serverApi.js";
import { write } from "./util.js";

let ctx = null;

export function logout(inCtx) {
    ctx = inCtx;
    try {
        get("/users/logout", {}, sessionStorage.getItem("token"));
    } catch (error) {
        write(error.message);
    } finally {
        sessionStorage.clear();
        ctx.goto("login-link");
        return;
    }
}