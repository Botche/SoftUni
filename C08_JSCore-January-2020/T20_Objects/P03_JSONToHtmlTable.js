function jsonToHtmlTable(input) {

    let tableElement = content => `<table>\n${content}<table>`;
    let rowElement = content => `\t<tr>${content}<tr>\n`;
    let tableHeaderElement = content => `<th>${content}<th>`;
    let tableDataElement = content => `<td>${content}<td>`;

    let result = rowElement(Object.keys(input[0]).map(key => tableHeaderElement(escapeHtml(String(key)))).join(''));

    result += input.reduce((accRows, row) => {
        let content = '';

        content = Object.values(row).map(key => tableDataElement(escapeHtml(String(key)))).join('');

        return accRows + rowElement(content);
    }, '')

    console.log(tableElement(result));

    function escapeHtml(unsafe) {
        return unsafe
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#39;");
    }
}

// Solution for judge
function solve(json) {
    let text = JSON.parse(json);

    let result = "";

    result += "<table>\n";
    result += "   <tr>";

    for (const key in text[0]) {
        if (text[0].hasOwnProperty(key)) {
            result += `<th>${key}</th>`;
        }
    }

    result += "</tr>\n";

    for (let i = 0; i < text.length; i++) {
        const element = text[i];
        result += "   <tr>";

        for (const value in element) {
            let cellValue = String(element[value])
                .replace(/&/gim, '&amp;')
                .replace(/</gim, '&lt;')
                .replace(/>/gim, '&gt;')
                .replace(/"/gim, '&quot;')
                .replace(/'/gim, '&#39;');

            result += `<td>${cellValue}</td>`;
        }

        result += "</tr>\n"
    }

    result += "</table>";

    console.log(result);
}

jsonToHtmlTable([{ "Name": "Pesho <div>-a", "Age": 20, "City": "Sofia" }, { "Name": "Gosho", "Age": 18, "City": "Plovdiv" }, { "Name": "Angel", "Age": 18, "City": "Veliko Tarnovo" }]);