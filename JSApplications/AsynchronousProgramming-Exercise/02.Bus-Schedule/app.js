function solve() {
    let stopId = 'depot';
    let currentStopName = '';
    let infoBox = document.getElementById('info').getElementsByTagName('span')[0];
    let departBtn = document.getElementById("depart");
    let arriveBtn = document.getElementById("arrive");

    function depart() {
        fetch(`http://localhost:3030/jsonstore/bus/schedule/${stopId}`)
        .then(onResponse)
        .then(onData)
        .catch(onError);
    }
    function onResponse(response){
        if(response.ok === false || response.status !== 200){
            throw "Error";
        }
        return response.json();
    }
    function onData(data){
        currentStopName = data.name;
        infoBox.textContent = `Next stop ${data.name}`;
        stopId = data.next;
        departBtn.disabled = true;
        arriveBtn.disabled = false;

    }
    function onError(e){
        infoBox.textContent = 'Error';
    }

    function arrive() {
        infoBox.textContent = `Arriving at ${currentStopName}`
        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();