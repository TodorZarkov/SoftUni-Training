class ListOfNumbers {
    _list = [];
    size = 0;
    add(element) {
        if (isNaN(element)) {
            throw 'Parameter is not a number.'
        }
        this._list.push(element);
        this._list.sort((a, b) => a - b);
        this.size++;
    }
    remove(index) {
        if (isNaN(index) || index % 1 !== 0) {
            throw 'The index must be integer number.'
        }
        if (index < 0 || index > this.size - 1) {
            throw 'Index is out of range.'
        }
        this._list.splice(index, 1);
        this._list.sort((a, b) => a - b);
        this.size--;
    }
    get(index) {
        if (isNaN(index) || index % 1 !== 0) {
            throw 'The index must be integer number.'
        }
        if (index < 0 || index > this.size - 1) {
            throw 'Index is out of range.'
        }
        return this._list[index];
    }

}

let list = new ListOfNumbers();
list.add(2.35);
list.add(2.36);
list.add(88);
list.add(1.35);
list.add(0);
console.log(list.get(2));
for(let i =0;i<list.size;i++){
    console.log(list.get(i));
}