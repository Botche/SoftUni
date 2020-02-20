class Stringer {
    constructor(text, length) {
        this.innerString = text;
        this.innerLength = length;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        if (this.innerLength - length < 0) {
            this.innerLength = 0;

            return;
        }

        this.innerLength -= length;
    }

    toString() {
        let result = this.innerString.substring(0, this.innerLength);

        if (this.innerLength < this.innerString.length) {
            result += '...';
        }

        return result;
    }
}








let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
