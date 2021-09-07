import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';

import { logout } from './api/data.js';
import { loginPage } from '../views/login.js';
import { registerPage } from '../views/register.js';
import { bookCreate } from '../views/create.js';
import { allBooks } from '../views/dashboard.js';
import { detailsPage } from '../views/details.js';
import { editPage } from '../views/edit.js';
import { myBooksPage } from '../views/profile.js';


const main = document.getElementById('site-content');


page('/dashboard', decorateContext, allBooks);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/create', decorateContext, bookCreate);
page('/details/:id', decorateContext, detailsPage);
page('/edit/:id', decorateContext, editPage);
page('/profile', decorateContext, myBooksPage);


setUserNav();


// Start Application
page.start();


function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setUserNav = setUserNav;
    next();
}


function setUserNav() {

    const email = sessionStorage.getItem('email');

    if (email != null) {
        document.getElementById('user').firstElementChild.textContent = `Welcome, ${email}`;
        document.getElementById('user').style.display = '';
        document.getElementById('guest').style.display = 'none';
    } else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = '';
    }
}


document.getElementById('user').lastElementChild.addEventListener('click', async () => {
    await logout();
    setUserNav();
    page.redirect('/dashboard');
});