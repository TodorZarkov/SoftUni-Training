attachEvents();

async function attachEvents() {
    let btn = document.getElementById("submit");
    btn.addEventListener('click', getWeather);
}

async function getWeather() {
    try {
        let locations = [];
        let txtBox = document.getElementById("location");

        let locationsResponse = await fetch('http://localhost:3030/jsonstore/forecaster/locations/');
        if (locationsResponse.ok === false || locationsResponse.status !== 200) throw "Bad REST1";
        locations = await locationsResponse.json();

        let location = locations.find(l => l.name === txtBox.value);
        if (location === undefined) throw "City not found in DB";

        let todayResponse =
            await fetch(`http://localhost:3030/jsonstore/forecaster/today/${location.code}`);
        if (todayResponse.ok === false || todayResponse.status !== 200) throw "Bad REST2";
        let today = await todayResponse.json();

        let upcomingResponse =
            await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${location.code}`);
        if (upcomingResponse.ok === false || upcomingResponse.status !== 200) throw "Bad REST3";
        let upcoming = await upcomingResponse.json();

        generateHtmlToday(today);
        generateHtmlUpcoming(upcoming);

    } catch (error) {
        onError(error);
    }
}

function generateHtmlToday(today) {
    let currentDiv = document.getElementById("current");
    currentDiv.children[1] !== undefined ? currentDiv.children[1].remove() : true;

    let innerHtmlCurrent =
        `<span class="conditoin symbol">${conditionToSymbol(today.forecast.condition)}</span>
            <span class="condition">
                <span class="forecast-data">${today.name}</span>
                <span class="forecast-data">${today.forecast.low}&#176/${today.forecast.high}&#176</span>
                <span class="forecast-data">${today.forecast.condition}</span>
            </span>`;
    let toFillDiv = document.createElement('div');
    toFillDiv.setAttribute('class', 'forecasts');
    toFillDiv.innerHTML = innerHtmlCurrent;
    currentDiv.appendChild(toFillDiv);
    document.getElementById("forecast").style.display = 'block';


}

function generateHtmlUpcoming(upcoming) {
    let upcomingDiv = document.getElementById("upcoming");
    upcomingDiv.children[1] !== undefined ? upcomingDiv.children[1].remove() : true;

    let toFillDiv = document.createElement('div');
    toFillDiv.setAttribute('class', 'forecast-info');
    console.log(upcoming.forecast);
    for (let f of upcoming.forecast) {
        let innerHtmlUpcoming =
            `<span class="upcoming">
            <span class="symbol">${conditionToSymbol(f.condition)}</span>
            <span class="forecast-data">${f.low}&#176/${f.high}&#176</span>
            <span class="forecast-data">${f.condition}</span>
        </span>`;
        toFillDiv.innerHTML += innerHtmlUpcoming;
    }
    upcomingDiv.appendChild(toFillDiv);
}

function onError(e) {
    let currentDiv = document.getElementById("current");
    currentDiv.children[1] !== undefined ? currentDiv.children[1].remove() : true;

    let upcomingDiv = document.getElementById("upcoming");
    upcomingDiv.children[1] !== undefined ? upcomingDiv.children[1].remove() : true;

    let errorDiv = document.createElement('div');
    errorDiv.textContent = 'Error';
    currentDiv.appendChild(errorDiv);
    document.getElementById("forecast").style.display = 'block';
}

function conditionToSymbol(condition) {
    let weatherSymbol = {
        Sunny: '&#x2600',               // ☀
        ['Partly sunny']: '&#x26C5',    // ⛅
        Overcast: '&#x2601',            // ☁
        Rain: '&#x2614',                // ☂
    }
    return weatherSymbol[condition];
}