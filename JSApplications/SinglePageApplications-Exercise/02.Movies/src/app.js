import { getAllMovies } from './home.js';

window.addEventListener('load', loadHome);

export function loadHome() {
    
    document.getElementById("add-movie-button").style.display = "none";
    document.querySelectorAll(".user").forEach(e => e.style.display = "none");

    
    
    
    
    document.getElementById("home-page").style.display = "block";
    
    getAllMovies();

}





