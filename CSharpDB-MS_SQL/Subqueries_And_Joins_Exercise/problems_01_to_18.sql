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
