function uniqueSequences(input) {
    let arrays = [];
    let items = input.map(i => JSON.parse(i));

    for (const array of items) {
        let sum = array.reduce((a, b) => a + b, 0);

        if (!arrays.some((x) => x.reduce((a, b) => a + b, 0) === sum)) {
            arrays.push(array);
        }
    }

    console.log(arrays
        .sort((a, b) => a.length - b.length)
        .map(array => `[${array
            .sort((a, b)=>b - a)
            .join(", ")}]`)
        .join("\n"));
}

uniqueSequences(["[-3, -2, -1, 0, 1, 2, 3, 4]",
    "[10, 1, -17, 0, 2, 13]",
    "[4, -3, 3, -2, 2, -1, 1, 0]"]
);