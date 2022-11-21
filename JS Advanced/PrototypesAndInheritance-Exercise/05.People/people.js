function solution() {
    class Employee {
        constructor(name, age) {
            if(new.target === Employee){
                throw new Error("Cannot make instance of abstract class Employee.")
            }
            this.name = name;
            this.age = age;

            this.salary = 0;
            this.tasks = [];

            this._currentTask = 0;
        };


        _print(arg) {
            console.log(arg.toString());
        };


        work() {
            if (this._currentTask >= this.tasks.length) {
                this._currentTask = 0;
            }
            this._print(this.tasks[this._currentTask]);
            this._currentTask++;
        };


        getSalary(){
            return this.salary;
        }


        collectSalary() {
            this._print(`${this.name} received ${this.getSalary()} this month.`);
        }

    }




    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [`${this.name} is working on a simple task.`]
        }
    }



    class Senior extends Employee{
        constructor(name, age) {
            super(name, age);
            this.tasks = [  `${this.name} is working on a complicated task.`,
                            `${this.name} is taking time off work.`,
                            `${this.name} is supervising junior workers.`];
        }
    }



    class Manager extends Employee{
        constructor(name, age) {
            super(name, age);
            this.dividend = 0
            this.tasks = [  `${this.name} scheduled a meeting.`,
                            `${this.name} is preparing a quarterly report.`];
        }


        getSalary(){
            return super.getSalary() + this.dividend;
        }
    }



    return {Employee, Junior, Senior, Manager};
}