function timeToWalk(steps, lengthOfFootstep, speed) {
    let kmWalked = steps * lengthOfFootstep;
    let secondsBreak = Math.floor(kmWalked / 500) * 60;
    let speedInMs = speed * 1000 / 3600;
    let secondsWalking = kmWalked / speedInMs + secondsBreak;

    let timeMin = Math.floor(secondsWalking / 60);
    let timeSec = Math.round(secondsWalking - (timeMin * 60));
    let timeHr = Math.floor(secondsWalking / 3600);

    console.log((timeHr < 10 ? "0" : "") + timeHr + ":" + 
    (timeMin < 10 ? "0" : "") + (timeMin) + ":" + 
    (timeSec < 10 ? "0" : "") + timeSec);
}

timeToWalk(4000, 0.60, 5);