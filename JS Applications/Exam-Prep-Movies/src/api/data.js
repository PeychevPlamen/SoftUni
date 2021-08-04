import * as api from './api.js';

const host = 'http://localhost:3030';
api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

// GET all movies !!!!!!
export async function getAllMovies() {
    return await api.get(host + '/data/movies');
}

//GET movie by id  !!!!!
export async function getMovieById(id) {
    return await api.get(host + '/data/movies/' + id);
}

// // GET My Meme
// export async function getMyMovie() {
//     const userId = sessionStorage.getItem('userId');
//     return await api.get(host + `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
// }

// POST create movie !!!!!!!
export async function createMovie(data) {
    return await api.post(host + '/data/movies', data);
}

// Update movie !!!!!!
export async function editMovie(id, data) {
    return await api.put(host + '/data/movies/' + id, data);
}

// DELETE movie !!!!!!
export async function deleteMovie(id) {
    return await api.del(host + '/data/movies/' + id);
}

