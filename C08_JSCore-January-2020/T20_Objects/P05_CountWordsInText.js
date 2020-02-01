function countWordsInText(text) {
    let splittedText = text[0].split(/\W+/g).filter(x => x != '');

    const result = splittedText.reduce((acc, element) => {
        if (acc[element]) {
            acc[element]++;
        } else {
            acc[element] = 1;
        }

        return acc;
    }, {});

    console.log(JSON.stringify(result));
}

countWordsInText([ "Far too slow, you're far too slow." ])