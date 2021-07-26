import { html } from "../node_modules/lit-html/lit-html.js";
import { register } from "../src/api/data.js";


const registerTemplate = (onSubmit, invalidEmail, invalidPass, invalidRepass) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Register New User</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class=${"form-control" + (invalidEmail ? ' is-invalid' : ' is-valid' )} id="email" type="text"
                    name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class=${'form-control' + (invalidPass ? ' is-invalid' : ' is-valid' )} id="password"
                    type="password" name="password">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="rePass">Repeat</label>
                <input class=${'form-control' + (invalidRepass ? ' is-invalid' : ' is-valid' )} id="rePass"
                    type="password" name="rePass">
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
        </div>
    </div>
</form>`;


export async function registerPage(ctx) {
    // console.log('register page');
    ctx.render(registerTemplate(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);
        const email = formData.get('email').trim();
        const password = formData.get('password').trim();
        const repass = formData.get('rePass').trim();

        if (email == '' || password == '' || repass == '') {
            ctx.render(registerTemplate(onSubmit, email == '', password == '', repass == ''));
            return alert('All fileds are required!');
        }
        if (password !== repass) {
            return alert(`Passwords dont't match!`);
        }

        await register(email, password);

        ctx.setUserNav();
        ctx.page.redirect('/');
    }

}

