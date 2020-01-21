function excractIncreasingSubsequence(array = []){
    let result = array.reduce((acc,currElement) => {

        const lastElement = acc[acc.length - 1];

        if (currElement >= lastElement || lastElement === undefined) {
            acc.push(currElement);
        }

        return acc;
    }, []);

    return result.join('\r\n');
}

console.log(excractIncreasingSubsequence([20, 
    3, 
    2, 
    15,
    6, 
    1]
    
)); 