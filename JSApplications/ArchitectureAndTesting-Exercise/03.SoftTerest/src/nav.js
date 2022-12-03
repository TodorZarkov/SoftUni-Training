
const userSee = [...document.querySelectorAll("[itemid='user']")];
const anonymousSee = [...document.querySelectorAll("[itemid='anonymous']")];
const navItems = [...document.querySelectorAll(".nav-item")];

export function checkNavBar(event) {
    if(sessionStorage.getItem("user")) {
        userSee.forEach(el=>el.parentElement.style.display = 'inline-block');
        anonymousSee.forEach(el=>el.parentElement.style.display = 'none');    
    } else {
        userSee.forEach(el=>el.parentElement.style.display = 'none');
        anonymousSee.forEach(el=>el.parentElement.style.display = 'inline-block');
    }

    if(event && event.target && event.target.href && event.target.href.startsWith("/")) {
        navItems.forEach(ni=>ni.classList.remove("active"));

        if(event.target.parentElement)
        event.target.parentElement.classList.add("active");
    }
}




export function router(link) {
    history.pushState(null,"",link);
}

