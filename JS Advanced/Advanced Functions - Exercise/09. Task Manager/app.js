function solve() {
    let addBtn = document.getElementById('add');
    let wrapper = document.querySelector('.wrapper');


    let toAdd = addBtn.parentElement;
    let open = document.getElementsByTagName('section')[1].children[1];
    let inProgress = document.getElementsByTagName('section')[2].children[1];
    let completed = document.getElementsByTagName('section')[3].children[1];

    let currentData = {
        task: '',
        description: '',
        date: ''
    };

    addBtn.addEventListener('click', (event) => {
        event.preventDefault();
        updateCurrDataFrom(toAdd);
        if (!isValidData()) {
            return;
        }
        appendOpenWithCurrentData();
    })

    wrapper.addEventListener('click',remove);
    wrapper.addEventListener('click',(event)=>{
        if(event.target.className !== 'green'){
            return;
        }
        updateCurrDataFrom(event.target.parentElement.parentElement);
        event.target.parentElement.parentElement.remove();
        appendInProgressWithCurrentData();

    });
    wrapper.addEventListener('click',(event)=>{
        if(event.target.className !== 'orange'){
            return;
        }
        updateCurrDataFrom(event.target.parentElement.parentElement);
        event.target.parentElement.parentElement.remove();
        appendCompletedWithCurrentData();

    })




    function appendCompletedWithCurrentData() {
        article = document.createElement('article');
        article.innerHTML =
        `<h3>${currentData.task}</h3>
        <p>Description: ${currentData.description}</p>
        <p>Due Date: ${currentData.date}</p>`
        completed.appendChild(article);
    }



    function appendInProgressWithCurrentData() {
        article = document.createElement('article');
        article.innerHTML =
        `<h3>${currentData.task}</h3>
        <p>Description: ${currentData.description}</p>
        <p>Due Date: ${currentData.date}</p>
        <div class="flex">
            <button class="red">Delete</button>
            <button class="orange">Finish</button>
        </div>`
        inProgress.appendChild(article);
    }


    function remove(event){
        if(event.target.className !== 'red'){
            return;
        }
        event.target.parentElement.parentElement.remove();
    }



    function appendOpenWithCurrentData() {
        article = document.createElement('article');
        article.innerHTML =
        `<h3>${currentData.task}</h3>
        <p>Description: ${currentData.description}</p>
        <p>Due Date: ${currentData.date}</p>
        <div class="flex">
            <button class="green">Start</button>
            <button class="red">Delete</button>
        </div>`
        open.appendChild(article);
    }

    function isValidData() {
        if (currentData.task === '' ||
            currentData.description === '' ||
            currentData.date === '') {
            return false;
        }
        return true;
    }

    function updateCurrDataFrom(element) {
        if (element.tagName === 'FORM') {
            currentData.task = document.getElementById('task').value;
            currentData.description = document.getElementById('description').value;
            currentData.date = document.getElementById('date').value;
            
            
        } else if (element.tagName === 'ARTICLE') {
            currentData.task = element.children[0].textContent;
            currentData.description = element.children[1].textContent.slice(13);
            currentData.date = element.children[2].textContent.slice(10);
            
        }
    }



}
