function solve() {
    let key = document.getElementById("string").value;
    let message = document.getElementById("text").value;
    let result = document.getElementById("result");

    let saveMesaage = message.match(`${key}(.+)${key}`)[1];

    let northRegex = /(north).*?([\d]{2})[^,]*?,[^,]*?([\d]{6})/igm;
    let eastRegex = /(east).*?([\d]{2})[^,]*?,[^,]*?([\d]{6})/igm;


    let east;
    let north;

    let eastMatch = eastRegex.exec(message);
    let northMathch = northRegex.exec(message);
    while (eastMatch) {
        east = `${eastMatch[2]}.${eastMatch[3]}`;
        eastMatch = eastRegex.exec(message);
    }
    while (northMathch) {
        north = `${northMathch[2]}.${northMathch[3]}`;
        northMathch = northRegex.exec(message);
    }

    result.innerHTML = `
    <p>${north} N</p>
    <p>${east} E</p>
    <p>Message: ${saveMesaage}</p>`
}