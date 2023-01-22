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


--problem 03. Many-To-Many Relationship
CREATE TABLE [Students]
(
    StudentID BIGINT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(200) NOT NULL
)
INSERT INTO [Students]
VALUES
    ('Mila'),
    ('Toni'),
    ('Ron')


CREATE TABLE [Exams]
(
    ExamID INT PRIMARY KEY IDENTITY(101,1),
    [Name] NVARCHAR(300) NOT NULL
)
INSERT INTO [Exams]
VALUES
    ('SpringMVC')
    ,('Neo4j')
    ,('Oracle 11g')

CREATE TABLE [StudentsExams]
(
    StudentID BIGINT NOT NULL,
    ExamID INT NOT NULL,
        PRIMARY KEY (StudentID, ExamID),
        FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
        FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)
INSERT INTO [StudentsExams]
VALUES
    (1, 101),
    (1, 102),
    (2, 101),
    (3, 103),
    (2, 102),
    (2, 103)



--problem 04. Self-Referencing 
CREATE TABLE [Teachers]
(
    TeacherID INT PRIMARY KEY IDENTITY(101,1),
    [Name] NVARCHAR(200) NOT NULL,
    ManagerID INT,
        FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)
)
INSERT INTO [Teachers]
VALUES
    ('John',    NULL),
    ('Maya',    106),
    ('Silvia',  106),
    ('Ted',     105),
    ('Mark',    101),
    ('Greta',   101)


--problem 06. University Database
CREATE TABLE [Majors]
(
    MajorID INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(200) NOT NULL
)

CREATE TABLE [Subjects]
(
    SubjectID SMALLINT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(200) NOT NULL
)

CREATE TABLE [Students1]
(
    StudentID BIGINT PRIMARY KEY IDENTITY,
    StudentNumber BIGINT NOT NULL,
    StudentName NVARCHAR(200) NOT NULL,
    MajorID INT,
        FOREIGN KEY(MajorID) REFERENCES Majors(MajorID)
)

CREATE TABLE [Payments]
(
    PaymentID BIGINT PRIMARY KEY IDENTITY,
    PaymentDate DATE NOT NULL,
    PaymentAmount SMALLMONEY NOT NULL,
    StudentID BIGINT NOT NULL,
        FOREIGN KEY(StudentID) REFERENCES Students1(StudentID)
)

CREATE TABLE [Agenda]
(
    StudentID BIGINT NOT NULL,
    SubjectID SMALLINT NOT NULL,
        PRIMARY KEY (StudentID, SubjectID),
        FOREIGN KEY (StudentID) REFERENCES Students1(StudentID),
        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID) 
)