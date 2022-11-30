import { put } from "./serverApi.js";
import { getForm, isEmptyInput, setForm } from "./util.js";

const section = document.getElementById("edit-movie");
const formEl = document.getElementById("form-edit");

formEl.addEventListener('submit',onSubmit);

section.remove();

let ctx;
let oldMovie;


export function edit(inCtx, inMovie) {
    ctx = inCtx;
    ctx.render(section);

    oldMovie = inMovie;

    setForm(formEl, [inMovie.title, inMovie.description, inMovie.img]);
}



async function onSubmit(event) {

    let data = getForm(event);
    
    if(isEmptyInput(data)) {
        write("All fields are mandatory.");
        return;
    }
    
    let movie = {};
    
    try {
        movie = await put("/data/movies" + "/" + oldMovie._id, data, sessionStorage.getItem("token"));
    } catch (error) {
        write(error.message);
        event.target.reset();
        return;
    }
    
    console.log(movie);

    event.target.reset();
    ctx.goto("details-link", movie._id);
}