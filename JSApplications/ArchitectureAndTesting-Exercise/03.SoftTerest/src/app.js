import { checkNavBar } from "./nav.js";
import { home } from "./views/home.js";
import "./serverApi.js";
import './serverApi.js';
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


const views = {
    "nav-home-link": home,
    "nav-dashboard-link": dash,
    "nav-create-link": create,
    "nav-logout-link": logout,
    "nav-login-link": login,
    "nav-register-link": register,
    "details-link" : details,
    "nav-get-started-link" : register
    
}

let obj = {target : {id:"nav-home-link"}}
goTo(obj);


//event.target.id is must to redirect!!! //mock  event problem
function goTo(event, ...params) {
    const id = event.target.id

    if (!id) return;
    if (!views[id]) return;

    if(typeof event.preventDefault === 'function')
    event.preventDefault();

    checkNavBar(event);

    if ((typeof views[id]) === "function") {
        views[id]({
            goTo,
            render
        })
    }
}


function render(elementToExpose, containerElement = container) {
    containerElement.replaceChildren(elementToExpose);
}