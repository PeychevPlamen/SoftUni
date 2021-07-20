import { html } from '../node_modules/lit-html/lit-html.js';

// let liTemplate = (town) => html`<li>${town}</li>`;

// let ulTemplate = (towns) => html`
// <ul>
//     ${towns.map(t => liTemplate(t))}
// </ul>`;

let listTemplate = (data) => html`
<ul>
    ${data.map(t => html`<li>${t}</li>`)}
</ul>`;

export {listTemplate};