function printEveryNthElementFromArray(array){
    let delimiter = array.pop();

    let result = array.filter((_,i) => (i % delimiter == 0)).join('\r\n');

    return result;
}

console.log(printEveryNthElementFromArray(['5', 
'20', 
'31', 
'4', 
'20', 
'2']
));