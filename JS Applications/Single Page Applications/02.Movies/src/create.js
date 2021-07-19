import {showDetails} from './details.js';

async function onSubmit(ev){
    ev.preventDefault();
    
    let formData = new FormData(ev.target);
    let movie = {
        title: formData.get('title'),
        description: formData.get('description'),
        img: formData.get('imageUrl')
    };
    if (movie.title == '' || movie.description == '' || movie.img == '') {
        return alert('All fields are require');
    }

    let response = await fetch('http://localhost:3030/data/movies', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('authToken')
        },
        body: JSON.stringify(movie)
    });

    if (response.ok) {
        let movie = await response.json();
        ev.target.reset();
        showDetails(movie._id);
    } else {
        alert('You have to be login to create a movie!');
    }
}

let main;
let section;

export function setupCreate(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;

    let form = section.querySelector('form');
    form.addEventListener('submit', onSubmit);
}

export async function showCreate() {
    main.innerHTML = '';
    main.appendChild(section);
}