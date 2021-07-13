let tableBody = document.querySelector('tbody');

let divInputs = document.querySelectorAll('.inputs input');

let btnSubmit = document.getElementById('submit');
btnSubmit.addEventListener('click', createStudents);

// console.log(divInputs);

let url = 'http://localhost:3030/jsonstore/collections/students';

async function getAllStudents() {

   try {
    let allStudentsRequest = await fetch(url);
    let allStudents = await allStudentsRequest.json();

    console.log(allStudents);

    while (tableBody.firstChild) {
        tableBody.removeChild(tableBody.lastChild);
    }

    Object.values(allStudents).map(fillTable);

   } catch (error) {
       let notification = document.querySelector('.notification');
         notification.textContent = error;
   }

}

function fillTable({ firstName, lastName, facultyNumber, grade, _id }) {
    let tableRow = document.createElement('tr');
    tableRow.id = _id;

    let th1 = document.createElement('th');
    th1.textContent = firstName;
    tableRow.appendChild(th1);
    let th2 = document.createElement('th');
    th2.textContent = lastName;
    tableRow.appendChild(th2);
    let th3 = document.createElement('th');
    th3.textContent = facultyNumber;
    tableRow.appendChild(th3);
    let th4 = document.createElement('th');
    th4.textContent = grade;
    tableRow.appendChild(th4);

    tableBody.appendChild(tableRow);

}

async function createStudents(e) {
    e.preventDefault();
    try {
        if (divInputs[0].value === '' 
        || divInputs[1].value === '' 
        || divInputs[2].value === ''
        || divInputs[3].value === '') {

            throw new Error('Fill in all required fields')
            
        }

        let studentToAdd = {
            firstName: divInputs[0].value,
            lastName: divInputs[1].value,
            facultyNumber: divInputs[2].value,
            grade: divInputs[3].value
        }

        await fetch(url, {
            method: 'Post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(studentToAdd)
        });

        divInputs[0].value = '';
        divInputs[1].value = '';
        divInputs[2].value = '';
        divInputs[3].value = '';

        await getAllStudents();

    } catch (error) {
         let notification = document.querySelector('.notification');
         notification.textContent = error;
    }

}

getAllStudents();
