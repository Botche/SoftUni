function circleArea(circleRadius) {
    if (Number(circleRadius) !== circleRadius) {
        return `We can not calculate the circle area, because we receive a ${typeof (circleRadius)}.`;
    }
    
    let result = Math.PI * circleRadius ** 2;

    return Math.round(result * 100) / 100;
}

console.log(circleArea('as'))