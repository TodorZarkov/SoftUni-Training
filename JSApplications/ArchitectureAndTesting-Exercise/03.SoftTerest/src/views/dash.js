const section = document.getElementById("dashboard-holder");
let ctx = {};

export function dash(inCtx) {
    ctx = inCtx;
    ctx.render(section);
}