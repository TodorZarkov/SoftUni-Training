CREATE DATABASE Hotel
GO

USE Hotel
GO

CREATE TABLE Employees 
(
    Id INT PRIMARY KEY ,--IDENTITY, 
    FirstName NVARCHAR(100) NOT NULL, 
    LastName NVARCHAR(100) NOT NULL, 
    Title NVARCHAR(100) NOT NULL, 
    Notes NVARCHAR(MAX) 
)

INSERT INTO Employees
VALUES
    (1, 'EMPL1FirstName', 'EMPL1LastName', 'Title1', NULL),
    (2, 'EMPL2FirstName', 'EMPL2LastName', 'Title2', NULL),
    (3, 'EMPL3FirstName', 'EMPL3LastName', 'Title3', NULL)


CREATE TABLE Customers 
(
    AccountNumber NVARCHAR(100) PRIMARY KEY, 
    FirstName NVARCHAR(100) NOT NULL, 
    LastName NVARCHAR(100) NOT NULL, 
    PhoneNumber NVARCHAR(100), 
    EmergencyName NVARCHAR(100), 
    EmergencyNumber NVARCHAR(100), 
    Notes NVARCHAR(MAX)
)

INSERT INTO Customers 
VALUES
    ('AccountNumber1', 'FirstName1', 'LastName1', 'PhoneNumber1', NULL, NULL, NULL),
    ('AccountNumber2', 'FirstName2', 'LastName2', 'PhoneNumber2', NULL, NULL, NULL),
    ('AccountNumber3', 'FirstName3', 'LastName3', 'PhoneNumber3', NULL, NULL, NULL)

--------------------------------------------
CREATE TABLE RoomStatus 
(
    RoomStatus NVARCHAR(60) PRIMARY KEY, 
    Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus
VALUES 
    ('RoomStatus1', NULL),
    ('RoomStatus2', NULL),
    ('RoomStatus3', NULL)


CREATE TABLE RoomTypes
(
    RoomType NVARCHAR(60) PRIMARY KEY, 
    Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes
VALUES 
    ('RoomType1', NULL),
    ('RoomType2', NULL),
    ('RoomType3', NULL)


CREATE TABLE BedTypes 
(
    BedType NVARCHAR(60) PRIMARY KEY, 
    Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes
VALUES 
    ('BedType1', NULL),
    ('BedType2', NULL),
    ('BedType3', NULL)
----------------------------------------------------


CREATE TABLE Rooms 
(
    RoomNumber VARCHAR(4) PRIMARY KEY, 
    RoomType NVARCHAR(60) NOT NULL,
        FOREIGN KEY(RoomType) REFERENCES Roomtypes(RoomType),
    BedType NVARCHAR(60) NOT NULL, 
        FOREIGN KEY(BedType) REFERENCES BedTypes(BedType),
    Rate REAL NOT NULL, 
    RoomStatus NVARCHAR(60) NOT NULL, 
        FOREIGN KEY(RoomStatus) REFERENCES RoomStatus(RoomStatus),
    Notes NVARCHAR(MAX)
)

INSERT INTO Rooms
VALUES 
    ('01', 'RoomType1', 'BedType1', 10.5, 'RoomStatus1', NULL),
    ('02', 'RoomType2', 'BedType2', 20.5, 'RoomStatus2', NULL),
    ('03', 'RoomType3', 'BedType3', 30.5, 'RoomStatus3', NULL)


CREATE TABLE Payments 
(
    Id BIGINT PRIMARY KEY IDENTITY, 
    EmployeeId INT,
        FOREIGN KEY(EmployeeId) REFERENCES  Employees(Id),
    PaymentDate DATETIME2 NOT NULL, 
    AccountNumber NVARCHAR(100), 
        FOREIGN KEY(AccountNumber) REFERENCES Customers(AccountNumber),
    FirstDateOccupied DATE NOT NULL, 
    LastDateOccupied DATE NOT NULL, 
    TotalDays SMALLINT NOT NULL, 
    AmountCharged SMALLMONEY NOT NULL, 
    TaxRate REAL NOT NULL, 
    TaxAmount SMALLMONEY NOT NULL,
    PaymentTotal SMALLMONEY NOT NULL, 
    Notes NVARCHAR(MAX)
)

INSERT INTO Payments
VALUES
    (1, '2022-12-21', 'AccountNumber1', '2022-12-10', '2022-12-21', 11, 500.50, 0.2, 100.1, 600.60, NULL),
    (2, '2022-12-21', 'AccountNumber2', '2022-12-10', '2022-12-21', 11, 500.50, 0.2, 100.1, 600.60, NULL),
    (3, '2022-12-21', 'AccountNumber3', '2022-12-10', '2022-12-21', 11, 500.50, 0.2, 100.1, 600.60, NULL)


CREATE TABLE Occupancies 
(
    Id INT PRIMARY KEY, 
    EmployeeId INT,
        FOREIGN KEY(EmployeeId) REFERENCES  Employees(Id),
    DateOccupied DATE NOT NULL, 
    AccountNumber NVARCHAR(100), 
        FOREIGN KEY(AccountNumber) REFERENCES Customers(AccountNumber),
    RoomNumber VARCHAR(4), 
        FOREIGN KEY(RoomNumber) REFERENCES Rooms(RoomNumber),
    RateApplied SMALLMONEY NOT NULL, 
    PhoneCharge SMALLMONEY, 
    Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies
VALUES  
    (1, 1, '2022-12-21', 'AccountNumber1', '01', 50.1, NULL, NULL),
    (2, 2, '2022-12-21', 'AccountNumber2', '02', 50.1, NULL, NULL),
    (3, 3, '2022-12-21', 'AccountNumber3', '03', 50.1, NULL, NULL)
