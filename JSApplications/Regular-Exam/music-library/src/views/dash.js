import { get } from "../serverApi.js";

const section = document.getElementById("dashboard");
let ctx = {};

export async function dash(inCtx) {
    ctx = inCtx;
    ctx.render(section);

    let albums = await get("/data/albums?sortBy=_createdOn%20desc");
    
    section.innerHTML = "";
    
    let arrCards = albums.map(a=>createCard(a));
    let cards = createCards(arrCards);

    if(cards){
      section.innerHTML = "<h2>Albums</h2>";
      section.appendChild(cards)
    } else {
      section.innerHTML = "<h2>There are no albums added yet.</h2>";
    }

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
    return li;
}


function createCards(arrCards) {

  if(!arrCards.length) return null;

  let ul = document.createElement('ul');
  ul.classList.add("card-wrapper");
  arrCards.forEach(card=>ul.appendChild(card));
  return ul;
}



