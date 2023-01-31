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

--problem 09. Length of Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LEN([LastName]) = 5

--problem 10. Rank Employees by Salary
SELECT EmployeeID, FirstName, LastName, Salary
    ,DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--problem 11. Find All Employees with Rank 2
SELECT EmployeeID, FirstName, LastName, Salary, Rank
FROM    (SELECT EmployeeID, FirstName, LastName, Salary
        ,DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
        FROM Employees
        WHERE Salary BETWEEN 10000 AND 50000) AS InnerQuery
WHERE Rank = 2 
ORDER BY Salary DESC

--problem 12. Countries Holding 'A' 3 or More Times
USE [Geography]
SELECT CountryName AS [Country Name], IsoCode AS [ISO Code]
FROM Countries
WHERE UPPER(CountryName) LIKE '%A%A%A%' 
ORDER BY IsoCode

--problem 13. Mix of Peak and River Names
SELECT Peaks.PeakName , Rivers.RiverName 
    , LOWER( CONCAT(Peaks.PeakName, STUFF(Rivers.RiverName,1,1,'') ) ) AS Mix
FROM Peaks, Rivers
WHERE LOWER(RIGHT(Peaks.PeakName,1)) = LOWER(LEFT(Rivers.RiverName,1))
ORDER BY Mix
 
--problem 14. Games From 2011 and 2012 Year
USE Diablo
GO
SELECT TOP(50) [Name], FORMAT([Start],'yyyy-MM-dd') AS [Start]
FROM Games
WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]


--problem 15. User Email Providers
SELECT Username, STUFF(Email, 1, CHARINDEX('@', Email), '') AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

--problem 16. Get Users with IP Address Like Pattern
SELECT Username, IpAddress AS [IP Address]
FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username