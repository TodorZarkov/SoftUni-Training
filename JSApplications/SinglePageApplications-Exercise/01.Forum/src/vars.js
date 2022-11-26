export let postSection = document.getElementById("post");
export let homeSection = document.getElementById("home");
export let formHomeEl = homeSection.querySelector('form');
export let navEl = document.querySelector("nav");
export let HomeLink = navEl.getElementsByTagName("a")[0];
export let themeName = document.querySelector(".theme-name");
export let postHeader = document.querySelector(".header");
export let answerForm =  document.querySelector(".answer").querySelector("form");
export let userCommentsDiv = document.getElementById("user-comment");
export let topicContainerDiv = document.querySelector(".topic-title");

export const loadingBoxes = {
    title: "loading...",
    userName: "loading...",
    text: "loading...",
    eventTime: "loading...",
    _id: "loading"
};