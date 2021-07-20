import { html } from '../node_modules/lit-html/lit-html.js';
import {ifDefined} from '../node_modules/lit-html/directives/if-defined.js';

let liTemplate = (town) => html`
    <li class=${ifDefined(town.class)}>${town.name}</li>
`;

let ulTemplate = (towns) => html`
<ul>
    ${towns.map(t => liTemplate(t))}
</ul>`;


export { ulTemplate, liTemplate };