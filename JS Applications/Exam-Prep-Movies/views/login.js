import { html } from '../node_modules/lit-html/lit-html.js';

import { login } from '../src/api/data.js';

const loginTemplate = (onSubmit) => html`
        <form @submit=${onSubmit} class="text-center border border-light p-5" action="" method="">
            <div class="form-group">
                <label for="email">Email</label>
                <input type="email" class="form-control" placeholder="Email" name="email" value="">
            </div>
            <div class="form-group">
                <label for="password">Password</label>
                <input type="password" class="form-control" placeholder="Password" name="password" value="">
            </div>
        
            <button type="submit" class="btn btn-primary">Login</button>
        </form>
`;


export async function loginPage(ctx) {

    ctx.render(loginTemplate(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);

        const email = formData.get('email').trim();
        const password = formData.get('password').trim();


        if (!email || !password) {
            return alert('All fields are required!');
        }

        await login(email, password);
        
        ctx.page.redirect('/');
        ctx.setUserNav();

    }
}