import * as api from './api.js';

const host = 'http://localhost:3030';
api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

// GET all books !!!!!!
export async function getAllBooks() {
    return await api.get(host + '/data/books?sortBy=_createdOn%20desc');
}

//GET book by id  !!!!!
export async function getBookById(id) {
    return await api.get(host + '/data/books/' + id);
}

// GET My books
export async function getMyBooks() {
    const userId = sessionStorage.getItem('userId');
    return await api.get(host + `/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

// POST create book !!!!!!!
export async function createBook(data) {
    return await api.post(host + '/data/books', data);
}

// EDIT book !!!!!!
export async function editBook(id, data) {
    return await api.put(host + '/data/books/' + id, data);
}

// DELETE book !!!!!!
export async function deleteBook(id) {
    return await api.del(host + '/data/books/' + id);
}