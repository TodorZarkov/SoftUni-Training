import { post } from "./dataServerService";

const endpoint = '/users'

export const onLogin = async (data) => {

    const result = await post(endpoint + '/login', data);

    return result;
};

export const onRegister = async (data) => {
    const result = await post (endpoint + '/register', data);

    return result;
}