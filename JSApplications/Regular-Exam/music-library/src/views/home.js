
const section = document.getElementById("home");
let ctx = {};

export function home(inCtx) {
    ctx = inCtx;
    ctx.render(section);
}