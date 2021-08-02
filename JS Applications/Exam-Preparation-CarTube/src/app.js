import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';


import { homePage } from '../views/homePage.js';
import { loginPage } from '../views/login.js';
import { registerPage } from '../views/register.js';
import { logout } from './api/api.js';
import { allCars } from '../views/catalog.js';
import { detailsPage } from '../views/details.js';
import { editPage } from '../views/editCar.js';
import { carCreate } from '../views/create.js';
import { myCarsPage } from '../views/userProfile.js';


const main = document.getElementById('site-content');


page('/', decorateContext, homePage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/catalog', decorateContext, allCars);
page('/details/:id', decorateContext, detailsPage);
page('/edit/:id', decorateContext, editPage);
page('/create', decorateContext, carCreate);
page(`/myCars`, decorateContext, myCarsPage);

setUserNav();


// Start Application
page.start();




function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setUserNav = setUserNav;
    next();
}

// by id name selector

function setUserNav() {

    const username = sessionStorage.getItem('username');

    if (username != null) {
        const welcome = document.querySelector('#profile').firstElementChild.textContent = `Welcome ${username}`;
        //console.log(welcome);
        document.getElementById('profile').style.display = '';
        document.getElementById('guest').style.display = 'none';
    } else {
        document.getElementById('profile').style.display = 'none';
        document.getElementById('guest').style.display = '';
    }
}


document.querySelector('#profile').lastElementChild.addEventListener('click', async () => {
    await logout();
    setUserNav();
    page.redirect('/');
});

