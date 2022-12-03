import { post } from "../serverApi.js";
import { getForm, isEmptyInput, write } from "../util.js";


const section = document.getElementById("create");
section.querySelector("form").addEventListener("submit",onCreate);
let ctx = {};

export function create(inCtx) {
    ctx = inCtx;
    ctx.render(section);


}


async function onCreate(event) {
    let data = getForm(event);
    

    if (isEmptyInput(data)) {
        write("All fields are mandatory.");
        return;
    }
    
    
    let album = {};
    try {

        album = await post("/data/albums", data);

    }
    catch (error) {
        write(error.message);
        event.target.reset();
        return;
    }


    event.target.reset();

    
    ctx.goTo(undefined, "/dashboard");
}
