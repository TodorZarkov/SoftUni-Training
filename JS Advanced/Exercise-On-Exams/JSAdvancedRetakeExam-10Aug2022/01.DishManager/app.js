window.addEventListener("load", solve);

function solve() {

  let dataStorage = new Map();

  document.querySelector("form").addEventListener('submit',(event) => event.preventDefault());

  document.getElementById("form-btn").addEventListener("click", onFormSubmit);

  document.getElementById("side-wrapper").addEventListener("click", onSideClick);



  function onSideClick(event) {
    let btn = event.target;
    if(btn.nodeName !== "BUTTON") return;
    if(btn.textContent === "Edit") {
      let li = btn.parentElement;
      onEdit(li);
    } else if(btn.textContent === "Mark as complete") {
      let li = btn.parentElement;
      onComplete(li);
    } else if(btn.textContent === "Clear") {
      onClear();
    }


  }

  function onFormSubmit() {
    let data = getForm();
    if (hasEmpty(data)) return;
    clearForm();
    let li = createLi(data);
    dataStorage.set(li, data);
    appendProgress(li);
    increaseProgress();
  }


  function onEdit(li) {
    let data = dataStorage.get(li);
    setForm(data);
    decreaseProgress();
    dataStorage.delete(li);
    li.remove();
  }


  function onComplete(li) {
    dataStorage.delete(li);
    removeButtons(li);
    decreaseProgress();
    appendFinished(li);
  }

  function onClear() {
    document.getElementById("finished").innerHTML = "";
  }


  function getForm() {
    const formEl = document.querySelector("form");
    let fieldElements = Array.from(formEl.querySelectorAll("[name]"));
    let fields = fieldElements.map(f => f.value);
    fields.push(document.getElementById("genderSelect").value);
    return fields;
  }

  function clearForm() {
    const formEl = document.querySelector("form");
    formEl.reset();
  }


  function createLi(data) {
    let description = data[3].trimEnd();
    let li = document.createElement("li");
    li.classList.add("each-line");
    li.innerHTML = `
          <article>
            <h4>${data[0]} ${data[1]}</h4>
            <p>${data[4]}, ${data[2]}</p>
            <p>Dish description: ${description}</p>
          </article>
          <button class="edit-btn">Edit</button>
          <button class="complete-btn">Mark as complete</button>
    `;
    return li;
  }


  function hasEmpty(data) {
    for(let i = 0; i < data.length-1;i++) {
      if(data[i] === "") {
        return true;
      }
    }
    return false;
  }


  function setForm(data) {
    const formEl = document.querySelector("form");
    let fieldElements = Array.from(formEl.querySelectorAll("[name]"));
    for (let i = 0; i < data.length - 1; i++) {
      fieldElements[i].value = data[i];
    }

    document.getElementById("genderSelect").value = data[4];
  }

  function appendProgress(li) {
    document.getElementById("in-progress").appendChild(li);
  }

  function removeButtons(li) {
    let buttons = Array.from(li.querySelectorAll("button"));
    buttons.forEach(b => b.remove());
  }

  function appendFinished(li) {
    document.getElementById("finished").appendChild(li);
  }

  function increaseProgress() {
    let counterEl = document.getElementById("progress-count");
    let counter = Number(counterEl.textContent);
    counter++;
    counterEl.textContent = `${counter}`;
  }

  function decreaseProgress() {
    let counterEl = document.getElementById("progress-count");
    let counter = Number(counterEl.textContent);
    counter--;
    counterEl.textContent = `${counter}`;
  }
}
