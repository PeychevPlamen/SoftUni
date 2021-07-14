let url = 'http://localhost:3030/jsonstore/collections/books';

let booksTableBody = document.querySelector('table tbody');
booksTableBody.querySelectorAll('tr').forEach(tr => tr.remove());

let btnSubmit = document.querySelector('form button');
btnSubmit.addEventListener('click', createBook);

async function getAllBooks() {

    try {
        let allBooksRequest = await fetch(url);
        let allBooks = await allBooksRequest.json();

        booksTableBody.querySelectorAll('tr').forEach(tr => tr.remove());

        Object.entries(allBooks).forEach(item => {
            let [id, book] = item;

            let tr = document.createElement('tr');
            tr.id = id;

            let tdAuthor = document.createElement('td');
            tdAuthor.textContent = book.author;

            let tdTitle = document.createElement('td');
            tdTitle.textContent = book.title;

            let editBtn = document.createElement('button');
            editBtn.textContent = 'Edit';

            let deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';

            let tdBtn = document.createElement('td');
            tdBtn.appendChild(editBtn);
            tdBtn.appendChild(deleteBtn);

            tr.appendChild(tdTitle);
            tr.appendChild(tdAuthor);
            tr.appendChild(tdBtn);

            let tbody = document.querySelector('table tbody');

            tbody.appendChild(tr);

            editBtn.addEventListener('click', bookEditing);
            deleteBtn.addEventListener('click', bookDelete);

        });

    } catch (error) {
        console.error(error);
    }

}

async function createBook(e) {
    e.preventDefault();

    try {
        btnSubmit.textContent = 'Submit';
        let h3Form = document.querySelector('h3');
        h3Form.textContent = 'FORM';

        let bookTitleInput = document.getElementById('title');
        let bookAuthorInput = document.getElementById('author');

        if (bookAuthorInput.value === '' || bookTitleInput.value === '') {
            throw new Error('Empty input fields');
        }

        let bookToCreate = {
            author: bookAuthorInput.value,
            title: bookTitleInput.value
        };

        await fetch(url, {
            method: 'Post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(bookToCreate)
        });

        bookAuthorInput.value = '';
        bookTitleInput.value = '';

        await getAllBooks();
    } catch (error) {
        console.error(error);
    }

}

async function bookEditing(e) {
    e.preventDefault();

    let h3Form = document.querySelector('h3');
    h3Form.textContent = 'Edit FORM';

    btnSubmit.textContent = 'Save';

    let bookTitleInput = document.getElementById('title');
    let bookAuthorInput = document.getElementById('author');

    let bookId = e.target.parentNode.parentNode.id;
    let bookResponse = await fetch(`${url}/${bookId}`);
    let book = await bookResponse.json();

    bookTitleInput.value = book.title;
    bookAuthorInput.value = book.author;
}

async function bookDelete(e) {
    e.preventDefault();

    let bookId = e.target.parentNode.parentNode.id;
    let bookResponse = await fetch(`${url}/${bookId}`, {
        method: 'Delete'
    });
         
    await getAllBooks();
}

getAllBooks();