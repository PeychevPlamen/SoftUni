import { cats } from './catSeeder.js';
import { ulTemplate } from './templates.js';
import { render } from '../node_modules/lit-html/lit-html.js';

let allCatsSection = document.getElementById('allCats');

function showInfo(e) {
    e.preventDefault();
    let btn = e.target;
    btn.textContent = btn.textContent === 'Show status code'
        ? 'Hide status code'
        : 'Show status code';

    let infoDiv = btn.parentNode;
    let divStatus = infoDiv.querySelector('.status');

    if (divStatus.style.display == 'none') {
        divStatus.style.display = '';
        btn.textContent = 'Hide status code';
    } else {
        divStatus.style.display = 'none';
        btn.textContent = 'Show status code';
    }

}

render(ulTemplate(cats, showInfo), allCatsSection);

