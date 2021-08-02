import * as api from './api.js';

const host = 'http://localhost:3030';
api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

// GET all cars !!!!!!
export async function getAllCars() {
    return await api.get(host + '/data/cars?sortBy=_createdOn%20desc');
}

//GET car by id  !!!!!  -- Details Page --
export async function getCarById(id) {
    return await api.get(host + '/data/cars/' + id);
}

// GET My car
export async function getMyCar() {
    const userId = sessionStorage.getItem('userId');
    return await api.get(host + `/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

// POST create CAR !!!!!!!
export async function createCar(data) {
    return await api.post(host + '/data/cars', data);
}

// EDIT CAR !!!!!!
export async function editCar(id, data) {
    return await api.put(host + '/data/cars/' + id, data);
}

// DELETE CAR !!!!!!
export async function deleteCar(id) {
    return await api.del(host + '/data/cars/' + id);
}