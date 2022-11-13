class Company {

    constructor() {
        this.departments = {};
    }


    addEmployee(name, salary, position, department) {

        if (!name || !position || !department) {
            throw "Invalid input!";
        }
        if (salary === null || salary === undefined || salary === "") {
            throw "Invalid input!";
        }

        if (salary < 0) {
            throw "Invalid input!";
        }


        let employee = { name, salary, position };
        if (!this.departments.hasOwnProperty(department)) {
            this.departments[department] = {
                avgSalary: 0,
                sumSalary: 0,
                employees: []
            };
        }
        this.departments[department].employees.push(employee);
        this._updateDepartment(this.departments[department], salary);

        return `New employee is hired. Name: ${name}. Position: ${position}`
    }

    _updateDepartment(department, salary) {
        department.sumSalary += salary;
        department.avgSalary = department.sumSalary / department.employees.length;
    }

    bestDepartment() {
        let bestDep = Object.entries(this.departments).sort(([depA, empA], [depB, empB]) => empB.avgSalary - empA.avgSalary)[0];
        let bestSalary = bestDep[1].avgSalary;
        let bestDepName = bestDep[0];


        let result = `Best Department is: ${bestDepName}\nAverage salary: ${bestSalary.toFixed(2)}\n`;

        bestDep[1].employees.sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name));

        for (let employee of bestDep[1].employees) {
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