USE SoftUni
GO

CREATE VIEW V_EmployeeNameJobTitle
AS 
SELECT 
    FirstName + CONCAT(' ', MiddleName) + ' ' + LastName AS [Full Name]
    , JobTitle AS [Job Title]
FROM Employees