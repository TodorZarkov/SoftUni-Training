
import { get } from "../serverApi.js";

const section = document.getElementById("details");
let ctx = {};

export async function details(inCtx,id,ownerId) {
    ctx = inCtx;
    ctx.render(section);

    if(ctx.event && ctx.event.target) {
    id = ctx.event.target.id;
    ownerId = ctx.event.target.getAttribute("ownerId");
    }
    
    
    let data = await get("/data/albums/"+id)

    let card = await createCard(data, ownerId, id);

    ctx.render(card,section);
}




async function createCard(data, ownerId, id){
    let div = document.createElement("div");
    div.id = "details-wrapper";

    let likes = await get(`/data/likes?where=albumId%3D%22${id}%22&distinct=_ownerId&count`)

    let displayLike = "none";
    let ownerDisplay = "none"

    
    let user = JSON.parse(sessionStorage.getItem("user"));

    if(user) {
        if(ownerId === user._id){
            ownerDisplay = "inline-block";
        }else{
            displayLike = "inline-block";
        }

    }

    let liked = await get(`/data/likes?where=albumId%3D%22${id}%22%20and%20_ownerId%3D%22${user._id}%22&count`);
    if(liked) {
      displayLike = 'none';
    }

    div.innerHTML = `
          <p id="details-title">Album Details</p>
          <div id="img-wrapper">
            <img src="${data.imageUrl}" alt="example1" />
          </div>
          <div id="info-wrapper">
            <p><strong>Band:</strong><span id="details-singer">${data.singer}</span></p>
            <p>
              <strong>Album name:</strong><span id="details-album">${data.album}</span>
            </p>
            <p><strong>Release date:</strong><span id="details-release">${data.release}</span></p>
            <p><strong>Label:</strong><span id="details-label">${data.label}</span></p>
            <p><strong>Sales:</strong><span id="details-sales">${data.sales}</span></p>
          </div>
          <div id="likes">Likes: <span id="likes-count">${likes}</span></div>

          <!--Edit and Delete are only for creator-->
          <div id="action-buttons">
            <a href="/like" id="like-btn" albumid = ${data._id} style="display: ${displayLike};">Like</a>
            <a href="/edit" id="edit-btn" albumid = ${data._id} ownerid = ${data._ownerId} style="display: ${ownerDisplay};">Edit</a>
            <a href="/remove" id="delete-btn" albumid = ${data._id} style="display: ${ownerDisplay};">Delete</a>
          </div>
    `;

    return div;
}



