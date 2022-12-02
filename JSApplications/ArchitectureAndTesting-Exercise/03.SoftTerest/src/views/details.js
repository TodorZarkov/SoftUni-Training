const section = document.getElementById("details");
let ctx = {};

export function details(inCtx) {
    ctx = inCtx;
    ctx.render(section);
}