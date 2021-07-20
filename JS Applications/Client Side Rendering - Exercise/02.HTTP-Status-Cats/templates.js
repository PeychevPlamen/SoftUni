import { html } from '../node_modules/lit-html/lit-html.js';

let liTemplate = (cat, showCatInfo) => html`
    <li>
        <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
        <div class="info">
            <button class="showBtn" @click=${showCatInfo}>Show status code</button>
            <div class="status" style="display: none" id="${cat.id}">
                <h4>Status Code: ${cat.statusCode}</h4>
                <p>${cat.statusMessage}</p>
            </div>
        </div>
    </li>
`;

let ulTemplate = (allCats, showCatInfo) => html`
<ul>
    ${allCats.map(c => liTemplate(c, showCatInfo))}
</ul>`;



export { ulTemplate, liTemplate };