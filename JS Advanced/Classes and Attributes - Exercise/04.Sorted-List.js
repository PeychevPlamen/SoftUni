class List {
    constructor() {
        this.numbers = [];
        this.size = this.numbers.length;
    }


    add(element) {
        if (typeof element !== 'number') {
            throw new Error('Element to add must be a number');
        } else {
            this.numbers.push(element);
            this.numbers.sort((a, b) => a - b);
            this.size++;
        }

        return this;
    }

    remove(index) {
        if (index >= 0 && index < this.numbers.length) {
            this.numbers.sort((a, b) => a - b).splice(index, 1);
            this.size--;
        } else {
            throw new Error('Invalid index');
        }

        return this;
    }

    get(index) {
        if (index >= 0 && index < this.numbers.length) {
            return this.numbers[index];
        } else {
            throw new Error('Invalid index');
        }

    }

}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size);
