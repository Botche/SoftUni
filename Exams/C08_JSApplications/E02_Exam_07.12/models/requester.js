const BASE_URL = 'https://my-project-3a3c3.firebaseio.com/'; // type your url here

function fetchRequest(endpoint, headers) {
    const url = `${BASE_URL}/${endpoint}`;

    return fetch(url, headers)
        .then(handleError)
        .then(serializeData)
        .catch(error => console.log(`Error - ${error.message}`));
}

function handleError(response) {
    if (!response.ok) {
        throw new Error('Something went wrong');
    }

    return response;
}

function serializeData(data) {
    return data.json();
}

function makeHeaders(method, data) {
    const headers = {
        method: method,
        headers: {
            'Content-Type': 'application/json',
        },
    };

    if (method === 'POST' || method === 'PATCH') {
        headers.body = JSON.stringify(data);
    }

    return headers;
}

function get(endpoint) {
    const headers = makeHeaders('GET');

    return fetchRequest(endpoint, headers);
}

function create(endpoint, data) {
    const headers = makeHeaders('POST', data);

    return fetchRequest(endpoint, headers);
}

function update(endpoint, data) {
    const headers = makeHeaders('PATCH', data);

    return fetchRequest(endpoint, headers, data);
}

function del(endpoint) {
    const headers = makeHeaders('DELETE');

    return fetchRequest(endpoint, headers);
}

export default {
    get,
    create,
    update,
    del,
}