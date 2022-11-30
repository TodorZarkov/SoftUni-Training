import { get } from "./serverApi.js";
import { write } from "./util.js";

const section = document.getElementById("home-page");
const btnAddMovieSection = document.getElementById("add-movie-button");
const cardsContainerEl = document.getElementById("roller");
cardsContainerEl.addEventListener("wheel", moveCards);
document.getElementById("left").addEventListener("click", moveCards);
document.getElementById("right").addEventListener("click", moveCards);

let ctx = {};

let pageOfCardsDisplayed = 0;
let numberOfPages;

const pageSize = 10;

export async function home(inCtx) {
    ctx = inCtx;
    ctx.render(section);


    if (sessionStorage.getItem("token")) {
        btnAddMovieSection.style.display = "block";
    }
    else {
        btnAddMovieSection.style.display = "none";
    }

    numberOfPages = (await getCardsFromREST("/data/movies", 1, 0)).length;

    moveCards();
}



//TO DO PAGINATION json(): will return the data and next uri probably. alsol semistandart provides => ?_limit={number} ; ?_page={number}; NO!!
//ON THIS REST API IS LIKE THAT - e.g. ?pageSize=3&offset=2
async function getCardsFromREST(uri, offset = 1, pageSize = 3) {

    let movies;
    try {
        movies = await get(uri + "?" + `pageSize=${pageSize}&offset=${offset}`);
    } catch (error) {
        write(error.message);
        return;
    }

    return movies;
}



async function moveCards(event) {
    let pageRotator = 0;
    if (event) {
        event.preventDefault();
        pageRotator = event.wheelDeltaY > 0 ? -1 : 1;
        console.log(event.target.id);
        if (event.target.id == "left") pageRotator = -1;
        if (event.target.id == "right") pageRotator = 1;
    }


    let pageNumber = pageOfCardsDisplayed + pageRotator;
    if (pageNumber < 0 || pageNumber > numberOfPages) {
        pageNumber = pageOfCardsDisplayed;
    }

    let cardsArray = await getCardsFromREST("/data/movies", pageOfCardsDisplayed, pageSize);
    let cardsFragment = generateCards(cardsArray, pageSize);
    ctx.render(cardsFragment, cardsContainerEl.children[0]);

    pageOfCardsDisplayed = pageNumber;
}


function generateCard(data) {

    let li = document.createElement('li');

    li.classList.add("card", "mb-4");
    li.innerHTML = `
        <img src="${data.img}">
        <div class="card-body">
          <h4 class="card-title">${data.title}</h4>
        </div>
        <div class="card-footer">
            <button class="btn btn-info" type="button" id="details-link" itemid="${data._id}">Details</button>
        </div>
    `;

    return li;
}

function generateCards(data, number = 3) {

    let documentFragment = document.createDocumentFragment();

    if (data.length < number) {
        number = data.length;
    }

    for (let i = 0; i < number; i++) {
        documentFragment.appendChild(generateCard(data[i]))
    }

    return documentFragment;
}