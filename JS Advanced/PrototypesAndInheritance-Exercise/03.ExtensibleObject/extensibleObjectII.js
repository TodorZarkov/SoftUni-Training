function extensibleObjectII(){
    let proto = {};
    let obj = Object.create(proto);
    obj.extend = function (tmp) {
        Object.entries(tmp).forEach(([k,v])=>{
            if (typeof v === 'function') {
                proto[k] = v;
            }
            else{
                obj[k] = v;
            }
        })
    }
    return obj;
}

const template = {
    extensionMethod: function () { },
    extensionProperty: 'someString'
}
obj = extensibleObjectII();
obj.extend(template);

const template2 = {
    extensionMethod2: function () { },
    extensionProperty2: 'someString2'
}

obj.extend(template2);
console.log(Object.getPrototypeOf(obj));