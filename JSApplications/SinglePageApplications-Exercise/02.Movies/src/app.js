import { add } from "./add.js";
import { details } from "./details.js";
import { edit } from "./edit.js";
import { home } from "./home.js";
import { login } from "./login.js";
import { logout } from "./logout.js";
import { nav } from "./nav.js";
import { register } from "./register.js";
import { request } from "./serverApi.js";

document.querySelector("nav").addEventListener('click', onNavigation);
const sectionContainer = document.getElementById("section-container");


const views = {
    "home-link": home,
    "logout-link": logout,
    "login-link": login,
    "register-link": register,

    "welcome-msg": null,

    "add-link": add,
    "details-link": details,
    "edit-link": edit,
    "nav-link": nav
}

goto("home-link");

function onNavigation(event) {
    event.preventDefault();
    if (event.target.nodeName === "A") {
        const viewName = event.target.id;
        goto(viewName);
    }
    else {

    }
}

function goto(viewName, ...params) {
    const view = views[viewName];
    if (typeof view === "function") {
        view({
            goto,
            render
        }, ...params);
    }
}

function render(section, container = sectionContainer) {
    container.replaceChildren(section);
}


window.request = request;