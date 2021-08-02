import * as api from './api.js';

const host = 'http://localhost:3030';
api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

// GET all ideas !!!!!!
export async function getAllIdeas() {
    return await api.get(host + '/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc');
}

//GET idea by id  !!!!!
export async function getIdeaById(id) {
    return await api.get(host + '/data/ideas/' + id);
}

// GET My idea
// export async function getMyIdea() {
//     const userId = sessionStorage.getItem('userId');
//     return await api.get(host + `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
// }

// POST create idea !!!!!!!
export async function createIdea(data) {
    return await api.post(host + '/data/ideas', data);
}

// EDIT meme !!!!!!
// export async function editMeme(id, data) {
//     return await api.put(host + '/data/memes/' + id, data);
// }

// DELETE idea !!!!!!
export async function deleteIdea(id) {
    return await api.del(host + '/data/ideas/' + id);
}