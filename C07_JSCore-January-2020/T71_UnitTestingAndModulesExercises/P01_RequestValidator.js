function reuqestValidator(reuqestValidator){
    const validMethods = ['GET', 'POST', 'DELETE', 'CONNECT']; 
    const uriPattern = /^(\*|[a-zA-Z\d\.]+)$/gim;
    const validHttpVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const messagePattern = /^[^<>\\&'"]*$/gim;

    if (!validMethods.includes(reuqestValidator.method)) {
        throw new Error("Invalid request header: Invalid Method");
    }

    if (!uriPattern.test(reuqestValidator.uri) || !reuqestValidator.hasOwnProperty("uri")) {
        throw new Error("Invalid request header: Invalid URI");
    }

    if (!validHttpVersions.includes(reuqestValidator.version)) {
        throw new Error("Invalid request header: Invalid Version");
    }

    if (!messagePattern.test(reuqestValidator.message) || !reuqestValidator.hasOwnProperty("message")) {
        throw new Error("Invalid request header: Invalid Message");
    }

    return reuqestValidator;
}


console.log(reuqestValidator({
    method: 'POST',
    uri: 'home.bash',
    version: 'HTTP/2.0'
}));