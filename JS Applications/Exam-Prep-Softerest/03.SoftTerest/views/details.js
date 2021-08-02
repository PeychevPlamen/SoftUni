import { html } from "../node_modules/lit-html/lit-html.js";
import { deleteIdea, getIdeaById } from "../src/api/data.js";


const detailsTemplate = (item, isOwner, onDelete) => html`
<div id="details-page" class="container home some">
    <img class="det-img" src="${item.img}" />
    <div class="desc">
        <h2 class="display-5">${item.title}</h2>
        <p class="infoType">Description:</p>
        <p class="idea-description">${item.description}</p>
    </div>
    ${isOwner ? html`<div class="text-center">
        <a @click=${onDelete} class="btn detb" href="javascript:void(0)">Delete</a>
    </div>` : ''}
</div>`;

export async function detailsPage(ctx) {
    // console.log('details page');

    const id = ctx.params.id;
    const item = await getIdeaById(id);

    const userId = sessionStorage.getItem('userId');
    const isOwner = item._ownerId == userId;

    ctx.render(detailsTemplate(item, isOwner, onDelete));

    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete this item?');
        if (confirmed) {
            await deleteIdea(item._id);
            ctx.page.redirect('/catalog');
        }
    }
}