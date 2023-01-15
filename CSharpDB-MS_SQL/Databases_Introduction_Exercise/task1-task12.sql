--1
CREATE DATABASE Minions
GO

USE Minions
GO

--2
CREATE TABLE Minions(
	Id INT NOT NULL, 
	[Name] VARCHAR(100),
	Age INT
	CONSTRAINT PK_Id PRIMARY KEY (Id)
)

CREATE TABLE Towns(
	Id INT NOT NULL,
	[Name] VARCHAR(100)
	CONSTRAINT PK_Towns PRIMARY KEY (Id)
)

--3
ALTER TABLE Minions
	ADD TownId INT FOREIGN KEY REFERENCES Towns(Id);

--4 
INSERT INTO Towns
VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions
VALUES
(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)

--5
TRUNCATE TABLE minions

--6
DROP TABLE Minions
DROP TABLE Towns

--7
CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	CHECK(Picture<=2000000),
	Height FLOAT,
	[Weight] FLOAT,
	Gender CHAR(1) NOT NULL,
	CHECK(Gender = 'm' OR Gender = 'f'),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX) 
);

INSERT INTO People
VALUES
	('Gosho',NULL, 178.55, 85.22, 'm', '1995-11-20','Coding hard'),
	('Penka',NULL, 155, 85.22, 'f', '1995-11-20',NULL),
	('Gosho',NULL, 178.55, 85.22, 'm', '1995-11-20','Coding hard'),
	('Stamat',NULL, 178.55, 85.22, 'm', '1995-11-20','Coding'),
	('Gosho',NULL, 178.55, 85.22, 'm', '1995-11-20','Coding hard')


--8
CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	CHECK(ProfilePicture <= 900000),
	LastLoginTime DATETIME2,
	IsDeleted BIT 
);

INSERT INTO Users
VALUES
	('Dragan','12345',null, '2023-3-22', 0),
	('petkan','12345',null, '2022-3-22', 1),
	('bratMu','12322245',null, '2023-3-22', 0),
	('gosho','12345',null, '2022-3-23', 1),
	('Stamat','12345',null, '2023-3-22', 0)


--9
ALTER TABLE Users
	DROP CONSTRAINT PK__Users__3214EC070A37E94F

ALTER TABLE Users
	ADD CONSTRAINT PK_Users PRIMARY KEY(Id, Username)


--10
ALTER TABLE Users
	ADD CHECK(LEN([Password]) >= 5);


--11
ALTER TABLE Users
	ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users
VALUES
	('Dragan2','12345',null,NULL, 0)


INSERT INTO Users([Username],[Password],[ProfilePicture],[IsDeleted])
VALUES
	('Dragan3','12345',null, 0)


--12
ALTER TABLE Users
	DROP PK_Users

ALTER TABLE Users
	ADD CONSTRAINT PK_Users_Id PRIMARY KEY(Id)

ALTER TABLE Users
	ADD CONSTRAINT CK_UserName_Len CHECK(LEN(Username)>=3)

INSERT INTO Users([Username],[Password],[ProfilePicture],[IsDeleted])
VALUES
	('DrA','12345',null, 0)

ALTER TABLE Users
	ADD CONSTRAINT UC_Username UNIQUE(Username)

INSERT INTO Users([Username],[Password],[ProfilePicture],[IsDeleted])
VALUES
	('DrA','12345',null, 0)
