const postsUrl = "http://localhost:3030/jsonstore/blog/posts/";
const commentsUrl = "http://localhost:3030/jsonstore/blog/comments/";
let allPosts = {};

function attachEvents() {
    document.getElementById("btnLoadPosts").addEventListener('click', onLoad);
    document.getElementById("btnViewPost").addEventListener('click', onView);
}

attachEvents();


async function getPostsIdAndTitle(url) {
    let response = await fetch(url);
    let data = await response.json();
    allPosts = JSON.parse(JSON.stringify(data));//to gain performance
    return Object.values(allPosts).map(p => obj = { id: p.id, title: p.title });
}

async function getCommentsOf(postId, url) {
    let response = await fetch(url);
    let data = await response.json();
    return Object.values(data).filter(c => c.postId === postId).map(c => obj = { id: c.id, text: c.text });
}

function createOption(value, text) {
    let option = document.createElement('option');
    option.value = value;
    option.textContent = text;
    return option;
}

async function onLoad() {
    let select = document.getElementById("posts");
    let titles = await getPostsIdAndTitle(postsUrl);
    let options = titles.map(t => createOption(t.id, t.title));
    select.replaceChildren(...options);
    //onView();
}

async function getArticle(url, id) {
    let response = await fetch(url + id);
    let data = await response.json();
    let obj = { title: data.title, text: data.body };
    return obj;
}

function generateArticle(article) {
    document.getElementById("post-title").textContent = article.title;
    document.getElementById("post-body").textContent = article.body;
}

function generateLi(id, text) {
    let li = document.createElement('li');
    li.id = id;
    li.textContent = text;
    return li;
}

async function onView() {
    let id = document.getElementById('posts').value;
    //let article = await getArticle(postsUrl,id);
    let article = allPosts[id];
    generateArticle(article);
    let comments = await getCommentsOf(id,commentsUrl);
    let lis = comments.map(c=>generateLi(c.id,c.text));
    document.getElementById("post-comments").replaceChildren(...lis);
}

