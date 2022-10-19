function getFibonator(){
    let F1 = 0;
    let F2 = 1;
    let isFirst = true;
    return ()=>{
        if(isFirst){
            isFirst = false;
            return 1;
        }
        let Fn = F1 + F2;
        F1=F2;
        F2=Fn;
        return Fn;
    }
}

let fib = getFibonator();
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());