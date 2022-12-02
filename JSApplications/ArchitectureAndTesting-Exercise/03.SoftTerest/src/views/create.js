const section = document.getElementById("create");
let ctx = {};

export function create(inCtx) {
    ctx = inCtx;
    ctx.render(section);
}