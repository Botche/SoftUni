function roadRadar(arrayOfElement) {
    let speed = Number(arrayOfElement[0]);
    let typeOfArea = String(arrayOfElement[1]);
    let maxSpeedOfArea = 0;
    let diffInSpeed = 0;
    let result = '';

    switch (typeOfArea) {
        case 'motorway':
            maxSpeedOfArea = 130;
            diffInSpeed = speed - maxSpeedOfArea;

            if (diffInSpeed <= 0) {
                break;
            }
            else if (diffInSpeed <= 20) {
                result = 'speeding';
            }
            else if (diffInSpeed <= 40) {
                result = 'excessive speeding';
            }
            else {
                result = 'reckless driving';
            }

            break;
        case 'interstate':
            maxSpeedOfArea = 90;
            diffInSpeed = speed - maxSpeedOfArea;

            if (diffInSpeed <= 0) {
                break;
            }
            else if (diffInSpeed <= 20) {
                result = 'speeding';
            }
            else if (diffInSpeed <= 40) {
                result = 'excessive speeding';
            }
            else {
                result = 'reckless driving';
            }
            break;
        case 'city':
            maxSpeedOfArea = 50;
            diffInSpeed = speed - maxSpeedOfArea;

            if (diffInSpeed <= 0) {
                break;
            }
            else if (diffInSpeed <= 20) {
                result = 'speeding';
            }
            else if (diffInSpeed <= 40) {
                result = 'excessive speeding';
            }
            else {
                result = 'reckless driving';
            }
            break;
        case 'residential':
            maxSpeedOfArea = 20;
            diffInSpeed = speed - maxSpeedOfArea;

            if (diffInSpeed <= 0) {
                break;
            }
            else if (diffInSpeed <= 20) {
                result = 'speeding';
            }
            else if (diffInSpeed <= 40) {
                result = 'excessive speeding';
            }
            else {
                result = 'reckless driving';
            }
            break;
        default:
            break;
    }

    console.log(result);
}

roadRadar([200, 'motorway']);