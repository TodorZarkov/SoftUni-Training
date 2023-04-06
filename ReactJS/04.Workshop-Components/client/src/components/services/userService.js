const endpoint = 'http://localhost:3005/api/users'

export async function getAll() {
    const responce = await fetch(endpoint)
    //todo: server up validation
    const data = await responce.json();
    //todo: content available validation
    data.users.forEach(u => {
        u.createdAt = new Date(u.createdAt);
        u.updatedAt = new Date(u.updatedAt);
    });
    return data;
}

export async function getInfo(id) {
    const responce = await fetch (endpoint + `\\${id}`);
    //todo: server up validation
    const data = await responce.json();
     //todo: content available validation
    const userRaw = {...data.user};
    const createdOn = new Date(userRaw.createdAt);
    const updatedOn = new Date(userRaw.updatedAt);
    const {address,  ...userInfo} = userRaw;
    userInfo.createdAt = createdOn;
    userInfo.updatedAt = updatedOn;
    return {...userInfo, ...address};
}

export async function deleteUser(id) {
    const responce = await fetch(endpoint + '\\' + id, {
        method: "DELETE"
    });
    //todo: if server error
    //todo: if user not exist error
}

export async function update(id, data) {
    const {vfirstName, lastName, email, imageUrl, phoneNumber, ...address} = data;
    const {country, city, street, streetNumber, ...userInfo} = data;
    const user = {...userInfo, address};

    const responce = await fetch(endpoint + '\\' + id, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(user),
    });
    const updatedUser = (await responce.json()).user;
    updatedUser.createdAt = new Date(updatedUser.createdAt);
    updatedUser.updatedAt = new Date(updatedUser.updatedAt);
    return updatedUser;
}
