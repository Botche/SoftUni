function checkIfValid(points) {
    let x1 = Number(points[0]);
    let y1 = Number(points[1]);
    let x2 = Number(points[2]);
    let y2 = Number(points[3]);

    let result = [];

    let firstDistance = Math.sqrt(x1 ** 2 + y1 ** 2); 
    if (Number.isInteger(firstDistance)) {
        result.push(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        result.push(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    let secondDistance = Math.sqrt(x2 ** 2 + y2 ** 2); 
    if (Number.isInteger(secondDistance)) {
        result.push(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        result.push(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    let horizontalDist = Math.pow(x2 - x1, 2);
    let verticalDist = Math.pow(y2 - y1, 2);

    let distanceBetweenPoints = Math.sqrt(horizontalDist + verticalDist);
    if (Number.isInteger(distanceBetweenPoints)) {
        result.push(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        result.push(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }

    console.log(result.join('\r\n'))
}

checkIfValid([3, 0, 0, 4]);
checkIfValid([2, 1, 1, 1]);