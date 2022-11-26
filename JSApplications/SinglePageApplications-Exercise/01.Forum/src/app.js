
import {loadHome } from "./home.js";
import {loadPost} from "./post.js";
import {homeSection, navEl } from "./vars.js";

homeSection.addEventListener('click', onTopicClick);
navEl.addEventListener('click',loadHome);

loadHome();

function onTopicClick(event) {
if (event.target.parentElement.parentElement.className !== "topic-name") return;
    loadPost(event);
}

 