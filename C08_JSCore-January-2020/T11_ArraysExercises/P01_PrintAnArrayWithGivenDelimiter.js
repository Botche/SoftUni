function printAnArrayWithGivenDelimiter(array){
    let delimiter = array[array.length - 1];
    
    let result = array.slice(0,-1).join(delimiter);
    
    return result;
}

console.log(printAnArrayWithGivenDelimiter(['One', 
'Two', 
'Three', 
'Four', 
'Five', 
'-']
));