
const urlMovies = "http://localhost:3030/data/movies"

let user = "";
let token = "";

//sessionStorage.setItem("userName", "Pesho");
//sessionStorage.clear();

export async function loadHome() {
    if (!sessionStorage.getItem("userName")) {
        document.getElementById("add-movie-button").style.display = "none";
        document.querySelectorAll(".user").forEach(e=>e.style.display = "none");
        

        //in both cases
        let movieListDiv = document.getElementById("movies-list");
        let moviesArr = await getAllMovies(urlMovies);
        let cards = createCards(moviesArr)
        movieListDiv.replaceChildren(cards);
        
        document.getElementById("home-page").style.display = "block";
    }
    else {
        user = sessionStorage.getItem("userName");
        token = sessionStorage.getItem("token");
        document.getElementById("home-page").style.display = "block";
        document.querySelectorAll(".guest").forEach(e=>e.style.display = "none");
        
        //in both cases
        let movieListDiv = document.getElementById("movies-list");
        let moviesArr = await getAllMovies(urlMovies);
        let cards = createCards(moviesArr)
        movieListDiv.replaceChildren(cards);

        document.getElementById("add-movie-button").style.display = "block";
    }
}

function createCard(movieObj) {
    let cardLi = document.createElement("li");
    cardLi.classList.add("card");
    cardLi.classList.add("mb-4");
    cardLi.innerHTML = `
                <img src=${movieObj.img}>
                <div class="card-body">
                  <h4 class="card-title">${movieObj.title}</h4>
                </div>
                <div class="card-footer">
                  <a href="#"></a>
                  <button class="btn btn-info" type="button">Details</button>
                </div>
    `;
    return cardLi;
}


function createCards(moviesArr) {
    let documentFragment = document.createDocumentFragment();
    let cardLis = moviesArr.map(c => createCard(c));
    documentFragment.replaceChildren(...cardLis);
    return documentFragment;
}

//utilities
async function getAllMovies(url, sortDelegate = (a, b) => true, filterPredicate = a => a) {
    let responce = await fetch(url);
    let result = await responce.json();

    return Object.values(result).filter(filterPredicate).sort(sortDelegate);
}


