
const domain = "http://localhost:3030";

export async function request(method, uri, data, accessToken) {

    let requestObj = {
        method,
        headers: { "content-type": "application/json" }
    }


    if (method === "get") {
        requestObj.body = {};
    }
    else if (method === "post" || method === "put") {
        requestObj.body = JSON.stringify(data);
    }


    if (accessToken) {
        requestObj.headers["X-Authorization"] = accessToken;
    }


    try {
        let responce = await fetch(domain + uri, requestObj);

        if(responce.status === 204) { 
            return null;
        }

        if(!responce.ok) {
            const msg = await responce.json();
            throw new Error(msg)
        }
        let result = await responce.json(); 


        return result;

    } catch (error) {
        alert(error.message);
        throw error;
    }

}