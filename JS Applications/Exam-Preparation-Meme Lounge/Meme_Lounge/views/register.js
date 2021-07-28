import { html } from "../node_modules/lit-html/lit-html.js";
import { register } from "../src/api/data.js";

import { notify } from '../src/notifications.js';

const registerTemplate = (onSubmit) => html`
<section id="register">
    <form @submit=${onSubmit} id="register-form">
        <div class="container">
            <h1>Register</h1>
            <label for="username">Username</label>
            <input id="username" type="text" placeholder="Enter Username" name="username">
            <label for="email">Email</label>
            <input id="email" type="text" placeholder="Enter Email" name="email">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <label for="repeatPass">Repeat Password</label>
            <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
            <div class="gender">
                <input type="radio" name="gender" id="female" value="female">
                <label for="female">Female</label>
                <input type="radio" name="gender" id="male" value="male" checked>
                <label for="male">Male</label>
            </div>
            <input type="submit" class="registerbtn button" value="Register">
            <div class="container signin">
                <p>Already have an account?<a href="/login">Sign in</a>.</p>
            </div>
        </div>
    </form>
</section>`;


export async function registerPage(ctx) {
    // console.log('register page');
    ctx.render(registerTemplate(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);
        const username = formData.get('username').trim();
        const email = formData.get('email').trim();
        const password = formData.get('password').trim();
        const repass = formData.get('repeatPass').trim();
        const gender = formData.get('gender');

        if ( !email || !password || !repass || !username || !gender) {
            // ctx.render(registerTemplate(onSubmit, email == '' || password == '' || repass == '' || username == ''));
            return alert('All fileds are required!');
        }
        if (password !== repass) {
            return alert(`Passwords dont't match!`);
        }

        await register(email, password, username, gender);

        ctx.setUserNav();
        ctx.page.redirect('/catalog');


        // try {
        //     if ( !email || !password || !repass || !username || !gender) {
        //         // ctx.render(registerTemplate(onSubmit, email == '' || password == '' || repass == '' || username == ''));
        //        throw new Error('All fileds are required!');
        //     }
        //     if (password !== repass) {
        //         throw new Error(`Passwords dont't match!`);
        //     }
    
        //     await register(email, password, username, gender);
    
        //     ctx.setUserNav();
        //     ctx.page.redirect('/catalog');
        // } catch (error) {
        //     notify(error.message);
        // }
    }

}