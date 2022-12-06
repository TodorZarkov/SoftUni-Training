window.addEventListener("load", solve);

function solve() {
  document.querySelector("form").addEventListener("submit", (event) => event.preventDefault());
  document.getElementById("publish").addEventListener("click", onPublish);
  document.querySelector(".table-wrapper").addEventListener("click", sideClick);

  let dataMap = new Map();


  function onPublish(event) {
    event.preventDefault();
    let data = getForm();
    if(hasEmpty(data)) return;
    let tr = createTr(data);
    appendTr(tr);
    dataMap.set(tr, data)
    clearForm();
  }

  function sideClick(event) {
    let btn = event.target;
    if (btn.nodeName !== "BUTTON") return;
    if (btn.textContent === "Edit") {
      onEdit(event);
    } else if (btn.textContent === "Sell") {
      onSell(event);
    }
  }

  function onEdit(event) {
    let tr = event.target.parentElement.parentElement;
    let data = dataMap.get(tr);
    tr.remove();
    setForm(data)
  }

  function onSell(event) {
    let tr = event.target.parentElement.parentElement;
    let data = dataMap.get(tr);
    tr.remove();
    let li = createLi(data);
    appendLi(li);
    updataTotal(tr);
  }



  function getForm() {
    let fieldElements = Array.from(document.querySelectorAll("form input"));
    let fields = fieldElements.map(e => e.value);
    fields.push(document.getElementById("fuel").value);
    return fields;
  }

  function setForm(data) {
    let fieldElements = Array.from(document.querySelectorAll("form input"));
    for (let i = 0; i < fieldElements.length; i++) {
      fieldElements[i].value = data[i];
    }
    document.getElementById("fuel").value = data[5];
  }
  
  function clearForm() {
    //document.querySelector('form').reset();
    setForm(["","","","","",""]);
  }



  function createTr(data) {
    let tr = document.createElement('tr');
    tr.classList.add("row");
    tr.innerHTML = `<td>${data[0]}</td>
                    <td>${data[1]}</td>
                    <td>${data[2]}</td>
                    <td>${data[5]}</td>
                    <td>${data[3]}</td>
                    <td>${data[4]}</td>
                    <td>
                      <button class="action-btn edit">Edit</button>
                      <button class="action-btn sell">Sell</button>
                    </td>`;
    return tr;
  }

  function createLi(data) {
    let li = document.createElement('li');
    li.classList.add("each-list");

    let difference = Number(data[4]) - Number(data[3])

    li.innerHTML = `<span>${data[0]} ${data[1]}</span>
                    <span>${data[2]}</span>
                    <span>${difference}</span>`;
    return li;
  }



  function appendLi(li) {
    document.getElementById("cars-list").appendChild(li);
  }

  function appendTr(tr) {
    document.getElementById("table-body").appendChild(tr);
  }


  
  function updataTotal(tr) {
    let totalElement = document.getElementById("profit");
    let prevTotal = Number(totalElement.textContent);
    data = dataMap.get(tr);
    let difference = Number(data[4]) - Number(data[3])
    let newTotal = (prevTotal + difference).toFixed(2);

    totalElement.textContent = newTotal;

  }

  function hasEmpty(data) {
    let difference = Number(data[4]) - Number(data[3])
    if(difference < 0) return true;
    
    for(let i = 0; i < data.length;i++) {
      if(data[i] === "") {
        return true;
      }
    }
    return false;
  }
}
