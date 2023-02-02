--problem 01. Records’ Count
USE Gringotts
GO
SELECT COUNT(*) AS Count
FROM WizzardDeposits

--problem 02. Longest Magic Wand
SELECT MAX(w.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits AS w

--problem 03. Longest Magic Wand per Deposit Groups
SELECT
    w.DepositGroup, MAX(w.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup

--problem 04. Smallest Deposit Group per Magic Wand Size
SELECT DepositGroup
FROM
(
    SELECT TOP(2)
        w.DepositGroup AS DepositGroup
        ,AVG(w.MagicWandSize) AS a
    FROM WizzardDeposits AS w
    GROUP BY w.DepositGroup
    ORDER BY a  
)AS b

--problem 05. Deposits Sum
SELECT
    w.DepositGroup
    ,SUM(w.DepositAmount)
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup

--problem 06. Deposits Sum for Ollivander Family
SELECT
    w.DepositGroup
    ,SUM(w.DepositAmount)
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup , w.MagicWandCreator
HAVING w.MagicWandCreator = 'Ollivander family'

--problem 07. Deposits Filter
SELECT
    w.DepositGroup
    ,SUM(w.DepositAmount) AS TotalSum
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup, w.MagicWandCreator
HAVING w.MagicWandCreator = 'Ollivander family' AND SUM(w.DepositAmount) < 150000
ORDER BY TotalSum DESC

--problem 08. Deposit Charge
SELECT
    w.DepositGroup
    ,w.MagicWandCreator
    ,MIN(w.DepositCharge) AS MinDepositCharge
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup, w.MagicWandCreator
ORDER BY w.MagicWandCreator, w.DepositGroup

--problem 09. Age Groups
SELECT
    AgeGroup
    ,COUNT(*) AS WizardCount
FROM
(
    SELECT
        CASE
            WHEN w.Age BETWEEN 0  AND 10 THEN '[0-10]'
            WHEN w.Age BETWEEN 11 AND 20 THEN '[11-20]'
            WHEN w.Age BETWEEN 21 AND 30 THEN '[21-30]'
            WHEN w.Age BETWEEN 31 AND 40 THEN '[31-40]'
            WHEN w.Age BETWEEN 41 AND 50 THEN '[41-50]'
            WHEN w.Age BETWEEN 51 AND 60 THEN '[51-60]'
            WHEN w.Age > 60              THEN '[61+]'
            END AS AgeGroup
    FROM WizzardDeposits AS w
) AS a
GROUP BY AgeGroup

--problem 10. First Letter
SELECT
    LEFT(w.FirstName,1) AS FirstLetter
    --,COUNT(*)
FROM WizzardDeposits AS w
WHERE w.DepositGroup = 'Troll Chest'
GROUP BY LEFT(w.FirstName,1)
ORDER BY FirstLetter

--problem 11. Average Interest
SELECT
    w.DepositGroup
    ,w.IsDepositExpired
    ,AVG(w.DepositInterest) AS AverageInterest
FROM WizzardDeposits AS w
WHERE w.DepositStartDate > '01-01-1985'
GROUP BY w.DepositGroup, w.IsDepositExpired
ORDER BY w.DepositGroup DESC, IsDepositExpired

--problem 12. *Rich Wizard, Poor Wizard
SELECT
    --  wh.FirstName AS        HostName
    -- ,wh.DepositAmount AS    HostDeposit
    -- ,wh.Id AS               HostId
    -- ,wg.FirstName AS        GuestName
    -- ,wg.DepositAmount AS    GuestDeposit
    -- ,wg.Id AS               GuestId
    SUM(wh.DepositAmount - wg.DepositAmount) AS [SumDifference]
FROM WizzardDeposits AS wh
JOIN WizzardDeposits AS wg
ON wh.Id = (wg.Id - 1)

--problem 13. Departments Total Salaries
USE SoftUni
GO
SELECT
    e.DepartmentID
    ,SUM(e.Salary) AS TotalSalary
FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

--problem 14. Employees Minimum Salaries
SELECT 
    e.DepartmentID
    ,MIN(Salary) AS MinimumSalary
FROM Employees  AS e
WHERE e.DepartmentID IN(2, 5, 7) AND e.HireDate > '1-1-2000'
GROUP BY e.DepartmentID

--problem 15. Employees Average Salaries 