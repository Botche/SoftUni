function rotateArray(array){
    let number = array.pop();

    let timesOfRotation = number % array.length;

    for (let i = 0; i < timesOfRotation; i++) {
        array.unshift(array.pop());
    }

    return array.join(' ');
}

console.log(rotateArray(['Banana', 
'Orange', 
'Coconut', 
'Apple', 
'5']
));