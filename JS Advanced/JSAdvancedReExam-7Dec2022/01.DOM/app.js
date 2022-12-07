window.addEventListener('load', solve);

function solve() {
    document.querySelector("form").addEventListener("submit", (event) => event.preventDefault());
    document.getElementById("next-btn").addEventListener("click", onPublish);
    document.getElementById("info-reservations").addEventListener("click", midClick);
    document.getElementById("confirm-reservations").addEventListener("click", sideClick);

    let dataMap = new Map();


    function onPublish(event) {
        event.preventDefault();
        let data = getForm();
        if (hasEmpty(data)) return;
        let li = createInfoLi(data);
        appendInfo(li);
        dataMap.set(li, data)
        clearForm();
        disableForm();
    }


    function midClick(event) {
        let btn = event.target;
        if (btn.nodeName !== "BUTTON") return;
        if (btn.textContent === "Edit") {
            onEdit(event);
        } else if (btn.textContent === "Continue") {
            onContinue(event);
        }
    }

    function sideClick(event) {
        let btn = event.target;
        if (btn.nodeName !== "BUTTON") return;
        if (btn.textContent === "Confirm") {
            onConfirm(event);
        } else if (btn.textContent === "Cancel") {
            onCancel(event);
        }
    }


    function onConfirm(event) {
        let reservationLi = event.target.parentElement;
        dataMap.delete(reservationLi);
        reservationLi.remove();
        enableForm();
        let h1 = document.getElementById("verification");
        
        h1.classList.add("reservation-confirmed");
        h1.textContent = "Confirmed."

    }

    function onCancel(event) {
        let reservationLi = event.target.parentElement;
        dataMap.delete(reservationLi);
        reservationLi.remove();
        enableForm();
        let h1 = document.getElementById("verification");
        
        h1.classList.add("reservation-cancelled");
        h1.textContent = "Cancelled."

    }




    function onEdit(event) {
        let li = event.target.parentElement;
        let data = dataMap.get(li);
        li.remove();
        setForm(data)
        enableForm();
    }

    function onContinue(event) {
        let reservationLi = event.target.parentElement;
        let data = dataMap.get(reservationLi);
        reservationLi.remove();
        let confirmLi = createConfirmLi(data);
        appendConfirm(confirmLi);
    }




    function createInfoLi(data) {
        let li = document.createElement("li");
        li.classList.add("reservation-content");

        li.innerHTML = `
            <article>
                <h3>Name: ${data[0]} ${data[1]}</h3>
                <p>From date: ${data[2]}</p>
                <p>To date: ${data[3]}</p>
                <p>For ${data[4]} people</p>
            </article>
            <button class="edit-btn">Edit</button>
            <button class="continue-btn">Continue</button>`;

        return li;
    }

    function appendInfo(li) {
        document.querySelector(".info-list").appendChild(li);
    }

    function createConfirmLi(data) {
        let li = document.createElement("li");
        li.classList.add("reservation-content");

        li.innerHTML = `
            <article>
                <h3>Name: ${data[0]} ${data[1]}</h3>
                <p>From date: ${data[2]}</p>
                <p>To date: ${data[3]}</p>
                <p>For ${data[4]} people</p>
            </article>
            <button class="confirm-btn">Confirm</button>
            <button class="cancel-btn">Cancel</button>`;

        return li;
    }

    function appendConfirm(li) {
        document.querySelector(".confirm-list").appendChild(li);
    }





    function getForm() {
        let fieldElements = Array.from(document.querySelectorAll("form input"));
        let fields = fieldElements.map(e => e.value);
        return fields;
    }

    function setForm(data) {
        let fieldElements = Array.from(document.querySelectorAll("form input"));
        for (let i = 0; i < fieldElements.length; i++) {
            fieldElements[i].value = data[i];
        }
    }

    function clearForm() {
        document.querySelector('form').reset();
        //setForm(["", "", "", "", ""]);
    }

    function hasEmpty(data) {
        let difference = new Date(data[3]) - new Date(data[2]);

        if (difference < 0) return true;

        for (let i = 0; i < data.length; i++) {
            if (data[i] === "") {
                return true;
            }
        }
        return false;
    }

    function disableForm() {
        document.getElementById("next-btn").disabled = 'true';
    }

    function enableForm() {
        document.getElementById("next-btn").disabled = '';
    }
}





