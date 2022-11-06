class Student {
    firstName;
    lastName;
    facultyNumber;
    grade;
    _id;
    constructor(firstName, lastName, facultyNumber, grade) {
        this._firstName = firstName,
            this._lastName = lastName,
            this._facultyNumber = facultyNumber,
            this._grade = grade
    }

    get _firstName() {
        return this.firstName;
    }
    set _firstName(value) {
        if (/^\s+$/.test(value) || value === '') {
            throw "Invalid field exception.";
        }
        this.firstName = value
    }
    get _lastName() {
        return this.lastName;
    }
    set _lastName(value) {
        if (/^\s+$/.test(value) || value === '') {
            throw "Invalid field exception.";
        }
        this.lastName = value
    }
    get _facultyNumber() {
        return this.facultyNumber;
    }
    set _facultyNumber(value) {
        if (/^\s+$/.test(value) || value === '' || !(/^\d+$/.test(value))) {
            throw "Invalid field exception.";
        }
        this.facultyNumber = value
    }
    get _grade() {
        return this.grade;
    }
    set _grade(value) {
        if (/^\s+$/.test(value) || value === '' || isNaN(value)) {
            throw "Invalid field or NaN exception.";
        }
        this.grade = value;
    }

}


let dbURL = "http://localhost:3030/jsonstore/collections/students";
attachListeners();

//control
function attachListeners() {
    document.getElementById("form").addEventListener('submit',onSubmit);
    addEventListener("load", onLoad);
}
async function onLoad() {
    console.log('ONLOAD');
    let students = await getStudentsFromDB();
    let trs = students.map(createTr);
    let tbody = document.getElementById("results").querySelector('tbody');
    tbody.replaceChildren(...trs);
}
async function onSubmit(event){
    event.preventDefault();
    let std =  Object.values(Object.fromEntries(new FormData(event.target)));
    let student = new Student(...std);
    id="";
    try{
        id = await setStudentToDB(student);
    }catch{
        console.log("Error writing DB.");
        return;
    }
    student._id = id;
    let tbody = document.getElementById("results").querySelector('tbody');
    tbody.appendChild(createTr(student));
}
//view
function createTr(student) {
    let tr = document.createElement('tr');
    let tds = Object.entries(student).filter(k => k[0] !== "_id").map(createTd)
    tr.replaceChildren(...tds);
    return tr;
}
function createTd([key, value]) {
    let td = document.createElement('td');
    td.key = key;
    td.textContent = value;
    return td;
}

//workers
async function getStudentsFromDB() {
    let data;
    let responce;
    try {
        responce = await fetch(dbURL);
    }
    catch(e){
        throw "Server error.";
    }
    if (responce.ok === false || responce.status !== 200) throw "Error loading";
    try {
        data = await responce.json();
    } catch (e) { throw "Error loading - no db" }
    if (data === {}) throw "Error loading - empty db";
    return Object.values(data);
}

async function setStudentToDB(student) {
    let responce = await fetch(dbURL, {
        method: 'post',
        headers: { "content-type": "application/json" },
        body: JSON.stringify(student)
    });
    let data = await responce.json();
    let id = data._id;
    return id;
}

async function deleteStudentFromDB(id){
    //todo
}
function addStudentToLocal(id){
    //todo
}