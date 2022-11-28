
export function home(thisCtx,name) {
    console.log("home");
    console.log(name);
    thisCtx.goto("login-link");
}