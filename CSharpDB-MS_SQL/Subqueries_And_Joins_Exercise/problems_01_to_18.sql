--problem 01. Employee Address
USE SoftUni
GO
SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID = e.AddressID
ORDER BY e.AddressID


