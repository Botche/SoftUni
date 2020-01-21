function addAndRemoveElementsFromArray(array){
    let result = [];

    array.forEach((element, index) => {
        element == 'add' ? result.push(index + 1) : result.pop();
    });

    return result.length != 0 ? result.join('\r\n') : 'Empty';
}

console.log(addAndRemoveElementsFromArray(['add', 
'add', 
'add', 
'add']
));