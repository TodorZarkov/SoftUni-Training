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

----------------------------------------------