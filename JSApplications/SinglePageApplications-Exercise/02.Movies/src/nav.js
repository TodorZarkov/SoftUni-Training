

export function checkNavBar() {
    let email = sessionStorage.getItem("email");
    let token = sessionStorage.getItem("token");

    if (token) {
        document.querySelectorAll(".user").forEach(u => u.style.display = 'block');
        document.querySelectorAll(".guest").forEach(u => u.style.display = 'none');

        document.getElementById("welcome-msg").textContent = "Welcome, " + email;
    } 
    else {
        document.querySelectorAll(".user").forEach(u => u.style.display = 'none');
        document.querySelectorAll(".guest").forEach(u => u.style.display = 'block');

    }
}
