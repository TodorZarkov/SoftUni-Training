CREATE DATABASE [SoftUni]
GO
USE [SoftUni]
GO

CREATE TABLE Towns
(
    Id INT PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
    Id INT PRIMARY KEY IDENTITY, 
    AddressText NVARCHAR(100) NOT NULL,
    TownId INT,
        FOREIGN KEY(TownId) REFERENCES Towns(Id)
)

CREATE TABLE Departments 
(
    Id TINYINT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Employees 
(
    Id INT PRIMARY KEY IDENTITY, 
    FirstName NVARCHAR(100) NOT NULL, 
    MiddleName NVARCHAR(100), 
    LastName NVARCHAR(100) NOT NULL, 
    JobTitle NVARCHAR(100) NOT NULL, 
    DepartmentId TINYINT, 
        FOREIGN KEY(DepartmentId) REFERENCES Departments(Id),
    HireDate DATE NOT NULL, 
    Salary MONEY NOT NULL, 
    AddressId INT,
        FOREIGN KEY(AddressId) REFERENCES Addresses(Id)
)