function getInfo() {
    let stopId = document.getElementById('stopId').value;

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId}`)
        .then(onResponse)
        .then(onData)
        .catch(onError);


    function onResponse(response) {
        if (response.ok === false || response.status === 204 || stopId === '') {
            throw "Error";
        }
        return response.json();
    }

    function onData(data) {
        let stopNameDiv = document.getElementById("stopName");
        stopNameDiv.textContent = data.name;
        let bussesUl = document.getElementById("buses");
        bussesUl.innerHTML = '';

        for (let key in data.buses) {
            let li = document.createElement('li');
            let innerText = `Bus ${key} arrives in ${data.buses[key]} minutes`;
            li.textContent = innerText;
            bussesUl.appendChild(li);
        }
        console.log(data);
        console.log(data.buses);

    }

    function onError(e) {
        let stopNameDiv = document.getElementById("stopName");
        stopNameDiv.textContent = "Error";
        let bussesUl = document.getElementById("buses");
        bussesUl.innerHTML = '';
    }

}