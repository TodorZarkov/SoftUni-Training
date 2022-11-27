const div = document.querySelector('.container');
const nav = document.querySelector('nav');
const footer = document.querySelector('footer');




export async function getAllMovies(sortDelegate = (a, b) => true, filterPredicate = a => a) {
    let movies = [];
    try {
        const responce = await fetch("http://localhost:3030/data/movies");
        if (!responce.ok || responce.status !== 200) throw new Error("No empty resource.")

        const result = await responce.json();

        movies = Object.values(result).filter(filterPredicate).sort(sortDelegate);

    } catch (error) {
        throw new Error(error.message);
    }

    const documentFragment = document.createDocumentFragment();

    movies.forEach(movieObj => {
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




        documentFragment.appendChild(cardLi);

    });

    document.getElementById("movies-list").replaceChildren(documentFragment);
}



export function showSection(section) {
    div.replaceChildren(nav, section, footer);
}


