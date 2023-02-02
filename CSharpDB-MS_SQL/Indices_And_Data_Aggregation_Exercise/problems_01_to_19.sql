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