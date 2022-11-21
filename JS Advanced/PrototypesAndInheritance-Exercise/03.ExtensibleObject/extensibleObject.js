
function extensibleObject() {

    obj = Object.create(null);
    obj.extend = function (tmp) {
        Object.setPrototypeOf(this, tmp);
        Object.assign(this,tmp);
    }
    return obj;
}

const template = {
    extensionMethod: function () { },
    extensionProperty: 'someString'
}
obj = extensibleObject();
obj.extend(template);

const template2 = {
    extensionMethod2: function () { },
    extensionProperty2: 'someString2'
}

obj.extend(template2);
console.log(Object.getPrototypeOf(obj));