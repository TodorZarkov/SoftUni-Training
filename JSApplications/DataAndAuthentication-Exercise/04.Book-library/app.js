class Book {
    author;
    title;
    constructor(author, title) {
        this._author = author;
        this._title = title;
    }
    set _author(value) {
        if (value === '' || /^\s+$/.test(value) || value === undefined || value === null) {
            throw "Empty field error";
        }
        this.author = value;
    }
    set _title(value) {
        if (value === '' || /^\s+$/.test(value) || value === undefined || value === null) {
            throw "Empty field error";
        }
        this.title = value;
    }
}


let isEditing = false;
let idToEdit = "";


const url = "http://localhost:3030/jsonstore/collections/books/";

addListeners();

function addListeners() {
    document.getElementById("loadBooks").addEventListener('click', loadBooks);
    document.querySelector('form').addEventListener('submit', onSubmit);
    document.querySelector('table').addEventListener('click', onDelete);
    document.querySelector('table').addEventListener('click', onEdit);
    document.querySelector('form').addEventListener('submit', onEditSubmit);
    addEventListener('load', onLoad);

}

//control
function onLoad() {
    let tbody = document.querySelector('tbody');
    tbody.replaceChildren();
}
async function loadBooks() {
    let tbody = document.querySelector('tbody');
    let books = await getBooksFromDB();
    let trs = books.map(createTr);
    tbody.replaceChildren(...trs);
}
async function onSubmit(event) {
    event.preventDefault();
    if (isEditing) return;
    let submit = new FormData(event.target);
    let book = new Book(submit.get('author'), submit.get('title'));
    let id;
    try {
        id = await setBookToDB(book);
    } catch (error) {
        throw error;
    }
    document.querySelector("tbody").appendChild(createTr([id, book]));
    submit.delete('author');
    event.target.reset();

}
async function onDelete(event) {
    if (isEditing) return;
    let delBtn = event.target;
    if (delBtn.nodeName !== 'BUTTON' || delBtn.textContent !== 'Delete') return;
    let trToDel = delBtn.parentElement.parentElement;
    let id = trToDel.id
    try {
        await deleteBookFromDB(id)
    } catch (error) {
        console.log(error);
        return;
    }
    trToDel.remove();
}
async function onEditSubmit(event) {
    if (!isEditing) return;
    let formEl = event.target;
    let form = new FormData(formEl);
    try {
        let updatedBook = new Book(form.get('author'), form.get('title'));
        await updateBookOnDB(updatedBook,idToEdit);
    } catch (error) {
        console.log(error);
        return;
    }
    formEl.querySelector('h3').textContent = 'FORM';
    
    trToEdit = document.getElementById(idToEdit);
    trToEdit.children[0].textContent = form.get('title');
    trToEdit.children[1].textContent = form.get('author');
    
    formEl.reset();
    idToEdit = "";
    isEditing = false;
}

//view
function createTr(idBookArray) {
    let tr = document.createElement('tr');
    tr.id = idBookArray[0];
    let tds = Object.entries(idBookArray[1]).filter(b => b[0] !== '_id').reverse().map(b => createTd(b[1]));
    tr.append(...tds);
    let buttonsTd = document.createElement('td');
    buttonsTd.innerHTML =
        `<button>Edit</button>
    <button>Delete</button>`;
    tr.appendChild(buttonsTd);
    return tr;
}
function createTd(text) {
    let td = document.createElement('td');
    td.textContent = text;
    return td;
}
function onEdit(event) {
    let btn = event.target;
    if (btn.nodeName !== "BUTTON" || btn.textContent !== "Edit") return;
    if (isEditing) return;
    isEditing = true;
    let titleToEdit = btn.parentElement.parentElement.children[0].textContent;
    let authorToEdit = btn.parentElement.parentElement.children[1].textContent;
    idToEdit = btn.parentElement.parentElement.id;


    let formEl = document.querySelector('form');
    let formTitle = formEl.querySelector('h3');
    formTitle.textContent = "Edit FORM"
    let titleFormEl = formEl.querySelector('[name="title"]');
    let authorFormEl = formEl.querySelector('[name="author"]');


    titleFormEl.value = titleToEdit;
    authorFormEl.value = authorToEdit;
}

//workers
async function getBooksFromDB() {
    try {
        let responce = await fetch(url);
        if (responce.ok === false || responce.status !== 200) throw "Error Retrieving books from DB";
        let data = await responce.json();
        if (data === {}) throw "Empty DB.";
        let books = Object.entries(data);
        return books;
    } catch (error) {
        throw error;
    }

}

async function setBookToDB(book) {
    id = '';
    try {
        let responce = await fetch(url, {
            method: "post",
            headers: { "content-type": "application/json" },
            body: JSON.stringify(book)
        });
        if (responce.ok === false || responce.status !== 200) throw "Error set to DB.";
        let data = await responce.json();
        id = data._id;
    }
    catch (e) {
        console.log(e);
        throw e;
    }
    return id;
}

async function deleteBookFromDB(id) {
    let deletedId;
    try {
        let responce = await fetch(url + id, {
            method: "delete"
        });
        if (responce.ok === false || responce.status !== 200) throw 'Error on delete.';
        let data = await responce.json();
        deletedId = data._id;
    } catch (error) {
        throw error;
    }
    return deletedId;
}

async function updateBookOnDB(book, id) {
    let updatedBook;
    try {
        let responce = await fetch(url + id, {
            method: "put",
            headers: { "content-type": "application/json" },
            body: JSON.stringify(book)
        });
        if (responce.ok === false || responce.status !== 200) throw 'Error on update.';
        let data = await responce.json();
        updatedBook = data;
    } catch (error) {
        throw error;
    }
    return updatedBook;
}