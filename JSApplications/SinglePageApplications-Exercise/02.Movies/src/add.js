

let ctx = {};
const section = document.getElementById("add-movie");
section.remove();

export function add(inCtx) {
    ctx = inCtx;
    ctx.render(section);
}