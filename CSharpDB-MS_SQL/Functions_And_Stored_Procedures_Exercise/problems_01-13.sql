--problem 01. Employees with Salary Above 35000
USE SoftUni
GO

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
SELECT 
    e.FirstName
    ,e.LastName
FROM Employees AS e
WHERE e.Salary > 35000
GO

--problem 02. Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@salaryThreshold DECIMAL(18, 4))
AS
SELECT 
    e.FirstName
    ,e.LastName
FROM Employees AS e
WHERE e.Salary >= @salaryThreshold
GO

--problem 03. Town Names Starting With
USE [SoftUni]
GO
CREATE PROC usp_GetTownsStartingWith(@startString NVARCHAR(MAX))
AS
SELECT
    t.Name AS Town
FROM Towns AS t
WHERE LEFT(t.Name,LEN(@startString)) = @startString
GO

--problem 04. Employees from Town