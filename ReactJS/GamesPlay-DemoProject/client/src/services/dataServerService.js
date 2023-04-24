const server = `http://localhost:3030`;

const requester = async (method, endpoint, data) => {

    const response = await fetch(server + endpoint);
    //todo: handle 404
    const result = response.status === 204 ? {} : await response.json();
    return Object.values(result);

};


export const get = requester.bind(null, 'GET');