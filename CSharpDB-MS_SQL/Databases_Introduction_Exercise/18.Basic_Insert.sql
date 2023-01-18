USE SoftUni
GO

INSERT INTO Towns
VALUES 
    ('Sofia'),
    ('Plovdiv'),
    ('Varna'),
    ('Burgas')

INSERT INTO Departments
VALUES 
    ('Engineering'), 
    ('Sales'), 
    ('Marketing'), 
    ('Software Development'), 
    ('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
VALUES
    ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-2-1', 3500.00, NULL),
    ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-3-2', 4000.00, NULL),
    ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-8-28', 525.25, NULL),
    ('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-9', 3000.00, NULL),
    ('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-8-28', 599.88, NULL)