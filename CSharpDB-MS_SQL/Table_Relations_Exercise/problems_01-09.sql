CREATE DATABASE [TableRelations]
GO

USE TableRelations
GO

-- problem 01 One-To-One Relationship
CREATE TABLE [Passports]
(
    PassportID BIGINT PRIMARY KEY IDENTITY(101,1),
    PassportNumber CHAR(8)
)
INSERT INTO Passports
VALUES
    ('N34FG21B'),
    ('K65LO4R7'),
    ('ZE657QP2')


CREATE TABLE [Persons]
(
    PersonID BIGINT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(200) NOT NULL,
    Salary SMALLMONEY ,
    PassportID BIGINT UNIQUE,
        FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)
)
INSERT INTO Persons
VALUES
    ('Roberto', 43300.00, 102),
    ('Tom', 56100.00, 103),
    ('Yana', 60200.00, 101)


--problem 02 One-To-Many Relationship
CREATE TABLE [Manufacturers]
(
    ManufacturerID SMALLINT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    EstablishedOn DATE
)
INSERT INTO Manufacturers
VALUES
    ('BMW', '1916-3-7'),
    ('Tesla', '2003-1-1'),
    ('Lada', '1966-5-1')


CREATE TABLE [Models]
(
    ModelID INT PRIMARY KEY IDENTITY(101,1),
    [Name] NVARCHAR(100) NOT NULL,
    ManufacturerID SMALLINT,
        FOREIGN KEY(ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
)
INSERT INTO Models
VALUES
    ('X1', 1),
    ('i6', 1),
    ('Model S', 2),
    ('Model X', 2),
    ('Model 3', 2),
    ('Nova', 3)
