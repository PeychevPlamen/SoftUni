import page from '../node_modules/page/page.mjs';
import { render } from "../node_modules/lit-html/lit-html.js";

import { createPage } from '../views/create.js';
import { dashboardPage } from '../views/dashboard.js';
import { detailsPage } from '../views/details.js';
import { editPage } from '../views/edit.js';
import { loginPage } from '../views/login.js';
import { myFurniturePage } from '../views/my-furniture.js';
import { registerPage } from '../views/register.js';
import { logout } from './api/data.js';

//import * as api from './api/data.js';

// window.api = api;

const main = document.querySelector('.container');

page('/', decorateContext, dashboardPage);
page('/details/:id', decorateContext, detailsPage);
page('/create', decorateContext, createPage);
page('/edit/:id', decorateContext, editPage);
page('/register', decorateContext, registerPage);
page('/login', decorateContext, loginPage);
page('/my-furniture', decorateContext, myFurniturePage);

document.getElementById('logoutBtn').addEventListener('click', async () => {
    await logout();
    setUserNav();
    page.redirect('/');
})

setUserNav();
// Start Application
page.start();

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setUserNav = setUserNav;
    next();
}

function setUserNav() {

    const userId = sessionStorage.getItem('userId');

    if (userId != null) {
        document.getElementById('user').style.display = '';
        document.getElementById('guest').style.display = 'none';
    } else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = '';
    }
}