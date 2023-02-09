--Zoo
CREATE DATABASE Zoo
GO
USE
Zoo
GO
--problem 01. DDL (30 pts)
CREATE TABLE Owners
(
     Id             INT PRIMARY KEY IDENTITY
    ,[Name]         VARCHAR(50) NOT NULL
    ,PhoneNumber    VARCHAR(15) NOT NULL
    ,[Address]      VARCHAR(50) NULL
)

CREATE TABLE AnimalTypes
(
     Id             INT PRIMARY KEY IDENTITY
    ,AnimalType     VARCHAR(30) NOT NULL
)

CREATE TABLE Cages
(
     Id             INT PRIMARY KEY IDENTITY
    ,AnimalTypeId   INT NOT NULL 
    ,   FOREIGN KEY(AnimalTypeId) REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals
(
     Id             INT PRIMARY KEY IDENTITY
    ,[Name]         VARCHAR(30) NOT NULL
    ,BirthDate      DATE NOT NULL
    ,OwnerId        INT NULL
        ,FOREIGN KEY(OwnerId) REFERENCES Owners(Id)
    ,AnimalTypeId   INT NOT NULL
        ,FOREIGN KEY(AnimalTypeId) REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages
(
     CageId         INT NOT NULL
        ,FOREIGN KEY(CageId) REFERENCES Cages(Id)
    ,AnimalId       INT NOT NULL
        ,FOREIGN KEY(AnimalId) REFERENCES Animals(Id)
    ,PRIMARY KEY (CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments
(
     Id             INT PRIMARY KEY IDENTITY
    ,DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers
(
     Id             INT PRIMARY KEY IDENTITY
    ,[Name]         VARCHAR(50) NOT NULL
    ,PhoneNumber    VARCHAR(15) NOT NULL
    ,[Address]      VARCHAR(50) NULL
    ,AnimalId       INT NULL
    ,   FOREIGN KEY(AnimalId) REFERENCES Animals(Id)
    ,DepartmentId   INT NOT NULL
    ,   FOREIGN KEY(DepartmentId) REFERENCES VolunteersDepartments(Id)
)
GO

--problem 2. DML
INSERT INTO Volunteers([Name], PhoneNumber ,[Address], AnimalId, DepartmentId)
VALUES
    ('Anita Kostova'     ,'0896365412', 'Sofia, 5 Rosa str.', 15, 1),
    ('Dimitur Stoev'     ,'0877564223',  null  , 42, 4),
    ('Kalina Evtimova'   ,'0896321112', 'Silistra, 21 Breza str.', 9, 7),
    ('Stoyan Tomov'      ,'0898564100', 'Montana, 1 Bor str.', 18, 8),
    ('Boryana Mileva'    ,'0888112233',  null, 31, 5)

INSERT INTO Animals([Name], BirthDate, OwnerId, AnimalTypeId)
VALUES 
    ('Giraffe', '2018-09-21', 21, 1),
    ('Harpy Eagle', '2015-04-17', 15, 3),
    ('Hamadryas Baboon', '2017-11-02', null, 1),
    ('Tuatara', '2021-06-30', 2, 4)
GO

UPDATE Animals
SET OwnerId =
(
    SELECT o.Id
    FROM Owners AS o
    WHERE o.Name = 'Kaloqn Stoqnov'
)
WHERE OwnerId IS NULL
GO

DELETE FROM Volunteers
WHERE DepartmentId = 
(
    SELECT 
        vd.Id
    FROM VolunteersDepartments AS vd
    WHERE vd.DepartmentName = 'Education program assistant'
)

DELETE FROM VolunteersDepartments
WHERE Id = 
(
    SELECT 
        vd.Id
    FROM VolunteersDepartments AS vd
    WHERE vd.DepartmentName = 'Education program assistant'
)
GO

--problem 3. Querying (40 pts)
USE master
GO

ALTER DATABASE Zoo SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

DROP DATABASE Zoo
GO

        --CREATE AND POPULATE AS IN PROBLEM 01
USE Zoo
GO
SELECT 
     v.Name
    ,v.PhoneNumber
    ,v.Address
    ,v.AnimalId
    ,v.DepartmentId
FROM Volunteers as v
ORDER BY v.Name, v.Id, v.DepartmentId
GO

SELECT 
    a.[Name]
    ,ant.AnimalType
    ,FORMAT(a.BirthDate, 'dd.MM.yyyy')
FROM Animals AS a
LEFT JOIN AnimalTypes AS ant
ON ant.Id = a.AnimalTypeId
ORDER BY a.Name

SELECT 
     CONCAT_WS('-', o.Name, a.Name) AS OwnersAnimals
    ,o.PhoneNumber
    ,ac.CageId
FROM Owners AS o
JOIN Animals AS a
ON o.Id = a.OwnerId
JOIN AnimalTypes AS atps
ON a.AnimalTypeId = atps.Id
JOIN AnimalsCages AS ac
ON ac.AnimalId = a.Id 
WHERE atps.AnimalType = 'Mammals'
ORDER BY o.Name, a.Name DESC
GO

SELECT 
    v.Name
    ,v.PhoneNumber
    ,TRIM(REPLACE(REPLACE(v.[Address], 'Sofia',''), ',',''))
FROM Volunteers AS v
JOIN VolunteersDepartments AS vd
ON v.DepartmentId = vd.Id AND vd.DepartmentName = 'Education program assistant'
WHERE CHARINDEX('Sofia', v.Address) <> 0
ORDER BY v.Name
GO

SELECT 
    a.Name
    ,a.BirthDate
    ,atps.AnimalType
FROM Animals AS a
JOIN AnimalTypes AS atps 
ON a.AnimalTypeId = atps.Id AND atps.AnimalType <> 'Birds'
WHERE DATEADD(YEAR, 4 , a.BirthDate) >= '01-01-2022' AND a.OwnerId IS NULL
ORDER BY a.Name
GO

--problem 4. Programmability (20 pts)

