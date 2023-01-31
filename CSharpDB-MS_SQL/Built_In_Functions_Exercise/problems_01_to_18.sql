--problem 01. Find Names of All Employees by First Name
USE SoftUni
GO

SELECT FirstName, LastName
FROM Employees
WHERE LEFT(FirstName,2) = 'Sa'


--problem 02. Find Names of All Employees by Last Name
SELECT FirstName, LastName
FROM Employees
WHERE CHARINDEX('ei', LastName) <> 0