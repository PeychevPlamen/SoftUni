import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';

import { homePage } from '../views/homePage.js';
import { loginPage } from '../views/login.js';
import { registerPage } from '../views/register.js';
import { logout } from './api/data.js';
import { allMemes } from '../views/catalog.js';
import { memeCreate } from '../views/create.js';
import { detailsPage } from '../views/details.js';
import { editPage } from '../views/editMeme.js';
import { myMemesPage } from '../views/userProfile.js';

const main = document.querySelector('main');


page('/', decorateContext, homePage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/catalog', decorateContext, allMemes);
page('/create', decorateContext, memeCreate);
page('/details/:id', decorateContext, detailsPage);
page('/edit/:id', decorateContext, editPage);
page('/profile', decorateContext, myMemesPage);


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
    
    const email = sessionStorage.getItem('email');
    
    if (email != null) {
        document.querySelector('div.profile > span').textContent = `Welcome, ${email}`
        document.querySelector('.user').style.display = '';
        document.querySelector('.guest').style.display = 'none';
    } else {
        document.querySelector('.user').style.display = 'none';
        document.querySelector('.guest').style.display = '';
    }
}


document.getElementById('logoutBtn').addEventListener('click', async () => {
    await logout();
    setUserNav();
    page.redirect('/');
});