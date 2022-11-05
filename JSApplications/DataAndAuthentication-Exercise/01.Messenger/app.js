let urlMsgs = "http://localhost:3030/jsonstore/messenger";
function attachEvents() {
    document.getElementById("submit").addEventListener('click', onSubmit);
    document.getElementById("refresh").addEventListener('click', onRefresh);
}

attachEvents();

function onSubmit() {
    let author = document.querySelector('[name="author"]').value;
    let content = document.querySelector('[name="content"]').value;
    setMessage(urlMsgs, { author, content });
}

async function onRefresh() {
    let msgEl = document.getElementById("messages");
    msgEl.value = '';
    let msgs = (await getMessages(urlMsgs)).map(msg =>msg.author + ': ' + msg.content);
    let msg = msgs.join('\n');
    msgEl.value = msg;
}


async function getMessages(urlMsgs) {
    let response = await fetch(urlMsgs);
    if (response.ok === false || response.status !== 200) throw "Error on Reading";
    let data = await response.json();
    return Object.entries(data).map(e => obj = { id: e[0], author: e[1].author, content: e[1].content });
}

async function setMessage(urlMsgs, msg) {
    let response = await fetch(urlMsgs, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(msg)
    });
    if (response.ok === false || response.status !== 200) throw "Error on Writing";
    return response.json();
}