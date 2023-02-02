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