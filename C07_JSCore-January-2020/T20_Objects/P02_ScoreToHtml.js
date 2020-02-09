function toHtml(json) {
    const array = JSON.parse(json);

    let html = '<table>\n';
    html += '   <tr><th>name</th><th>score</th></tr>\n';

    for (const obj of array) {
        html += `   <tr><td>${escapeHtml(String(obj.name))}</td><td>${escapeHtml(String(obj.score))}</td></tr>\n`;
    }

    html += '</table>';

    console.log(html);


    function escapeHtml(unsafe) {
        return unsafe
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#39;");
    }
}

toHtml(['[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]']);