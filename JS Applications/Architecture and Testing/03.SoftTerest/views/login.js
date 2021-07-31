import { login } from "../src/api/data.js";

export function setupLogin(section, navigation) {

    const form = section.querySelector('form');
    console.log(form);
    form.addEventListener('submit', onSubmit);

    return showLogin;

    async function showLogin() {
        return section;
    }

    async function onSubmit(event) {
        event.preventDefault();
        let formData = new FormData(form);

        let email = formData.get('email');
        let password = formData.get('password');

        await login(email, password);
        form.reset();
        navigation.setUserNav();
        navigation.goTo('home');
    }
}