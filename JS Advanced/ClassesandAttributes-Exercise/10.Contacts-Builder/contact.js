class Contact {

    constructor(firstName, lastName, phone, email) {
        //TO DO Set parameters validatoin -the count of parameters and the values!
        //DOM Elements
        this._article = document.createElement('article');
        this._divFirst = document.createElement('div');
        this._divSecond = document.createElement('div');
        this._spanFirst = document.createElement('span');
        this._spanSecond = document.createElement('span');
        this._btnInfo = document.createElement('button');

        this.online = false;

        this._firstName = firstName;
        this._lastName = lastName;
        this._phone = phone;
        this._email = email;
    }


    get online() {
        return this._online;
    }
    set online(value) {
        if (typeof value !== "boolean") throw "Online value must be boolean."
        if (value) {
            this._divFirst.className = "title online"
        }
        else {
            this._divFirst.className = "title"
        }

    }

    render(id) {
        this._divFirst.classList.add("title");
        this._divFirst.textContent += this._firstName + " " + this._lastName;
        this._btnInfo.innerHTML = "&#8505;";
        this._btnInfo.addEventListener('click',this._togleInfo.bind(this));

        this._divSecond.classList.add("info");
        this._divSecond.style.display = 'none';
        this._spanFirst.innerHTML += "&phone;";
        this._spanFirst.textContent += " " + `${this._phone}`;
        this._spanSecond.innerHTML += "&#9993;";
        this._spanSecond.textContent += " " + `${this._email}`;

        this._generateContactStructure();
        document.getElementById(id).appendChild(this._article);

    }

    _generateContactStructure() {
        this._divFirst.appendChild(this._btnInfo);
        this._divSecond.appendChild(this._spanFirst);
        this._divSecond.appendChild(this._spanSecond);
        this._article.appendChild(this._divFirst);
        this._article.appendChild(this._divSecond);

    }


    _togleInfo() {
        console.log("in _togleInfo func");
        console.log(this);
        if (this._divSecond.style.display === "none") {
            this._divSecond.style.display = "block";
        }
        else {
            this._divSecond.style.display = "none";
        }

    }
}

let contacts = [
    new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
    new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
    new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
];
contacts.forEach(c => c.render('main'));

// After 1 second, change the online status to true
setTimeout(() => contacts[1].online = true, 2000);

let c = new Contact("I an", "I anov", "0888 123 456", "i.ivanov@gmail.com");
c.render('main');


