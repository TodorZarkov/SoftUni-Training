
const section = document.getElementById("home-page");
let ctx = {};

export function home(inCtx) {
    ctx = inCtx;

    console.log("home");
    ctx.goto("add-link");
}