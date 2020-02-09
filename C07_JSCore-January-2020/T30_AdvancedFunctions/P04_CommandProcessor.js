function commandProcessor() {
    let text = '';

    function append(textToAppend) {
        text += textToAppend;
    }

    function removeStart(count) {
        text = text.substring(count);
    }

    function removeEnd(count) {
        text = text.substring(0,text.length - count);
    }

    function print() {
        console.log(text);
    }

    return {
        append,
        removeStart,
        removeEnd,
        print
    }
}

let firstZeroTest = commandProcessor();

firstZeroTest.append('hello');
firstZeroTest.print();
firstZeroTest.append('again');
firstZeroTest.print();
firstZeroTest.removeStart(3);
firstZeroTest.print();
firstZeroTest.removeEnd(4);
firstZeroTest.print();