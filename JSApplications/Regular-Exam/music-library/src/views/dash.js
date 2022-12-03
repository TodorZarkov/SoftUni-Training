import { get } from "../serverApi.js";

const section = document.getElementById("dashboard");
const cardWrapperUl = document.querySelector(".card-wrapper")
let ctx = {};

export async function dash(inCtx) {
    ctx = inCtx;
    ctx.render(section);

    let albums = await get("/data/albums?sortBy=_createdOn%20desc")
    
    cardWrapperUl.innerHTML = "";
    
    albums.map(a=>createCard(a));

    console.log(albums);
}


function createCard(data) {
    let li = document.createElement('li');
    li.classList.add("card");
    li.innerHTML = `
            <img src="${data.imageUrl}" />
            <p>
              <strong>Singer/Band: </strong><span class="singer">${data.singer}</span>
            </p>
            <p>
              <strong>Album name: </strong><span class="album">${data.album}</span>
            </p>
            <p><strong>Sales:</strong><span class="sales">${data.sales}</span></p>
            <a class="details-btn" href="/dashboard/details" id="${data._id}" ownerid = "${data._ownerId}">Details</a>
    `;
    cardWrapperUl.appendChild(li);
}



