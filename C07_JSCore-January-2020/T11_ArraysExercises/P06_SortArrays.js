function sortArray(array) {
    return array
        .sort((a, b) =>
            a.length - b.length ||
            a.toLowerCase().localeCompare(b.toLowerCase()))
        .join('\r\n');
}

console.log(sortArray(['test',
    'Deny',
    'omen',
    'Default']
));