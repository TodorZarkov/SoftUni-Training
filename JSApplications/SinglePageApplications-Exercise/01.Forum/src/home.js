import { homeSection, postSection, topicContainerDiv } from "./vars.js";

homeSection.addEventListener('submit', onSubmit);

const postsUrl = "http://localhost:3030/jsonstore/collections/myboard/posts";


//control
export async function loadHome() {
    postSection.style.display = "none";
    homeSection.style.display = "block";
    homeSection.style.opacity = "0.2";
    let allTopics = await getAllTopicsFromDb();
    let topicCards = createTopicCards(allTopics);
    homeSection.style.opacity = "1";
    topicContainerDiv.replaceChildren(topicCards);

}

async function onSubmit(event) {
    let clickDateTime = Date.now();

    event.preventDefault();
    let target = event.target;
    let formData = new FormData(target);
    let btn = event.submitter;
    if (btn.textContent === "Post") {
        let title = formData.get("topicName");
        let userName = formData.get("username");
        let text = formData.get("postText")
        clickDateTime = (new Date(clickDateTime)).toISOString();

        try {
            homeSection.style.opacity = "0.2";
            let id = await setTopicToDb(title, userName, text, clickDateTime);
            let topic = await getTopicFromDb(id);
            homeSection.style.opacity = "1";
            let topicDiv = createTopicCard(topic);
            topicContainerDiv.prepend(topicDiv);
        } catch (error) {
            window.alert(error.message);
        } finally{
            homeSection.style.opacity = "1";
            target.reset();
        }

    }
    else if(btn.textContent === "Cancel"){
        target.reset();
    }
}



//dom
function createTopicCard(topicObj) {
    let maingDiv = document.createElement("div");
    maingDiv.classList.add("topic-container");

    let eventTime = Date.parse(topicObj.eventTime) - (new Date()).getTimezoneOffset()*60000;
    let currentDateTime = new Date(eventTime);

    maingDiv.innerHTML = `
        <div class="topic-name-wrapper">
            <div class="topic-name">
                <a id="${topicObj._id}" href="javascript:void(0)" class="normal">
                    <h2>${topicObj.title}</h2>
                </a>
                <div class="columns">
                    <div>
                        <p>Date: <time>${currentDateTime.toISOString()}</time></p>
                        <div class="nick-name">
                            <p>Username: <span>${topicObj.userName}</span></p>
                        </div>
                    </div>
    
    
                </div>
            </div>
        </div>`;
    return maingDiv;
}

function createTopicCards(allTopicsArrayOfObjects) {
    let docFragment = document.createDocumentFragment();
    let allTopicCards = allTopicsArrayOfObjects.map(t => createTopicCard(t));
    docFragment.replaceChildren(...allTopicCards);
    return docFragment;
}


//model
export function isValid(...textFields) {
    for (let tf of textFields) {
        if (!tf) {
            return false;
        }
    }

    return true;
}

async function setTopicToDb(title, username, content, eventTime) {
    if (!isValid(title, username, content)) {
        throw new TypeError("All the 'New Topic' fields are mandatory.");
    }
    try {
        let topic = { title, username, content, eventTime };
        let responce = await fetch(postsUrl, {
            method: "post",
            headers: { "content-type": "application/json" },
            body: JSON.stringify(topic)
        });
        let createdTopic = await responce.json();
        return createdTopic._id;
    } catch (error) {
        throw error;
    }
}

export async function getTopicFromDb(id) {
    // let topicUrl = postsUrl + "/" + id;
    // let responce = await fetch(topicUrl);
    // let topic = await responce.json();
    let topic = (await getAllTopicsFromDb()).find(t=>t._id === id);
    return topic;
}

async function getAllTopicsFromDb() {
    let responce = await fetch(postsUrl);
    let topics = await responce.json();
    return Object.values(topics).reverse();
}