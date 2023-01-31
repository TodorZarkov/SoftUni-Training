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

--problem 03. Find First Names of All Employees
SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3,10) AND YEAR(HireDate) BETWEEN 1995 AND 2005

--problem 04. Find All Employees Except Engineers
SELECT FirstName, LastName
FROM Employees
WHERE CHARINDEX('engineer', JobTitle) = 0

--problem 05. Find Towns with Name Length
SELECT [Name]
FROM Towns
WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name]

--problem 06. Find Towns Starting With
SELECT TownID, [Name] 
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

--problem 07. Find Towns Not Starting With
SELECT TownID, [Name] 
FROM Towns
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]

--problem 08. Create View Employees Hired After 2000 Year
GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
    SELECT FirstName, LastName
    FROM Employees
    WHERE YEAR(HireDate) > 2000
GO

