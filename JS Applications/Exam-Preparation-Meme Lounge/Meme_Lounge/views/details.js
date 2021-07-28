import { html } from "../node_modules/lit-html/lit-html.js";
import { deleteMeme, getMemeById } from "../src/api/data.js";


const detailsTemplate = (item, isOwner, onDelete) => html`
<section id="meme-details">
    <h1>Meme Title: ${item.title}</h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src=${item.imageUrl}>
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>
                ${item.description}
            </p>
            ${isOwner ? html`
            <a class="button warning" href=${`/edit/${item._id}`}>Edit </a> <button @click=${onDelete}
                href=”javascript:void(0)” class="button danger">Delete</button>

        </div>` : ''}

    </div>
</section>`;

export async function detailsPage(ctx) {
    // console.log('details page');

    const id = ctx.params.id;
    const item = await getMemeById(id);

    const userId = sessionStorage.getItem('userId');
    const isOwner = item._ownerId == userId;

    ctx.render(detailsTemplate(item, isOwner, onDelete));

    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete this item?');
        if (confirmed) {
            await deleteMeme(item._id);
            ctx.page.redirect('/catalog');
        }
    }
}
