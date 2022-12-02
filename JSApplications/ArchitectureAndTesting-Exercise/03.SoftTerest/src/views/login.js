const section = document.getElementById("login");
let ctx = {};

export function login(inCtx) {
    ctx = inCtx;
    ctx.render(section);

}