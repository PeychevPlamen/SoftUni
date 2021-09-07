import { html } from "../node_modules/lit-html/lit-html.js";
import { deleteBook, getBookById } from "../src/api/data.js";


const detailsTemplate = (item, isOwner, onDelete) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${item.title}</h3>
        <p class="type">Type: ${item.type}</p>
        <p class="img"><img src=${item.imageUrl}></p>
        <div class="actions">


            ${isOwner ? html`
            <a class="button" href="/edit/${item._id}">Edit</a>
            <a class="button" @click=${onDelete} href="javascript:void(0)">Delete</a>` : ''}

            <!-- Edit/Delete buttons ( Only for creator of this book )  -->


            <!-- Bonus -->
            <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
            <a class="button" href="#">Like</a>

            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: 0</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${item.description}</p>
    </div>
</section>`;

export async function detailsPage(ctx) {
    // console.log('details page');

    const id = ctx.params.id;
    const item = await getBookById(id);

    const userId = sessionStorage.getItem('userId');
    const isOwner = item._ownerId == userId;

    ctx.render(detailsTemplate(item, isOwner, onDelete));

    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete this item?');
        if (confirmed) {
            await deleteBook(item._id);
            ctx.page.redirect('/dashboard');
        }
    }
}