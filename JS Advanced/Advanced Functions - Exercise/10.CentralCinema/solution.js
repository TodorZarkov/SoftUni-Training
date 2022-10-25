function solve() {

    let form = document.getElementById('add-new');
    form.addEventListener('submit', (event) => {
        event.preventDefault();
        let inputs = getInput.call(event.target);
        inputs = validateInputs(inputs);
        if (inputs === null) return;

        event.target.reset();
        let screen = document.getElementById('movies').
        getElementsByTagName('ul')[0];
        addScreen.call(screen,inputs);
    });

    let onScreen = document.getElementById('movies');
    onScreen.addEventListener('click',(event)=>{
        if(event.target.tagName !== 'BUTTON') return;
        let archive = document.getElementById('archive').getElementsByTagName('ul')[0];
        
        addArchive.call(archive,event.target.parentNode.parentNode);
    });

    let archive= document.getElementById('archive');
    archive.addEventListener('click',(event)=>{
        if(event.target.tagName !== 'BUTTON') return;
        if(event.target.textContent === 'Delete'){
            event.target.parentNode.remove();
        }
        if(event.target.textContent === 'Clear'){
            let ulEl = event.target.parentNode.getElementsByTagName('ul')[0];
            console.log(ulEl);
            ulEl.innerHTML = '';
        }
    })

    function getInput() {
        result = [];
        for (let i = 0; i < this.elements.length; i++) {
            if (this.elements[i].tagName === 'BUTTON') {
                continue;
            }
            result.push(this.elements[i].value);
        }
        return result;
    }

    function validateInputs(inputs) {
        if (inputs[0] === '' || inputs[1] === '' || inputs[2].match(/^[\d]+\.{0,1}[\d]*$/) === null) {
            return null;
        }
        return inputs;
    }

    function addScreen(inputs) {
        let li = document.createElement('li');
        li.innerHTML =`<span></span>
            <strong>Hall: </strong>
            <div>
                <strong></strong>
                <input placeholder="Tickets Sold">
                <button>Archive</button>
            </div>`
        li.children[0].textContent = inputs[0];
        li.children[1].textContent += inputs[1];
        li.children[2].children[0].textContent = inputs[2];
        this.appendChild(li);

    }

    function addArchive(screenEntry){
        let quontityEl = screenEntry.getElementsByTagName('div')[0].getElementsByTagName('input')[0];
        if(quontityEl.value === '' || quontityEl.value.match(/^[\d]+$/) === null) return;

        let toArchive = screenEntry.cloneNode(true);
        screenEntry.remove();

        let priceEl = toArchive.getElementsByTagName('div')[0].getElementsByTagName('strong')[0];
        quontityEl = toArchive.getElementsByTagName('div')[0].getElementsByTagName('input')[0];
        let divEl = toArchive.getElementsByTagName('div')[0];
        divEl.remove();
        
        let total = Number(priceEl.textContent)*Number(quontityEl.value);

        let archBtn = document.createElement('button');
        archBtn.textContent = 'Delete';
        toArchive.appendChild(archBtn);

        let totalEl = toArchive.getElementsByTagName('strong')[0];
        totalEl.textContent = `Total amount: ${total.toFixed(2)}`
        
        this.appendChild(toArchive);
    }

}