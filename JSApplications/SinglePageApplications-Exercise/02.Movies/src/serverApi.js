
const domain = "http://localhost:3030";

async function request(method, uri, data, accessToken) {

    let requestObj = {
        method,
        headers: { "content-type": "application/json" }
    }


    if (method === "post" || method === "put" || method === "patch") {
        requestObj.body = JSON.stringify(data);
    }


    if (accessToken) {
        requestObj.headers["X-Authorization"] = accessToken;
    }


    try {
        let responce = await fetch(domain + uri, requestObj);


        if (responce.status === 204) {
            return null;
        }

        if (!responce.ok) {
            const err = await responce.json();
            throw new Error(err.message);
        }
        let result = await responce.json();


        return result;

    } catch (error) {
        //alert(error.message);
        throw error;
    }

}

export let get = request.bind(null, "get");
export let post = request.bind(null, "post");
export let put = request.bind(null, "put");
export let del = request.bind(null, "delete");