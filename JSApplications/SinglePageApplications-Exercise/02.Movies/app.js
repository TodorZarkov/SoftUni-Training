import { getAllMovies, showSection } from './home.js';

window.addEventListener('load', loadHome);
const sections = document.querySelectorAll(".view-section");

export function loadHome() {
    
    document.getElementById("add-movie-button").remove();
    showSection(sections[0]);

    document.getElementById("home-page").style.display = "block";
    
    getAllMovies();

}





