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
GO

--problem 08. *Delete Employees and Departments
BACKUP DATABASE SoftUni
TO DISK = '/var/opt/mssql/data/softuni-backup-4-2-2023.bak'
GO



CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS

ALTER TABLE Departments 
ALTER COLUMN ManagerID INT NULL

DELETE FROM  EmployeesProjects
WHERE EmployeeID IN (
    SELECT e.EmployeeID  FROM Employees AS e
    WHERE e.DepartmentID = @departmentId
)

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (
    SELECT e.EmployeeID  FROM Employees AS e
    WHERE e.DepartmentID = @departmentId
)

UPDATE Employees
SET ManagerID = NULL
WHERE EmployeeID IN (
    SELECT e.EmployeeID  FROM Employees AS e
    WHERE e.DepartmentID = @departmentId
)

ALTER TABLE Employees NOCHECK CONSTRAINT [FK_Employees_Employees]

DELETE FROM Employees
WHERE EmployeeID IN (
    SELECT e.EmployeeID  FROM Employees AS e
    WHERE e.DepartmentID = @departmentId
)

ALTER TABLE Employees CHECK CONSTRAINT [FK_Employees_Employees]

SELECT COUNT(*) FROM Employees AS e
WHERE e.DepartmentID = @departmentId

GO

BEGIN TRANSACTION

EXEC dbo.usp_DeleteEmployeesFromDepartment 12

ROLLBACK

SELECT COUNT(*) FROM Employees AS e
WHERE e.DepartmentID = 12


USE master
GO

ALTER DATABASE SoftUni SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

DROP DATABASE SoftUni
GO

RESTORE DATABASE SoftUni
    FROM DISK = '/var/opt/mssql/data/softuni-backup-4-2-2023.bak'

--problem 09. Find Full Name
CREATE PROC usp_GetHoldersFullName
AS
SELECT CONCAT_WS(' ',a.FirstName, a.LastName) AS [Full Name]
FROM AccountHolders AS a 

GO

--problem 10. People with Balance Higher Than 
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@moneyThreshold MONEY)
AS
    SELECT 
        ah.FirstName AS [First Name]
        ,ah.LastName AS [Last Name]
    FROM AccountHolders AS ah
    JOIN Accounts AS a
    ON ah.Id = a.AccountHolderId
    GROUP BY ah.Id, ah.FirstName, ah.LastName
    HAVING SUM(a.Balance) > @moneyThreshold
    ORDER BY ah.FirstName, ah.LastName
GO

--problem 11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@initSum DECIMAL(38,5) ,@yearlyInterestRate FLOAT(53) , @years INT)
RETURNS DECIMAL(38,4)
AS
BEGIN
    DECLARE @futureValue DECIMAL(38,4)
    SET @futureValue = ROUND(   @initSum * POWER((1+@yearlyInterestRate) ,@years)   ,4)
    RETURN @futureValue
END
GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)
GO

--problem 12. Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @yearlyInterestRate FLOAT(53))
AS
    SELECT 
        a.Id AS [Account Id]
        ,ah.FirstName AS [First Name]
        ,ah.LastName AS [Last Name]
        ,a.Balance AS [Current Balance]
        ,dbo.ufn_CalculateFutureValue(a.Balance, @yearlyInterestRate, 5) AS [Balance in 5 years]
    FROM AccountHolders AS ah
    JOIN Accounts AS a
    ON ah.Id = a.AccountHolderId
    WHERE a.Id = @accountId
GO

--problem 13. *Cash in User Games Odd Rows
USE Diablo
GO

CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(400))
RETURNS TABLE
AS
RETURN 
(
    SELECT
        SUM(Cash) AS SumCash
    FROM
    (
        SELECT 
            g.Name
            ,ug.Cash AS Cash
            ,ROW_NUMBER() OVER
            (PARTITION BY g.Name ORDER BY ug.Cash DESC) AS Seq
        FROM UsersGames AS ug
        JOIN Games AS g
        ON g.Id = ug.GameId
        WHERE g.Name = @gameName
    )AS in1
    WHERE Seq %2 <> 0
)
GO

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')




    
