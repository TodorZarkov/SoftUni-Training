import { checkNavBar } from "./nav.js";
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
import { remove } from "./views/remove.js";
import { edit } from "./views/edit.js";
import { like } from "./views/like.js";


document.querySelector("#wrapper").addEventListener("click", goTo);
const container = document.querySelector("main");

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
    "/remove" : remove,
    "/edit" : edit,
    "/like" : like
    
}


goTo(undefined,"/");



function goTo(event,link, ...params) {
    let inLink = link;
    if(event && event.target.nodeName === "A") {
        let url = new URL(event.target.href);
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
            render,
            event
        },...params)
    }
}


function render(elementToExpose, containerElement = container) {
    containerElement.innerHTML = "";
    containerElement.appendChild(elementToExpose);
}