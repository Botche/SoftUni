class List{
    constructor() {
        this.arr = [];
        this.size = 0;
    }

    add(elemenent){
        this.arr.push(elemenent);
        this.size = this.arr.length;

        return this.arr;
    }

    remove(index){
        if (index < 0 || index > this.size) {
            return ;
        }

        this.arr.sort((a,b) => a - b);

        this.arr.splice(index, 1);
        this.size = this.arr.length;

        return this.arr;
    }

    get(index) {
        if (index < 0 || index > this.size) {
            return;
        }

        this.arr.sort((a,b) => a - b);

        return this.arr[index];
    }
}