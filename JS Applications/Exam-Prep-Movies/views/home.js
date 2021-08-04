import { html } from '../node_modules/lit-html/lit-html.js';

import { getAllMovies } from '../src/api/data.js';


const homeTemplate = (movies, isUser) => html`
<section id="home-page">
    <div class="jumbotron jumbotron-fluid text-light" style="background-color: #343a40;">
        <img src="https://slicksmovieblog.files.wordpress.com/2014/08/cropped-movie-banner-e1408372575210.jpg"
            class="img-fluid" alt="Responsive image" style="width: 150%; height: 200px">
        <h1 class="display-4">Movies</h1>
        <p class="lead">Unlimited movies, TV shows, and more. Watch anywhere. Cancel anytime.</p>
    </div>

    <h1 class="text-center">Movies</h1>

    ${isUser !== null ? html`<a href="/create" class="btn btn-warning ">Add Movie</a>` : ''}

    <div class=" mt-3 ">
        <div class="row d-flex d-wrap">

            <div class="card-deck d-flex justify-content-center">

                ${movies.length == 0 ? html` <h3>No movies in database</h3> ` :
                movies.map(movieTemplate)}

            </div>
        </div>
    </div>

</section>`;

const movieTemplate = (movie, user) => html`
    <div class="card mb-4">
        <img class="card-img-top" src=${movie.img} alt="Card image cap" width="400">
        <div class="card-body">
            <h4 class="card-title">${movie.title}</h4>
        </div>
        <div class="card-footer">
    
            ${user == null ? '' : html`<a href="/details/${movie._id}"><button type="button"
                    class="btn btn-info">Details</button></a>
        </div>`}
    
    </div>`;

export async function catalogMovies(ctx) {

    const isUser = sessionStorage.getItem('username');
    const data = await getAllMovies();

    ctx.render(homeTemplate(data, isUser));
};