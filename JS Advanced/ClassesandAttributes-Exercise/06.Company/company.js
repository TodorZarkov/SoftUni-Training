class Company {

    constructor() {
        this.departments = {};
    }


    addEmployee(name, salary, position, department) {

        if (!(name)) throw "Invalid input!";
        if (salary === null || salary === undefined || salary === "") throw "Invalid input!";
        if (!(position)) throw "Invalid input!";
        if (!(department)) throw "Invalid input!";

        if (salary < 0) {
            throw "Invalid input!";
        }


        let employee = { name, salary, position };
        if (!this.departments.hasOwnProperty(department)) {
            this.departments[department] = [];
        }
        this.departments[department].push(employee);

        return `New employee is hired. Name: ${name}. Position: ${position}`
    }

    bestDepartment() {
        let bestSalary = 0;
        let bestDep;
        for (let depKey in this.departments) {
            let salary = this.departments[depKey].reduce((prev, next) => prev + next.salary , 0)
            salary /= this.departments[depKey].length;
            if (salary > bestSalary) {
                bestSalary = salary;
                bestDep = depKey;
            }
        }
        
        this.departments[bestDep].sort((a,b) => a.name.localeCompare(b.name)).sort((a,b)=>b.salary - a.salary);

        let result = `Best Department is: ${bestDep}\nAverage salary: ${bestSalary.toFixed(2)}\n`;

        for(let employee of this.departments[bestDep]){
            result += `${employee.name} ${employee.salary} ${employee.position}\n`
        }

        return result.trimEnd();
    }


}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());