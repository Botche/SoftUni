function magicMatrices(array){
    const firstRowSum = array[0].reduce((a,b) => a + b);
    let isMagic = true;

    debugger;
    for (let row = 0; row < array.length; row++) {

        const rowSum = array[0].reduce((a,b) => a + b);
        
        let colSum = 0;
        for (let col = 0; col < array.length; col++) {
            colSum += array[col][row]; 
        }

        if (firstRowSum !== rowSum || firstRowSum !== colSum) {
            isMagic = false;
            break;
        }
    }

    return isMagic;
} 

console.log(magicMatrices(([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   )));