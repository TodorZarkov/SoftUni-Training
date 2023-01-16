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

CREATE TABLE RoomStatus 
(
    RoomStatus NVARCHAR(60) NOT NULL, 
    Notes NVARCHAR(MAX)
)

CREATE TABLE RoomTypes
(
    RoomType NVARCHAR(60) NOT NULL, 
    Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes 
(
    BedType NVARCHAR(60) NOT NULL, 
    Notes NVARCHAR(MAX)
)

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

CREATE TABLE Occupancies 
(
    Id INT PRIMARY, 
    EmployeeId, 
    DateOccupied, 
    AccountNumber, 
    RoomNumber, 
    RateApplied, 
    PhoneCharge, 
    Notes NVARCHAR(MAX)
)
