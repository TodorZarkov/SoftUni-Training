import { get, put } from "../serverApi.js";
import { getForm, isEmptyInput, setForm, write } from "../util.js";

const section = document.getElementById("edit");
const formEl = section.querySelector("form");
formEl.addEventListener("submit",onPut);

let ctx = {};
let albumId;
let ownerId;

export async function edit(inCtx,event) {
    ctx = inCtx;
    ctx.render(section);

    let id = getId(event);
    let inOwnerId = getOwnerId(event);
    albumId=id;
    ownerId = inOwnerId;

    let data =await get("/data/albums/" + id);
    console.log(data);
    setForm(formEl,[data.singer,data.album,data.imageUrl,data.release, data.label, data.sales]);


    

    

}

function getId(event) {
    return event.target.getAttribute("albumid");
}

function getOwnerId(event) {
    return event.target.getAttribute("ownerid");
}


async function onPut(event){
    let data = getForm(event);
    

    if (isEmptyInput(data)) {
        write("All fields are mandatory.");
        return;
    }
    
    
    let album = {};
    try {

        album = await put("/data/albums/" + albumId, data);

    }
    catch (error) {
        write(error.message);
        event.target.reset();
        return;
    }


    event.target.reset();

    
    ctx.goTo(undefined,"/dashboard/details",albumId, ownerId)
}
