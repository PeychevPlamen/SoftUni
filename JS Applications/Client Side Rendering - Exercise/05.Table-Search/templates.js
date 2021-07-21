import { html } from '../node_modules/lit-html/lit-html.js';
import {ifDefined} from '../node_modules/lit-html/directives/if-defined.js';

let studentTemplate = (student) => html`
<tr class=${ifDefined(student.class)}>
    <td>${student.name}</td>
    <td>${student.email}</td>
    <td>${student.course}</td>
</tr>
    
`;

let allstudentsTemplate = (students) => html`
${students.map(s => studentTemplate(s))}
`;


export { studentTemplate, allstudentsTemplate };