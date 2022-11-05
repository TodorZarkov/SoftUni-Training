const postsUrl = "http://localhost:3030/jsonstore/blog/posts/";
const commentsUrl = "http://localhost:3030/jsonstore/blog/comments/";
let allPosts = {};

attachEvents();

function attachEvents() {
    document.getElementById("btnLoadPosts").addEventListener('click', onLoad);
    document.getElementById("btnViewPost").addEventListener('click', onView);
}

function generateArticle(title,body) {
    document.getElementById("post-title").textContent = title;
    document.getElementById("post-body").textContent = body;
}

function generateLi(id, text) {
    let li = document.createElement('li');
    li.id = id;
    li.textContent = text;
    return li;
}

function createOption(value, text) {
    let option = document.createElement('option');
    option.value = value;
    option.textContent = text;
    return option;
}


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

async function onView() {
    let postsEl = document.getElementById('posts');
    let id = postsEl.value;
    let artName = postsEl.options[postsEl.selectedIndex].text;
    //let article = await getArticle(postsUrl,id);
    let artText = Object.values(allPosts).find(t => t.title === artName).body;
    generateArticle(artName, artText);
    let comments = await getCommentsOf(id, commentsUrl);
    let lis = comments.map(c => generateLi(c.id, c.text));
    document.getElementById("post-comments").replaceChildren(...lis);
}

