function jsonTable(json){
    let tableElement = content => `<table>\n${content}</table>`;
    let rowElement = content => `\t<tr>\n${content}\t</tr>\n`;
    let tableDataElement = content => `\t\t<td>${content}</td>\n`;

    let result = '';

    result += json.reduce((accRows, row) => {
        let obj = JSON.parse(row);
        
        let content = Object.values(obj).map(key => tableDataElement(escapeHtml(String(key)))).join('');

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

jsonTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
);