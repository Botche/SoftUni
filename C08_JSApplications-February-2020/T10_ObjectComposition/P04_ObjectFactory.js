function objectFactory(string) {
    let parsedInput = JSON.parse(string);

    let obj = {};
    for (const iterator of parsedInput) {
        Object.assign(obj, iterator);
    }

    return obj;
}

console.log(objectFactory(`[{"canMove": true},{"canMove":true, "doors": 4},{"capacity": 5}]`));