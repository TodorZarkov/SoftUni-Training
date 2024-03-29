import { checkNavBar, router } from "./nav.js";
import { home } from "./views/home.js";
import "./serverApi.js";
import './user.js';
import "./util.js";
import { dash } from "./views/dash.js";
import { create } from "./views/create.js";
import { details } from "./views/details.js";
import { login } from "./views/login.js";
import { register } from "./views/register.js";
import { logout } from "./views/logout.js";


document.querySelector("body").addEventListener("click", goTo);
const container = document.getElementById("dynamic-content");

// let a = document.createElement("a");
// a.parentElement


const views = {
    "/": home,
    "/dashboard": dash,
    "/create": create,
    "/logout": logout,
    "/login": login,
    "/register": register,
    "/dashboard/details" : details,
    
}



goTo(undefined,"/");


//event.target.id is must to redirect!!! //mock  event problem
function goTo(event,link, ...params) {
    let inLink = link;
    if(event && event.target.nodeName === "A") {
        let url = new URL(event.terget.href);
        inLink = url.pathname;
        if (!views[inLink]) return;
        event.preventDefault();
    } else if(event && event.target.parentElement.nodeName === "A"){
        let trg = event.target.parentElement;

        let url = new URL(trg.href);
        inLink = url.pathname;
        if (!views[inLink]) return;
        event.preventDefault();
    }

    if (!views[inLink]) return;

    checkNavBar(event);

    if ((typeof views[inLink]) === "function") {
        views[inLink]({
            goTo,
            render
        })
    }
}


function render(elementToExpose, containerElement = container) {
    containerElement.replaceChildren(elementToExpose);
}