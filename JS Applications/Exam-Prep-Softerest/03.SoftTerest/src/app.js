import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';


import { loginPage } from '../views/login.js';
import { registerPage } from '../views/register.js';
import { homePage } from '../views/home.js';
import { allIdeas } from '../views/catalog.js';
import { detailsPage } from '../views/details.js';
import { ideaCreate } from '../views/create.js';


const main = document.querySelector('main');


page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/', decorateContext, homePage);
page('/catalog', decorateContext, allIdeas);
page('/details/:id', decorateContext, detailsPage);
page('/create', decorateContext, ideaCreate);

setUserNav();


// Start Application
page.start();


function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setUserNav = setUserNav;
    next();
}

// by class name selector

function setUserNav() {

    const token = sessionStorage.getItem('authToken');

    if (token != null) {
        document.getElementById('createLink').style.display = '';
        document.getElementById('logoutBtn').style.display = '';
        document.getElementById('loginLink').style.display = 'none';
        document.getElementById('registerLink').style.display = 'none';
    } else {
        document.getElementById('createLink').style.display = 'none';
        document.getElementById('logoutBtn').style.display = 'none';
        document.getElementById('loginLink').style.display = '';
        document.getElementById('registerLink').style.display = '';
    }
}


// document.getElementById('logoutBtn').addEventListener('click', async () => {
//     await logout();
//     setUserNav();
//     page.redirect('/');
// });