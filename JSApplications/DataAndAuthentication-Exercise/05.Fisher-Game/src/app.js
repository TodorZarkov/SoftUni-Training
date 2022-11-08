const logoutUrl = "http://localhost:3030/users/logout";
const meUrl = "http://localhost:3030/users/me";
const catchesUrl = "http://localhost:3030/data/catches/";

registerListeners();


//control
function registerListeners() {
    window.addEventListener('load', onLoadPage);
    document.getElementById("logout").addEventListener('click', onLogout);
    document.querySelector(".load").addEventListener('click', onloadBtn);
    document.getElementById("home").addEventListener('click', () => window.location.assign("./index.html"));
    document.getElementById("addForm").addEventListener('submit', onAdd);
    document.getElementById("main").addEventListener('click', onUpdate);
    document.getElementById("main").addEventListener('click', onDelete);
}

async function onAdd(event) {
    event.preventDefault();
    let token = sessionStorage.getItem("accessToken");
    let formData = new FormData(event.target);
    let data = Object.fromEntries(formData);
    let newEntry;
    try {
        newEntry = await addCatch(token, data);
    } catch (error) {
        console.log(error);
        return;
    }
    event.target.reset();

}

async function onUpdate(event) {
    let btn = event.target;
    if (btn.nodeName !== 'BUTTON' || btn.textContent !== "Update") return;

    let token = sessionStorage.getItem("accessToken");
    let dataId = btn.getAttribute("data-id");

    let keys = ["angler", "weight", "species", "location", "bait", "captureTime"];
    let values = Array.from(btn.parentElement.getElementsByTagName("input")).map(i=>i.value);
    let data = {};
    for(let i =0;i<keys.length;i++){
        data[keys[i]] = values[i]
    }
    let updatedEntry;
    try {
        updatedEntry = await updateCatch(token, data, dataId);
    } catch (error) {
        console.log(error);
        return;
    }
}
async function onDelete(event) {
    let btn = event.target;
    if (btn.nodeName !== 'BUTTON' || btn.textContent !== "Delete") return;
    let token = sessionStorage.getItem("accessToken");
    let dataId = btn.getAttribute("data-id");
    try {
        await deleteCatch(token, dataId);
    } catch (error) {
        console.log(error);
        return;
    }
    btn.parentElement.remove();
}
async function onloadBtn(event) {
    event.preventDefault(); 
    let disabled = 'disabled';
    let token = sessionStorage.getItem("accessToken");
    let mainEl = document.getElementById('main');
    mainEl.style.border = "2px solid black";
    mainEl.innerHTML = `<legend>Catches</legend><div id="catches"></div>`;
    let cetchesDiv = document.getElementById("catches");
    let data = await getCatches();
    let userId = await getUserId(token);
    for (let entry of data) {
        if (userId === entry._ownerId) {
            disabled = '';
        }
        let fields = Object.entries(entry).filter(e => !(e[0].startsWith('_'))).map(e => e[1]);

        let card = createCatchCard(entry._id, disabled, fields);
        cetchesDiv.appendChild(card);
        disabled = 'disabled';
    }


}

async function onLogout() {
    const token = sessionStorage.getItem("accessToken");
    console.log(await logout(token));
    sessionStorage.removeItem("accessToken");
    window.location.replace("./index.html");
}

async function onLoadPage() {
    let user = {};
    const token = sessionStorage.getItem("accessToken");
    let divGuest = document.getElementById("guest");
    let divLogout = document.getElementById("user");
    let spanGest = document.querySelector(".email").children[0];
    let btnAdd = document.querySelector('.add');
    if (!token) {
        divLogout.remove();
        btnAdd.disabled = true;
    }
    else {
        try {
            let response = await fetch(meUrl, {
                headers: { "X-Authorization": token }
            });
            user = await response.json();
        } catch (error) {
            console.log(error);
        }
        divGuest.remove();
        spanGest.textContent = user.email;
        btnAdd.disabled = false;
    }

}

//view
function createCatchCard(dataId, disabled, fields) {
    let div = document.createElement('div');
    div.classList.add("catch");
    div.innerHTML =
        `
    <label>Angler</label>
    <input type="text" class="angler" value="${fields[0]}" ${disabled}>
    <label>Weight</label>
    <input type="text" class="weight" value="${fields[1]}" ${disabled}>
    <label>Species</label>
    <input type="text" class="species" value="${fields[2]}" ${disabled}>
    <label>Location</label>
    <input type="text" class="location" value="${fields[3]}" ${disabled}>
    <label>Bait</label>
    <input type="text" class="bait" value="${fields[4]}" ${disabled}>
    <label>Capture Time</label>
    <input type="number" class="captureTime" value="${fields[5]}" ${disabled}>
    <button class="update" data-id="${dataId}" ${disabled}>Update</button>
    <button class="delete" data-id="${dataId}" ${disabled}>Delete</button>
    `;
    return div;
}

//model
async function logout(token) {
    let result;
    let response = await fetch(logoutUrl, {
        method: "get",
        headers: { "X-Authorization": token }
    });
    if (response.status !== 204) {
        result = await response.json();
    }
    return result;
}

async function getCatches() {
    let response = await fetch(catchesUrl);
    let data = await response.json();
    return data
}
async function getUserId(token) {
    let user = null;
    try {
        let response = await fetch(meUrl, {
            headers: { "X-Authorization": token }
        });
        user = await response.json();
    } catch (error) {
        console.log(error);
    }
    return user._id;
}
async function addCatch(token, data) {
    let created;
    let response = await fetch(catchesUrl, {
        method: "post",
        headers: { "content-type": "applicaton/json", "X-Authorization": token },
        body: JSON.stringify(data)
    });
    created = response.json();
    if (response.ok === false || response.status !== 200) throw `${created}`;
    return created;
}
async function updateCatch(token, data, dataId) {
    let updated;
    let response = await fetch(catchesUrl + dataId, {
        method: "put",
        headers: { "content-type": "applicaton/json", "X-Authorization": token },
        body: JSON.stringify(data)
    });
    updated = response.json();
    if (response.ok === false || response.status !== 200) throw `${updated}`;
    return updated;
}
async function deleteCatch(token,dataId) {
    let deleted;
    let response = await fetch(catchesUrl + dataId, {
        method: "delete",
        headers: {"X-Authorization": token }
    });
    deleted = response.json();
    if (response.ok === false || response.status !== 200) throw `${deleted}`;
    return deleted;
}