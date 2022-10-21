function validate(request) {
    const methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    //const uriPattern = /^[a-zA-Z0-9\-\.]*$|^\*$/g;
    const uriPattern = /^[a-zA-Z0-9\-\.]+$|^\*$/g;//=>/w. === a-zA-Z0-9\-\.


    if (!request.hasOwnProperty('method') || methods.indexOf(request.method) === -1) {
        throw new Error('Invalid request header: Invalid Method');
    }

    if (!request.hasOwnProperty('uri') || request.uri.match(uriPattern) === null) {
        throw new Error('Invalid request header: Invalid URI')
    }

    if (!request.hasOwnProperty('version') || !versions.includes(request.version)) {
        throw new Error('Invalid request header: Invalid Version')
    }

    if (!request.hasOwnProperty('message') || request.message.match(/[\<\>\\\&\'\"]+/gm) !== null) {
        throw new Error('Invalid request header: Invalid Message')
    }

    return request;

}


validate({
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*'
});