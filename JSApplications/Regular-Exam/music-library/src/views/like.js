import { post } from "../serverApi.js";



let ctx = {};

export async function like(inCtx, event) {
    ctx = inCtx;


    let albumId = getId(event);

    let likes = await post("/data/likes",{albumId});
    console.log(likes);

}

function getId(event) {
    return event.target.getAttribute("albumid");
}