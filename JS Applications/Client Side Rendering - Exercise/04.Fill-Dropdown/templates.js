import { html } from '../node_modules/lit-html/lit-html.js';

let townTemplate = (town) => html`
    <option .value=${town._id}>${town.text}</option>
`;

let allTownsTemplate = (towns) => html`
${towns.map(t => townTemplate(t))}
`;



export { allTownsTemplate };