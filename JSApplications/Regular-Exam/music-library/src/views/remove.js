import { del } from "../serverApi.js";



let ctx = {};

export function remove(inCtx) {
    ctx = inCtx;

    let sure = confirm("Are you sure?");
    if(!sure) return;


    let id = getId(ctx.event);

    del("/data/albums/" + id);

    ctx.goTo(undefined,"/dashboard")

}

function getId(event) {
    return event.target.getAttribute("albumid");
}