
const userSee = document.querySelector(".user")
const anonymousSee = document.querySelector(".guest")

export function checkNavBar(event) {
    if(sessionStorage.getItem("user")) {
        userSee.style.display = 'inline-block';
        anonymousSee.style.display = 'none';    
    } else {
        userSee.style.display = 'none';
        anonymousSee.style.display = 'inline-block';
    }

    
}





