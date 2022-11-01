async function lockedProfile() {
    const urlProfiles = "http://localhost:3030/jsonstore/advanced/profiles";
    let profiles = {};
    try {
        let response = await fetch(urlProfiles);
        if (response.ok === false || response.status !== 200) throw "Bad URI";
        profiles = await response.json();
    } catch (error) {
        onError(error);
    }

    let profilesData = Object.values(profiles);
    const containerProfiles = document.getElementById("main");
    profilesData.map(p=>createProfile(p)).forEach(p=>containerProfiles.appendChild(p));

    containerProfiles.addEventListener('click', hideShow);
}

function hideShow(event) {
    let btn = event.target;
    if(btn.nodeName !== 'BUTTON') return;
    let id = btn.id;
    let locked = document.getElementById(`radio-${id}`);
    console.log(locked);
    if(locked.checked === true) return;
    let hiddenFields = document.querySelector(`[myid=user-${id}-HiddenFields]`)
    if(btn.textContent === 'Show more'){
        hiddenFields.style.display = 'block';
        btn.textContent = 'Hide it';
    }
    else if(btn.textContent === 'Hide it'){
        hiddenFields.style.display = 'none';
        btn.textContent = 'Show more';
    }
    
    console.log(btn.id);
}

function onError(e) {
    console.log(e);
}


function createProfile(data) {
    let id = data._id;
    let username = data.username;
    let email = data.email;
    let age = data.age;
    let profileDiv = document.createElement('div');
    profileDiv.classList.add('profile');
    profileDiv.innerHTML =
    `<img src="./iconProfile2.png" class="userIcon" />
    <label>Lock</label>
    <input type="radio"  id="radio-${id}" name="user${id}Locked" value="lock" checked="true">
    <label>Unlock</label>
    <input type="radio" name="user${id}Locked" value="unlock"><br>
    <hr>
    <label>Username</label>
    <input type="text" name="user1Username" value="${username}" disabled readonly />
    <div id="user1HiddenFields" myid="user-${id}-HiddenFields" style="display:none;">
        <hr>
        <label>Email:</label>
        <input type="email" name="user1Email" value="${email}" disabled readonly />
        <label>Age:</label>
        <input type="email" name="user1Age" value="${age}" disabled readonly />
    </div>
    
    <button id="${id}">Show more</button>`;
    return profileDiv;
}
