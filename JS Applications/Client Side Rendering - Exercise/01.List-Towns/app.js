import { render } from '../node_modules/lit-html/lit-html.js';
import { listTemplate } from './templates.js';

// add click listener
// parse input
// execute template
// render result

// data => list

let rootDiv = document.getElementById('root');

let loadBtn = document.getElementById('btnLoadTowns');
loadBtn.addEventListener('click', (e) => {
    e.preventDefault();

    let inputTown = document.getElementById('towns');
    let towns = inputTown.value.split(', ').map(x => x.trim());
    //console.log(towns);

    render(listTemplate(towns), rootDiv);
    inputTown.value = '';
})
