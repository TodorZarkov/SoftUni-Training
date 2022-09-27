'use strict';
function genSortedList() {
    let obj = {
        arr: [],
        size: 0,
        add(element) {
            if (typeof element !== 'number') return;
            this.arr.push(element);
            this.arr.sort((a, b) => a - b);
            this.size++;
        },
        remove(index) {
            if (index < this.size && index >= 0 && typeof index === 'number') {
                index = Math.round(index);
                this.arr = this.arr.filter((value, ind) => ind !== index);
                this.arr.sort((a, b) => a - b);
                this.size--;
            }
        },
        get(index) {
            if (index < this.size && index >= 0 && typeof index === 'number') {
                index = Math.round(index);
                return this.arr[index];
            }
        }
    }

    return obj;
}

let list = genSortedList();
list.add(4);
list.remove(-1);
list.add(8);
console.log(list.get(1));