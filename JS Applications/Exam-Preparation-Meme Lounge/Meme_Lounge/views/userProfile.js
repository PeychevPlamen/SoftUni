import { html } from "../node_modules/lit-html/lit-html.js";
import { getMyMeme } from "../src/api/data.js";


const myMemeTemplate = (memes, { username, email, gender }) => html`
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src="./images/${gender}.png">
        <div class="user-content">
            <p>Username: ${username}</p>
            <p>Email: ${email}</p>
            <p>My memes count: ${memes.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">
        <!-- Display : All created memes by this user (If any) -->

        ${memes.length == 0 ? html`<p class="no-memes">No memes in database.</p>` : memes.map(memeTemplate)}

        <!-- Display : If user doesn't have own memes  -->

    </div>
</section>
`;

const memeTemplate = (meme) => html`
<div class="user-meme">
    <p class="user-meme-title">${meme.title}</p>
    <img class="userProfileImage" alt="meme-img" src=${meme.imageUrl}>
    <a class="button" href="${'/details/' + meme._id}">Details</a>
</div>`;

export async function myMemesPage(ctx) {

    const memes = await getMyMeme();
    const username = sessionStorage.getItem('username');
    const email = sessionStorage.getItem('email');
    const gender = sessionStorage.getItem('gender');

    ctx.render(myMemeTemplate(memes, { username, email, gender }));
};