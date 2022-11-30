import { add } from "./add.js";
import { details } from "./details.js";
import { edit } from "./edit.js";
import { home } from "./home.js";
import { login } from "./login.js";
import { logout } from "./logout.js";
import { checkNavBar } from "./nav.js";
import { register } from "./register.js";

document.addEventListener('click', onNavigation);
const sectionContainer = document.getElementById("section-container");



const views = { //id:function dictionary
    "home-link": home,
    "logout-link": logout,
    "login-link": login,
    "register-link": register,

    "welcome-msg": null,

    "add-link": add,
    "details-link": details,
    "edit-link": edit,
    "nav-link": checkNavBar
}

goto("home-link");

function onNavigation(event) {
    
    
    if ((event.target.nodeName === "A" || event.target.nodeName === "BUTTON") 
    && views.hasOwnProperty(event.target.id)) {

        event.preventDefault();

        const viewName = event.target.id;
        
        goto(viewName, event);
    }
    
}

function goto(viewName, ...params) {
    
    checkNavBar();

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

