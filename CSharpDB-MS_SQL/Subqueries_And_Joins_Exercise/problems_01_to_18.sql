--problem 01. Employee Address
USE SoftUni
GO
SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID = e.AddressID
ORDER BY e.AddressID

--problem 02. Addresses with Towns
SELECT TOP(50) e.FirstName, e.LastName, t.Name AS Town, a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID = e.AddressID
JOIN Towns AS t
ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName

--problem 03. Sales Employees
SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID AND d.Name = 'Sales'
ORDER BY e.EmployeeID

--problem 04. Employee Departments
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID AND Salary > 15000
ORDER BY e.DepartmentID

--problem 05. Employees Without Projects
SELECT TOP(3) e.EmployeeID, e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

--problem 06. Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1.1.1999' AND d.Name IN('Sales' , 'Finance')
ORDER BY e.HireDate

