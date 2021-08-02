import { html } from "../node_modules/lit-html/lit-html.js";
import { getMyCar } from "../src/api/data.js";

const myCarTemplate = (cars, { brand, model, year, price, imageUrl }) => html`
<section id="my-listings">
    <h1>My car listings</h1>
    <div class="listings">
      
        <!-- Display if there are no records -->
        ${cars.length == 0 ? html`<p class="no-cars"> You haven't listed any cars yet.</p>` : cars.map(carTemplate)}
        
    </div>
</section>`;

const carTemplate = (car) => html`
<div class="listing">
    <div class="preview">
        <img src="${car.imageUrl}">
    </div>
    <h2>${car.brand} ${car.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${car.year}</h3>
            <h3>Price: ${car.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${car._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>`;

export async function myCarsPage(ctx) {

    const cars = await getMyCar();
    const brand = sessionStorage.getItem('brand');
    const model = sessionStorage.getItem('model');
    const year = sessionStorage.getItem('year');
    const price = sessionStorage.getItem('price');
    const imageUrl = sessionStorage.getItem('imageUrl');

    ctx.render(myCarTemplate(cars, { brand, model, year, price, imageUrl }));
};