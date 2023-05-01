import { requestFactory } from "./dataServerService";

const endpoint = '/users'

export const userServiceFactory = (token) => {
    const request = requestFactory(token);

    return {
        onLogin: async (data) => {

            const result = await request.post(endpoint + '/login', data);
        
            return result;
        },
        
        onRegister: async (data) => {
            const result = await request.post (endpoint + '/register', data);
        
            return result;
        },
        
        onLogout: () => {
            request.get ( endpoint + '/logout');
        },
    };
};