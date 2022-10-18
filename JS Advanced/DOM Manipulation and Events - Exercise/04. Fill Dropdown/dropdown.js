function addItem() {
    let menu = document.getElementById("menu");
    let newItemText = document.getElementById("newItemText");
    let newItemValue = document.getElementById("newItemValue");

    let option = document.createElement('option');
    option.value = newItemValue.value;
    option.textContent = newItemText.value;
    menu.appendChild(option);
    newItemText.value = '';
    newItemValue.value = '';
}