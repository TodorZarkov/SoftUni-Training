import { del, get, post } from "./serverApi.js";
import { write } from "./util.js";


const section = document.getElementById("movie-example");

const detailsContainer = document.getElementById("details-container");

let btnDel;
let btnEdit;

let btnLike;
let likesSpan;

section.remove();
let ctx = null;

let movie;



export async function details(inCtx, eventOrId) {
    ctx = inCtx;
    ctx.render(section);

    let movieId;
    if (!eventOrId.target) {
        movieId = eventOrId;
    } else {
        movieId = eventOrId.target.getAttribute("itemid");
    }

    movie = await getMovieFromREST("/data/movies", movieId);

    let mainDiv = await createDetails(movie);
    ctx.render(mainDiv, detailsContainer);

    
}


async function createDetails() {
    let display = "none";
    let displayLike = "none";
    let displayLikeBtn = "none";

    let userId = sessionStorage.getItem("id");
    let hasLikes = await isLiked(movie._id, sessionStorage.getItem("id"))
    let isOwner = userId === movie._ownerId ? true : false;

    let numberOfLikes = 'x';
    if (userId) {
        if (isOwner) {
            display = "inline-block";
            displayLike = "inline-block";
        }else{
            if(await hasLikes) {
                displayLike = "inline-block";
            } else{
                displayLikeBtn = "inline-block";
            }
        }

        numberOfLikes = await getNumberOfLikes(movie._id);
    }


    let div = document.createElement('div');
    div.classList.add("row", "bg-light", "text-dark");
    div.innerHTML = `
            <h1>Movie title: ${movie.title}</h1>
            <div class="col-md-8">
              <img class="img-thumbnail" src="${movie.img}"
                alt="Movie" />
            </div>
            <div class="col-md-4 text-center">
              <h3 class="my-3">Movie Description</h3>
              <p>
                ${movie.description}
              </p>
              <a class="btn btn-danger" href="javascript:void(0)" id="del-btn" style="display: ${display};">Delete</a>
              <a class="btn btn-warning" href="javascript:void(0)" id="edit-btn" style="display: ${display};">Edit</a>
              <a class="btn btn-primary" href="javascript:void(0)" id="like-btn" style="display: ${displayLikeBtn};">Like</a>
              <span class="enrolled-span" id="number-of-likes" style="display: ${displayLike};">Liked ${numberOfLikes}</span>
            </div>
    `;

    btnDel = div.querySelector("#del-btn");
    btnEdit = div.querySelector("#edit-btn");
    btnLike = div.querySelector("#like-btn");
    likesSpan = div.querySelector("#number-of-likes");

    btnDel.addEventListener('click', onDel);
    btnEdit.addEventListener('click', onEdit);
    btnLike.addEventListener('click', onLike);


    return div;
}


// /endpoint.{id} doesn't awlays work with the tests
async function getMovieFromREST(uri, movieId) {
    let movies;
    try {
        movies = await get(uri);
    } catch (error) {
        write(error.message);
        return;
    }

    return movies.find(m => m._id === movieId);
}


async function onDel(event) {
    if (movie._ownerId !== sessionStorage.getItem("id")) {
        return;
    }

    try {
        await del("/data/movies/" + movie._id, {}, sessionStorage.getItem("token"));
    } catch (error) {
        write(error.message);
        return;
    }

    ctx.goto("home-link");
}


function onEdit(event) {
    ctx.goto("edit-link", movie, event);
}


async function onLike(event) {
    let hasLikes = await isLiked(movie._id, sessionStorage.getItem("id"))
    let isOwner = sessionStorage.getItem("id") === movie._ownerId ? true : false;

    if (hasLikes || isOwner) {
        return;
    }

    console.log("onlike")
    await setLike(movie._id, sessionStorage.getItem("token"));

    btnLike.style.display = "none";
    likesSpan.style.display = "inline-block";
    likesSpan.textContent = "Liked " + await getNumberOfLikes(movie._id);
}


async function isLiked(movieId, userId) {
    let likes = [];
    try {
        likes = await get("/data/likes", {}, sessionStorage.getItem("token"));

    } catch (error) {
        write(message);
        return;
    }

    let filteredLike = likes.filter(l => l.movieid === movieId && l._ownerId === userId);

    return filteredLike.length;
}


async function getNumberOfLikes(movieId) {
    let likes = [];
    try {
        likes = await get("/data/likes", {}, sessionStorage.getItem("token"));

    } catch (error) {
        write(message);
        return;
    }

    return likes.filter(l => l.movieid === movieId).length;
}


async function setLike(movieid, accessToken) {
    let like = [];
    try {
        like = await post("/data/likes", { movieid }, accessToken);

    } catch (error) {
        write(error.message);
        return;
    }

    return like;
}