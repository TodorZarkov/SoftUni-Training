const server = `http://localhost:3030`;

const requester = async (method, token, endpoint, data) => {
    
    const options = {};
    if(method !== 'GET') {
        options.method = method;
        if(data) {
            options.headers = {"Content-Type": "Application/JSON"}
            options.body = JSON.stringify(data);
        }
    }

    if(token) {
        options.headers = {
            ...options.headers, 
            "X-Authorization": token
        }
    }
    
    const response = await fetch(server + endpoint, options);
    
    //todo: handle server not found
    const result = response.status === 204 ? {} : await response.json();

    if (response.status !== 200) {
        throw result
    }

    return result;
};

export const requestFactory = (token) => {
    

   return {
    get: requester.bind(null, 'GET', token),
    post: requester.bind(null, 'POST', token),
    put: requester.bind(null, 'PUT', token),
    patch: requester.bind(null, 'PATCH', token),
    delete: requester.bind(null, 'DELETE', token),
   }; 
};