import { render } from '../node_modules/lit-html/lit-html.js';
import { ulTemplate } from './templates.js';
import { towns } from './towns.js';

let townsDiv = document.getElementById('towns');
let baseTowns = towns.map(t => ({ name: t }));

render(ulTemplate(baseTowns), townsDiv);

let searchBtn = document.getElementById('button');
searchBtn.addEventListener('click', search);

let matchesResult = document.getElementById('result');

function search() {

   let inputText = document.getElementById('searchText');
   let searchText = inputText.value.toLowerCase();

   let allTowns = towns.map(t => ({ name: t }));
   let matchedTowns = allTowns.filter(t => t.name.toLowerCase().includes(searchText));
   matchedTowns.forEach(t => t.class = 'active');

   matchesResult.textContent = `${matchedTowns.length} matches found`;
   
   render(ulTemplate(allTowns), townsDiv);
}
