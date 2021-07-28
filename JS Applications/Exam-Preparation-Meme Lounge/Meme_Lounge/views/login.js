import { html } from '../node_modules/lit-html/lit-html.js';

import { login } from "../src/api/data.js";
//import { notify } from '../src/notifications.js';


const loginTemplate = (onSubmit) => html`
<section id="login">
    <form @submit=${onSubmit} id="login-form">
        <div class="container">
            <h1>Login</h1>
            <label for="email">Email</label>
            <input id="email" placeholder="Enter Email" name="email" type="text">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn button" value="Login">
            <div class="container signin">
                <p>Dont have an account?<a href="/register">Sign up</a>.</p>
            </div>
        </div>
    </form>
</section>`;



export async function loginPage(ctx) {
    console.log('login page');
    ctx.render(loginTemplate(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);
        const email = formData.get('email').trim();
        const password = formData.get('password').trim();

        if (!email || !password) {
            ctx.render(loginTemplate(onSubmit, email == '', password == ''));
            return alert('All fileds are required!');
        }

        await login(email, password);

        ctx.setUserNav();
        ctx.page.redirect('/catalog');

        // BONUS: Notifications

        // try {

        //     if (!email || !password) {
        //         ctx.render(loginTemplate(onSubmit, email == '', password == ''));
        //         throw new Error('All fileds are required!');
        //     }
        //     await login(email, password);

        //     ctx.setUserNav();
        //     ctx.page.redirect('/catalog');
        // } catch (error) {
        //     notify(error.message);
        // }
    }
}