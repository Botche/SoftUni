class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {

        if (!username ||
            !salary ||
            !position ||
            !department) {
            throw Error('Invalid input!');
        }

        if (salary < 0) {
            throw Error('Invalid input!');
        }

        if (!Object.keys(this.departments).includes(department)) {
            this.departments[department] = [];
        }

        this.departments[department].push({
            Username: username,
            Salary: salary,
            Position: position
        });

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDepartment = Object.keys(this.departments)
            .reduce((acc, department) => {
                let countOfPeople = this.departments[department].length;
                let salaryForEveryPerson = this.departments[department].reduce((acc, person) => {
                    acc += person.Salary;

                    return acc;
                }, 0);

                let averageSalaryPerPerson = salaryForEveryPerson / countOfPeople;

                if (acc.Salary < averageSalaryPerPerson) {
                    acc = {
                        Department: department,
                        Salary: averageSalaryPerPerson
                    };
                }

                return acc;
            }, {Salary: 0});

        let result = [];

        result.push(`Best Department is: ${bestDepartment.Department}`);
        result.push(`Average salary: ${bestDepartment.Salary.toFixed(2)}`);
        this.departments[bestDepartment.Department]
            .sort((a,b) => {
                if (b.Salary - a.Salary === 0) {
                    return a.Username.localeCompare(b.Username);
                }

                return b.Salary - a.Salary;
            })

            .forEach(employee => result.push(`${employee.Username} ${employee.Salary} ${employee.Position}`));

        return result.join('\n');
    }
}


let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Human resources");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
