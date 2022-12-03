
const domain = "http://localhost:3030";
//depends on user stringified  object in session storage and user.accessToken!!!

async function request(method, uri, data) {
    const user = JSON.parse(sessionStorage.getItem("user"));
    let requestObj = {
        method,
        headers: { "content-type": "application/json" }
    }


    if (method === "post" || method === "put" || method === "patch") {
        requestObj.body = JSON.stringify(data);
    }
    if (user) {
        requestObj.headers["X-Authorization"] = user.accessToken;
    }

    try {
        let responce = await fetch(domain + uri, requestObj);

        if (responce.status === 204) {
            return responce;
        }

        if (!responce.ok) {
            if(responce.status === 403) {
                sessionStorage.removeItem("user");
            }
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