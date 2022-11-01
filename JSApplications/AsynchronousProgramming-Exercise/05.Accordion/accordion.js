solution();


async function solution() {
    const uriTitles = 'http://localhost:3030/jsonstore/advanced/articles/list';

    let response = await fetch(uriTitles);
    let titles = await response.json();
    const main = document.getElementById("main");
    titles.map(t => loadTitle(t._id, t.title)).forEach(div => main.appendChild(div));
    console.log(titles);

    main.addEventListener('click',showHide);
}

async function showHide(event) {
    let btn = event.target;
    if(btn.nodeName !== 'BUTTON') return;
    btn.disabled = true;
    let id = btn.id;
    const uriArticle = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;
    if(btn.textContent === 'More'){
        let response = await fetch(uriArticle);
        let data = await response.json();
        let textContent = data.content;
        let toAppend = btn.parentNode.parentNode;
        let div = more(textContent,id);
        toAppend.appendChild(div);
        div.style.display = 'block';
        btn.textContent = 'Less';
    }
    else if(btn.textContent === 'Less'){
        document.getElementById(`extra-${id}`).remove();
        btn.textContent = 'More'
    }
    btn.disabled = false;
}

function more(content,id) {
    let div = document.createElement('div');
    div.classList.add('extra');
    div.id = `extra-${id}`;
    let p = document.createElement('p');
    p.textContent = content;
    div.appendChild(p);
    return div;
}

function loadTitle(id, title) {
    let div = document.createElement('div');
    div.classList.add("accordion");
    div.innerHTML =
        `<div class="head">
        <span>${title}</span>
        <button class="button" id="${id}">More</button>
        </div>`;
    return div;
}
