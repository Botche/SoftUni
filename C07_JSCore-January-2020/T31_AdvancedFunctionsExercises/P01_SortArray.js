function sortArray(arr, sortCriteria) {
    if (sortCriteria === 'asc') {
        arr.sort((a, b) => a - b);
    } else {
        arr.sort((a, b) => b - a);
    }

    return arr;
}