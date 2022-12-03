import { post } from "../serverApi.js";



let ctx = {};

export async function like(inCtx) {
    ctx = inCtx;

    let albumId = getId(ctx.event);

    await post("/data/likes",{albumId});

    ctx.event.target.style.display = 'none';
    let likesEl = document.getElementById("likes");
    let prevNumberOfLikes = Number(likesEl.textContent.slice(7,9));
    likesEl.textContent = `Likes: ${++prevNumberOfLikes}`;


}

function getId(event) {
    return event.target.getAttribute("albumid");
}