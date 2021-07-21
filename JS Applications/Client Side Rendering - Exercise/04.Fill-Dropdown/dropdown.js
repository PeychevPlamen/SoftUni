import { allTownsTemplate } from './templates.js';
import { render } from '../node_modules/lit-html/lit-html.js';

let menu = document.getElementById('menu');

let url = 'http://localhost:3030/jsonstore/advanced/dropdown';

let townInput = document.getElementById('itemText');
let button = document.getElementById('button');
console.log(button);
button.addEventListener('click', addItem);

loadTowns();

async function loadTowns() {

    let response = await fetch(url);
    let allTowns = await response.json();
    let towns = Object.values(allTowns);
    console.log(towns);

    render(allTownsTemplate(towns), menu);
}

async function addItem(e) {
    e.preventDefault();

    let newTown = {
        text: townInput.value
    };

    if (townInput.value == '') {
        alert('Empty town input field');
    } else {
        
        const rawResponse = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newTown)
        });
        
        townInput.value = '';
        
        if (rawResponse.ok) {
            await loadTowns();
        }
    }

}

