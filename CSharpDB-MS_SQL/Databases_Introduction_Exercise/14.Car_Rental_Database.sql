CREATE DATABASE CarRental
GO

USE CarRental
GO

CREATE TABLE Categories
(
    Id SMALLINT PRIMARY KEY IDENTITY,
    CategoryName NVARCHAR(100) NOT NULL,
    DailyRate REAL NOT NULL,
    WeeklyRate REAL NOT NULL,
    MonthlyRate REAL NOT NULL,
    WeekendRate REAL NOT NULL
)

CREATE TABLE Cars
(
    Id BIGINT PRIMARY KEY IDENTITY,
    PlateNumber VARCHAR(20) NOT NULL,
    Manufacturer NVARCHAR(60) NOT NULL,
    Model NVARCHAR(60) NOT NULL,
    CarYear DATE NOT NULL,
    CategoryId SMALLINT,
        FOREIGN KEY(CategoryId) REFERENCES Categories(Id),
    Doors TINYINT,
    Picture VARBINARY(MAX),
    Condition NVARCHAR(200),
    Available BIT NOT NULL
)

CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Notes NVARCHAR(MAX)
)

CREATE TABLE Customers
(
    Id BIGINT PRIMARY KEY IDENTITY,
    DriverLicenceNumber NVARCHAR(200) NOT NULL,
    FullName NVARCHAR(200) NOT NULL,
    [Address] NVARCHAR(400) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    ZIPCode VARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders
(
    Id BIGINT PRIMARY KEY IDENTITY,
    EmployeeId INT,
        FOREIGN KEY(EmployeeId) REFERENCES Employees(Id),
    CustomerId BIGINT,
        FOREIGN KEY(CustomerId) REFERENCES Customers(Id),
    CarId BIGINT,
        FOREIGN KEY(CarId) REFERENCES Cars(Id),
    TankLevel TINYINT NOT NULL,
    KilometrageStart INT NOT NULL,
    KilometrageEnd INT NOT NULL,
    TotalKilometrage INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalDays SMALLINT NOT NULL,
    RateApplied REAL NOT NULL,
    TaxRate REAL NOT NULL,
    OrderStatus VARCHAR(35) NOT NULL,
    Notes NVARCHAR(MAX)
)

INSERT INTO Categories
VALUES
    ('Car', 50, 300, 1000, 60),
    ('Suv', 60, 400, 1200, 80),
    ('Van', 70, 500, 1500, 90)

INSERT INTO Cars
VALUES
    ('CA 2525 HO', 'BMW', '3', '2020-1-1', 1, NULL, NULL, NULL, 1),
    ('CA 2525 MO', 'BMW', 'X3', '2020-1-1', 2, NULL, NULL, NULL, 0),
    ('CA 2525 HE', 'BMW', 'X5', '2020-1-1', 3, NULL, NULL, NULL, 1)

INSERT INTO Employees
VALUES
    ('FirstName1', 'LastName1', 'SERVICE', NULL),
    ('FirstName2', 'LastName2', 'MECHANIC', NULL),
    ('FirstName3', 'LastName3', 'DRIVER', NULL)


INSERT INTO Customers
VALUES
    ('12345677', 'Pesho Goshov', 'Tm nqkude', 'Plovdiv', '1234', null),
    ('12345678', 'Pesho Goshov2', 'Tm nqkude', 'Plovdiv', '1234', null),
    ('12345679', 'Pesho Goshov3', 'Tm nqkude', 'Plovdiv', '1234', null)

INSERT INTO RentalOrders
VALUES
    (1, 3, 2, 200, 200555, 200755, 200, '2023-10-10', '2023-10-20', 10, 60, 0.2, 'APPLYED', NULL),
    (2, 2, 1, 200, 200555, 200755, 200, '2023-10-10', '2023-10-20', 10, 60, 0.2, 'APPLYED', NULL),
    (3, 1, 2, 200, 200555, 200755, 200, '2023-10-10', '2023-10-20', 10, 60, 0.2, 'APPLYED', NULL)
