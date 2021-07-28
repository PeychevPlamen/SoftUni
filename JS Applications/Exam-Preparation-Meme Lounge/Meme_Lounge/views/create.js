import { html } from "../node_modules/lit-html/lit-html.js";

import { createMeme } from '../src/api/data.js';
//import { notify } from "../src/notifications.js";

const createMemeTemplate = (onSubmit) => html`
<section id="create-meme">
    <form @submit=${onSubmit} id="create-form">
        <div class="container">
            <h1>Create Meme</h1>
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title">
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description"></textarea>
            <label for="imageUrl">Meme Image</label>
            <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
            <input type="submit" class="registerbtn button" value="Create Meme">
        </div>
    </form>
</section>`;


export async function memeCreate(ctx) {
    //console.log('create page');

    ctx.render(createMemeTemplate(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);

        let title = formData.get('title');
        let description = formData.get('description');
        let memeImg = formData.get('imageUrl');


        if (!title || !description || !memeImg) {
            return alert('All fields are required!');
        }

        await createMeme({ title, description, imageUrl });

        ctx.page.redirect('/catalog');


    // BONUS: Notifications
        // try {
        //    if (!title || !description || !memeImg) {
        //         throw new Error('All fields are required!');
        //     }
    
        //     await createMeme({ title, description, imageUrl });
    
        //     ctx.page.redirect('/catalog');
        // } catch (error) {
        //     notify(error.message);
        // }
        
    }
};