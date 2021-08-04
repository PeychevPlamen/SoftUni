import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';

import { catalogMovies } from '../views/home.js';
import { loginPage } from '../views/login.js';
import { logout } from './api/data.js';
import { registerPage } from '../views/register.js';
import { detailsPage } from '../views/details.js';
import { movieAdd } from '../views/create.js';

const main = document.querySelector('main');


page('/', decorateContext, catalogMovies);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/details/:id', decorateContext, detailsPage);
page('/create', decorateContext, movieAdd);

setUserNav();

page.start();


function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setUserNav = setUserNav;
    next();
}


function setUserNav() {

    const email = sessionStorage.getItem('email');

    if (email != null) {
        document.getElementById('welcome-msg').textContent = `Welcome, ${email}`
        document.getElementById('logoutBtn').style.display = '';
        document.getElementById('loginLink').style.display = 'none';
        document.getElementById('registerLink').style.display = 'none';
    } else {
        document.getElementById('welcome-msg').style.display = `none`;
        document.getElementById('logoutBtn').style.display = 'none';
        document.getElementById('loginLink').style.display = '';
        document.getElementById('registerLink').style.display = '';
    }
}

document.getElementById('logoutBtn').addEventListener('click', async () => {
    await logout();
    setUserNav();
    page.redirect('/login');
});