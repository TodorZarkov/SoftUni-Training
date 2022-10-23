window.addEventListener("load", solve);

function solve() {
  let publishBtn = document.getElementById("form-btn");

  let ulOutputElement = document.getElementById("preview-list");

  let inputFirstNameEl = document.getElementById("first-name");
  let inputLastNameEl = document.getElementById("last-name");
  let inputAgeEl = document.getElementById("age");
  let inputTitleEl = document.getElementById("story-title");
  let inputGenreEl = document.getElementById("genre");//option
  let inputStoryEl = document.getElementById("story");//text area
  let inputs = Array.from(document.querySelectorAll("input"));
  inputs.pop();
  inputs.push(inputStoryEl);

  let globalEl = document.getElementById('side-wrapper')
  let btnSave = null;
  let btnDelete = null;
  let btnEdit = null;

  let storyData = [];


  publishBtn.addEventListener('click', (event) => {
    event.preventDefault();
    let hasEmpty = false;
    for (let input of inputs) {
      if (input.value == "") {///  TO DO WITH DIGITS
        hasEmpty = true;
        break;
      }
    }
    if (hasEmpty) return;

    let li = document.createElement('li');
    li.setAttribute('class', 'story-info');
    let article = document.createElement('article');
    let h4 = document.createElement('h4');
    h4.textContent = `Name: ${inputFirstNameEl.value} ${inputLastNameEl.value}`;
    let p1 = document.createElement('p');
    p1.textContent = `Age: ${inputAgeEl.value}`;
    let p2 = document.createElement('p');
    p2.textContent = `Title: ${inputTitleEl.value}`;
    let p3 = document.createElement('p');
    p3.textContent = `Genre: ${inputGenreEl.options[inputGenreEl.selectedIndex].text}`;
    let p4 = document.createElement('p');
    p4.textContent = `${inputStoryEl.value}`;

    article.appendChild(h4);
    article.appendChild(p1);
    article.appendChild(p2);
    article.appendChild(p3);
    article.appendChild(p4);

    li.appendChild(article);

    btnSave = document.createElement('button');
    btnSave.setAttribute('class', 'save-btn');
    btnSave.textContent = 'Save Story';
    li.appendChild(btnSave);

    btnEdit = document.createElement('button');
    btnEdit.setAttribute('class', 'edit-btn');
    btnEdit.textContent = 'Edit Story';
    li.appendChild(btnEdit);

    btnDelete = document.createElement('button');
    btnDelete.setAttribute('class', 'delete-btn');
    btnDelete.textContent = 'Delete Story';
    li.appendChild(btnDelete);

    ulOutputElement.appendChild(li);

    for (let input of inputs) {
      storyData.push(input.value);
      input.value = "";
    }
    console.log(storyData);


    publishBtn.disabled = true;
  });


  globalEl.addEventListener('click', (event) => {
    if (event.target == btnEdit) {
      for (let i = 0; i < storyData.length; i++) {
        inputs[i].value = storyData[i];
      }
      storyData = [];
      publishBtn.disabled = false;
      let toDelete = ulOutputElement.querySelector('li');
      toDelete.remove();
    }else if (event.target == btnDelete) {
      publishBtn.disabled = false;
      let toDelete = ulOutputElement.querySelector('li');
      toDelete.remove();
    }else if (event.target == btnSave) {
      let main =document.getElementById('main');
      let toDelete = Array.from(main.children);
      for (let child of toDelete) {
        child.remove();
      }
      let h1 = document.createElement('h1');
      h1.textContent = "Your scary story is saved!";
      main.appendChild(h1);
    }
  })

}
