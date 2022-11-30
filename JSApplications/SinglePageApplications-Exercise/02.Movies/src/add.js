import { post } from "./serverApi.js";
import { getForm, isEmptyInput, write } from "./util.js";

const section = document.getElementById("add-movie");

document.getElementById("add-movie-form").addEventListener('submit',onSubmit);

let ctx = null;
section.remove();


export function add(inCtx) {
    ctx = inCtx;
    ctx.render(section);
}



//"title" ; "description" ; "img"
async function onSubmit(event) {

    let data = getForm(event);
    
    if(isEmptyInput(data)) {
        write("All fields are mandatory.");
        return;
    }
    
    let movie = {};
    
    try {
        movie = await post("/data/movies",data, sessionStorage.getItem("token"));
    } catch (error) {
        write(error.message);
        event.target.reset();
        return;
    }
    
    event.target.reset();
    ctx.goto("home-link");
}