import { allstudentsTemplate } from './templates.js';
import { render } from '../node_modules/lit-html/lit-html.js';


document.querySelector('#searchBtn').addEventListener('click', onClick);

let url = 'http://localhost:3030/jsonstore/advanced/table';

let tbody = document.querySelector('tbody');
console.log(tbody);
let allStudents = [];
getAllStudents();

async function getAllStudents() {

   let response = await fetch(url);
   let students = await response.json();
   allStudents = Object.values(students).map(s => ({
      name: `${s.firstName} ${s.lastName}`,
      email: s.email,
      course: s.course
   }));

   console.log(allStudents);

   render(allstudentsTemplate(allStudents), tbody);

}


function onClick() {

   let searchInput = document.getElementById('searchField');

   let searchText = searchInput.value.toLowerCase();

   if (searchInput.value == '') {
      alert('Empty search field!')
   } else {
      let students = allStudents.map(s => Object.assign({}, s));
      let machedStudents = students.filter(s => Object.values(s).some(val => val.toLowerCase().includes(searchText)));

      machedStudents.forEach(s => s.class = 'select');
      
      render(allstudentsTemplate(students), tbody);

      searchInput.value = '';
   }

}
