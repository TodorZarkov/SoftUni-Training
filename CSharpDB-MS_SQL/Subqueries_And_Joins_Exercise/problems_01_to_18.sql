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

--problem 07. Employees With Project
SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '08.13.2002' AND  p.EndDate IS NULL
ORDER BY e.EmployeeID

--problem 08. Employee 24
SELECT e.EmployeeID, e.FirstName, p.Name AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p
ON ep.ProjectID = p.ProjectID  AND p.StartDate < '1.1.2005'
WHERE e.EmployeeID = 24

--problem 09. Employee Manager
SELECT e.EmployeeID, e.FirstName, e.ManagerID, je.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS je
ON e.ManagerID = je.EmployeeID AND je.EmployeeID IN (3,7)
ORDER BY e.EmployeeID

--problem 10. Employees Summary
SELECT TOP(50)
    e.EmployeeID
    , CONCAT_WS(' ', e.FirstName,e.LastName) AS EmployeeName
    , CONCAT_WS(' ', je.FirstName,je.LastName) AS ManagerName
    , d.Name AS DepartmentName
FROM Employees AS e
JOIN Employees AS je
ON e.ManagerID = je.EmployeeID
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--problem 11. Min Average Salary
SELECT MIN(ms.MinSalary) AS MinAverageSalary
FROM
    (
    SELECT AVG(e.Salary) AS MinSalary
    FROM Employees AS e
    GROUP BY e.DepartmentID 
    )AS ms

--problem 12. Highest Peaks in Bulgaria
USE [Geography]
GO
SELECT 
    c.CountryCode
    ,m.MountainRange
    ,p.PeakName
    ,p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode AND c.CountryCode = 'BG'
JOIN Mountains AS m
ON mc.MountainId = m.Id
JOIN Peaks AS p
ON m.Id = p.MountainId AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--problem 13. Count Mountain Ranges
SELECT 
    c.CountryCode
    ,COUNT(m.MountainRange) ASMountainRanges
FROM Countries AS c
JOIN MountainsCountries AS mc
ON  c.CountryCode = mc.CountryCode AND c.CountryName IN('United States', 'Russia', 'Bulgaria')
JOIN Mountains AS m
ON mc.MountainId = m.Id
GROUP BY c.CountryCode

--problem 14. Countries With or Without Rivers
SELECT TOP(5)
    c.CountryName
    ,r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode 
LEFT JOIN Rivers AS r
ON cr.RiverId = r.Id
WHERE c.ContinentCode IN
    (
        SELECT co.ContinentCode
        FROM Continents AS co
        WHERE co.ContinentName = 'Africa'
    )
ORDER BY c.CountryName
   
--problem 15. Continents and Currencies
SELECT 
    ContinentCode
    ,CurrencyCode
    ,CurrencyUssage
FROM
    (
    SELECT 
        co.ContinentCode
        ,COUNT(c.CurrencyCode) AS CurrencyUssage
        ,c.CurrencyCode
        ,DENSE_RANK() OVER 
        (PARTITION BY co.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS Rank
    FROM Continents AS co
    JOIN Countries AS c
    ON co.ContinentCode = c.ContinentCode
    GROUP BY co.ContinentCode, c.CurrencyCode
    ) AS iq
    WHERE Rank = 1 AND CurrencyUssage <> 1

--problem 16. Countries Without any Mountains
SELECT COUNT(c.CountryCode) AS Count
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL

--problem 17. Highest Peak and Longest River by Country
SELECT TOP(5)
    CountryName
    ,HighestPeakElevation
    ,LongestRiverLength
FROM
    (
    SELECT 
        c.CountryName AS CountryName
        ,MAX(p.Elevation) AS HighestPeakElevation
        ,MAX(r.Length) AS LongestRiverLength
        -- ,p.Elevation
        -- ,p.PeakName
        -- ,r.Length
        -- ,r.RiverName
        ,DENSE_RANK() OVER
        (PARTITION BY c.CountryName ORDER BY p.Elevation DESC, r.Length DESC) Rank
    FROM Countries AS c
    LEFT JOIN MountainsCountries AS mc
    ON mc.CountryCode = c.CountryCode
    LEFT JOIN Mountains AS m
    ON mc.MountainId = m.Id
    LEFT JOIN Peaks AS p
    ON m.Id = p.MountainId
    LEFT JOIN CountriesRivers AS cr
    ON cr.CountryCode = c.CountryCode
    LEFT JOIN Rivers AS r
    ON cr.RiverId = r.Id
    GROUP BY c.CountryName, p.Elevation, r.Length
    )
AS in1
WHERE Rank = 1
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName

--problem 18. Highest Peak Name and Elevation by Country