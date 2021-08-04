import { html } from "../node_modules/lit-html/lit-html.js";
import { deleteMovie, getMovieById } from "../src/api/data.js";



const detailsTemplate = (item, isOwner, onDelete, getLikesByMovieId, getOwnLikes) => html`
<section id="movie-details">
    <div class="container">
        <div class="row bg-light text-dark">
            <h1>Movie title: ${item.title}</h1>

            <div class="col-md-8">
                <img class="img-thumbnail" src=${item.img} alt="Movie">
            </div>
            <div class="col-md-4 text-center">
                <h3 class="my-3 ">Movie Description</h3>
                <p>${item.description}</p>

                ${isOwner ? 
                    html`
                <a @click=${onDelete} class="btn btn-danger" href="javascript:void(0)">Delete</a>
                <a class="btn btn-warning" href="/edit/${item._id}">Edit</a>
                <span class="enrolled-span">Liked 1</span>` 
                : html`<a class="btn btn-primary" href="#">Like</a>
                <span class="enrolled-span">Liked 1</span>`}
                
            </div>
        </div>
    </div>
</section>`;

export async function detailsPage(ctx) {
    // console.log('details page');

    const id = ctx.params.id;
    const item = await getMovieById(id);

    const userId = sessionStorage.getItem('userId');
    const isOwner = item._ownerId == userId;

    ctx.render(detailsTemplate(item, isOwner, onDelete));

    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete this item?');
        if (confirmed) {
            await deleteMovie(item._id);
            ctx.page.redirect('/');
        }
    }
}

// async function getLikesByMovieId(id) {
//     return await api.get(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`);
// }

// async function getOwnLikes(id) {
//     let userId = sessionStorage.getItem('userId');
//     return await api.get(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userId}%22`);
    
// }