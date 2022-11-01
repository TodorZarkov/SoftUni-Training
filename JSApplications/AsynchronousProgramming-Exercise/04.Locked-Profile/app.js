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

    const containerProfiles = document.getElementById("main");
    for(let profile in profiles){
        
    }
}

function onError(e) {
    console.log(e);
}

