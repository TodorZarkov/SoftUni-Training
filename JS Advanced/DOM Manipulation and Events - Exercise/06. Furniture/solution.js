function solve() {
  let generateBtn;
  let buyBtn;
  let btn = document.querySelectorAll('button');
  if (btn[0].textContent == 'Generate') {
    generateBtn = btn[0];
    buyBtn = btn[1];
  } else if (btn[1].textContent == 'Generate') {
    generateBtn = btn[1];
    buyBtn = btn[0];
  }
  generateBtn.addEventListener('click', generate);
  buyBtn.addEventListener('click', buy);
  let tBodyElement = document.querySelector('tbody');
  let inputArea = document.querySelectorAll('textarea')[0];
  let outputArea = document.querySelectorAll('textarea')[1];

  let rowsDB = [];


  function generate() {
    let furniture = JSON.parse(inputArea.value);
    for (let pieceOfFurniture of furniture) {
      let tRow = document.createElement('tr');

      let tDImage = document.createElement('td');
      let tDName = document.createElement('td');
      let tDPrice = document.createElement('td');
      let tDFactor = document.createElement('td');
      let tDCheckBox = document.createElement('td')
      tDImage.innerHTML = `<img src="${pieceOfFurniture.img}">`;
      tDName.innerHTML = `<p>${pieceOfFurniture.name}</p>`;
      tDPrice.innerHTML = `<p>${pieceOfFurniture.price}</p>`;
      tDFactor.innerHTML = `<p>${pieceOfFurniture.decFactor}</p>`;
      tDCheckBox.innerHTML = `<input type="checkbox"  />`;
      tRow.appendChild(tDImage);
      tRow.appendChild(tDName);
      tRow.appendChild(tDPrice);
      tRow.appendChild(tDFactor);
      tRow.appendChild(tDCheckBox);

      tBodyElement.appendChild(tRow);

      rowsDB.push([tDCheckBox.firstChild, pieceOfFurniture]);
    }
  }

  function buy() {
    let names = [];
    let totalPrice = 0;
    let avFactor = 0;
    let counter = 0;
    for (let row of rowsDB) {
      row[0].disabled = true;
      if (!row[0].checked) {
        continue;
      }
      names.push(row[1].name);
      totalPrice += Number(row[1].price);
      counter++;
      avFactor += Number(row[1].decFactor);
    }
    avFactor = avFactor / counter;

    let namesText = `Bought furniture: ${names.join(', ')}`;
    let totPriceText = `Total price: ${totalPrice.toFixed(2)}`
    let avFactorText = `Average decoration factor: ${avFactor}`

    let result = namesText + '\n' + totPriceText + '\n' + avFactorText;

    outputArea.value = result;

  }
}