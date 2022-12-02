import * as api from "./serverApi.js";

const endpoint = {
     login : "/users/login",
     logout : "/users/logout",
     register : "/users/register"
}


export async function login (email, password) {
    const user = await api.post(endpoint.login, {email, password});
    sessionStorage.setItem("user", JSON.stringify(user));
}


export async function register(email, password) {
    const user = await api.post(endpoint.register, {email, password});
    sessionStorage.setItem("user", JSON.stringify(user));
}


export function logout() {
    api.get(endpoint.logout);
    sessionStorage.removeItem("user");
}