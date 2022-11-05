let url = "http://localhost:3030/jsonstore/phonebook";

attachEvents();

function attachEvents() {
    document.getElementById("btnLoad").addEventListener('click', onLoad);
    document.getElementById("btnCreate").addEventListener('click', onCreate);
    document.querySelector('body').addEventListener('click', onDelete);
}

async function onDelete(event) {
    let btn = event.target;
    if (btn.nodeName !== 'BUTTON') return;
    if (btn.textContent !== 'Delete') return;
    let id = btn.parentElement.id;
    await deleteEntry(id);
    btn.parentElement.remove();
}

async function onCreate() {
    let person = document.getElementById("person");
    let phone = document.getElementById("phone");
    await setEntry(person.value, phone.value);
    person.value = '';
    phone.value = '';
    onLoad();

}

async function onLoad() {
    let ulEl = document.getElementById("phonebook");
    
        let entries = await getEntryes();
        ulEl.replaceChildren(...entries.map(generateLi));
    
}

function generateLi(entry) {
    let li = document.createElement('li');
    li.id = entry._id;
    li.textContent = entry.person + ': ' + entry.phone;
    let delBtn = document.createElement('button');
    delBtn.textContent = 'Delete';
    li.appendChild(delBtn);
    return li;
}


async function getEntryes() {
    let response = await fetch(url);
    if (response.ok == false || response.status !== 200) throw "Error on Retrieving";
    let data = await response.json();
    return Object.values(data);
}

async function setEntry(person, phone) {
    let response = await fetch(url, {
        method: 'post',
        headers: { "content-type": "application/json" },
        body: JSON.stringify({ person, phone })
    });
    if (response.ok == false || response.status !== 200) throw "Error on Creating";
    let data = await response.json();
    let id = data._id;
    if (id === null || id === {} || id === '' || id === undefined) throw "Server Error - NO ID";
    return id;
}

async function deleteEntry(id) {
    let response = await fetch(url + `/${id}`, {
        method: 'delete'
    });
    if (response.ok == false || response.status !== 200) throw "Error on Deleting";//is it 204?
    let data = await response.json();
    let deletedId = data._id;
    if (deletedId === null || deletedId === {} || deletedId === '' || deletedId === undefined) throw "Error on Deleting - NO ID";
    return deletedId;
}