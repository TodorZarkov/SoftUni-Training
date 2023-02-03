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
CREATE PROC usp_GetTownsStartingWith(@startString NVARCHAR(MAX))
AS
SELECT
    t.Name AS Town
FROM Towns AS t
WHERE LEFT(t.Name,LEN(@startString)) = @startString
GO

--problem 04. Employees from Town
CREATE PROC usp_GetEmployeesFromTown(@townName NVARCHAR(200))
AS
SELECT  
    e.FirstName
    ,e.LastName
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
WHERE t.Name = @townName
GO

--problem 05. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
    DECLARE @result VARCHAR(7)
    IF (@salary < 30000)
        SET @result = 'Low'
    ELSE IF @salary BETWEEN 30000 AND 50000
        SET @result = 'Average'
    ELSE
        SET @result = 'High'
    RETURN @result
END

GO
--problem 06. Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel(@levelOfSalary VARCHAR(7))
AS
SELECT
    e.FirstName AS [First Name]
    ,e.LastName AS [Last Name]
FROM Employees AS e
WHERE @levelOfSalary = dbo.ufn_GetSalaryLevel(e.Salary)
GO

--problem 07. Define Function
CREATE FUNCTION dbo.ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
    DECLARE @result BIT = 1
    DECLARE @i INT = 0
    WHILE @i < LEN(@word)
    BEGIN
        SET @i += 1 
        IF CHARINDEX(SUBSTRING(@word,@i,1),@setOfLetters) = 0
        BEGIN
            SET @result = 0
            BREAK
        END
    END
    RETURN @result
END
GO


DECLARE @isIn BIT
SET @isIn = dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT @isIn

--problem 08. *Delete Employees and Departments