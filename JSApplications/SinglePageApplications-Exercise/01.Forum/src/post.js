import { getTopicFromDb, isValid } from "./home.js";
import { answerForm, homeSection, loadingBoxes, postHeader, postSection, themeName, userCommentsDiv } from "./vars.js";

const urlComments = "http://localhost:3030/jsonstore/collections/myboard/comments";

answerForm.addEventListener('submit', onComment);
let currentTopicId;

//control
export async function loadPost(event) {
    postSection.style.display = "none";
    homeSection.style.display = "none";

    let id = event.target.parentElement.id;
    populateTopic(loadingBoxes);
    let topicObj = await getTopicFromDb(id)
    populateTopic(topicObj);
    currentTopicId = id;

    let comments = await getCommentsFromDb(currentTopicId);
    let commentCardsArray = createPostCards(comments);
    userCommentsDiv.replaceChildren(...commentCardsArray);
    postSection.style.display = "block";

}

async function onComment(event) {
    let uctTimeObj = new Date();
    let uctDateTimeISO = uctTimeObj.toISOString();
    event.preventDefault();
    let formData = new FormData(event.target);
    let text = formData.get("postText");
    let userName = formData.get("username");
    let topicId = currentTopicId;
    event.target.reset();
    try {
        let commentObj = await setCommentToDb(userName, text, uctDateTimeISO, topicId);
        let commentDiv = createPostCard(commentObj);
        userCommentsDiv.insertAdjacentElement("beforeend",commentDiv);
    } catch (error) {
        window.alert(error.message);
    } finally {

    }
}

//view
function populateTopic(topicObj) {
    let titleH2 = document.createElement('h2');
    titleH2.textContent = topicObj.title;
    themeName.replaceChildren(titleH2);

    let p1 = postHeader.getElementsByTagName("p")[0];
    let p2 = postHeader.getElementsByTagName("p")[1];
    let formatedDate = "loading...";
    if (topicObj.eventTime !== "loading...")
        formatedDate = formatDate(new Date(topicObj.eventTime));
    p1.innerHTML = `<span>${topicObj.username}</span> posted on <time>${formatedDate}</time>`;
    p2.textContent = topicObj.content;
}

function createPostCard(postObj) {

    let uctCommentTimeObj = new Date(postObj.uctDateTimeISO);
    let thisRegionStringDateTime = uctCommentTimeObj.toLocaleString();

    let mainDiv = document.createElement("div");
    mainDiv.classList.add("topic-name-wrapper");
    mainDiv.id = postObj._id;
    mainDiv.innerHTML = `
            <div class="topic-name">
                <p><strong>${postObj.username}</strong> commented on <time>${thisRegionStringDateTime}</time></p>
                <div class="post-content">
                    <p>${postObj.text}</p>
                </div>
            </div>`;
    return mainDiv;
}

function createPostCards(arrayOfPostObjects) {
    return arrayOfPostObjects.map(postObj => createPostCard(postObj));
}



//util
function formatDate(dateObj, toLocaleString) {
    if (toLocaleString === true) {
        return dateObj.toLocaleString();
    }
    let result = (
        [
            dateObj.getFullYear(),
            padTo2Digits(dateObj.getMonth() + 1),
            padTo2Digits(dateObj.getDate()),
        ].join('-') +
        ' ' +
        [
            padTo2Digits(dateObj.getHours()),
            padTo2Digits(dateObj.getMinutes()),
            padTo2Digits(dateObj.getSeconds()),
        ].join(':')
    );
    return result;
}

function padTo2Digits(num) {
    return num.toString().padStart(2, '0');
}

async function setCommentToDb(username, text, uctDateTimeISO, postId) {
    if (!isValid(username, text)) {
        throw new TypeError("All fields are mandatory.");
    }
    let responce = await fetch(urlComments, {
        method: "post",
        headers: { "content-type": "application/json" },
        body: JSON.stringify({ username, text, uctDateTimeISO, postId })
    });
    let comment = await responce.json();

    return comment;
}

async function getCommentsFromDb(commentId) {
    let responce = await fetch(urlComments);
    let commentsObj = await responce.json();

    let filteredCommentsArray = Object.values(commentsObj).filter(o => o.postId === commentId);
console.log(filteredCommentsArray);
    return filteredCommentsArray;
}
