function arrayMap(arr, func){
    return arr.reduce((acc, num) => {
        let calculated = func(num);
        acc.push(calculated);

        return acc;
    }, []);
}


let nums = [1,2,3,4,5];
console.log(arrayMap(nums,(item)=> item * 2)); // [ 2, 4, 6, 8, 10 ]
