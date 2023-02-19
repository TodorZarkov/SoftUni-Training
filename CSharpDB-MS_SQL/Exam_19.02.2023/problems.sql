CREATE DATABASE Boardgames
GO
USE Boardgames
GO

--problem 01. DDL (30 pts)
CREATE TABLE Categories 
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
    Id INT PRIMARY KEY IDENTITY,
    StreetName NVARCHAR(200) NOT NULL,
    StreetNumber INT NOT NULL,
    Town VARCHAR(30) NOT NULL,
    Country VARCHAR(50) NOT NULL,
    ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(30) UNIQUE NOT NULL,
    AddressId INT NOT NULL,
        FOREIGN KEY(AddressId) REFERENCES Addresses(Id),
    Website NVARCHAR(80) NULL,
    Phone NVARCHAR(40) NULL
)

CREATE TABLE PlayersRanges
(
    Id INT PRIMARY KEY IDENTITY,
    PlayersMin INT NOT NULL,
    PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(60) NOT NULL,
    YearPublished INT NOT NULL,
    Rating DECIMAL(38,2) NOT NULL,
    CategoryId INT NOT NULL,
        FOREIGN KEY(CategoryId) REFERENCES Categories(Id),
    PublisherId INT NOT NULL,
        FOREIGN KEY(PublisherId) REFERENCES Publishers(Id),
    PlayersRangeId INT NOT NULL,
        FOREIGN KEY(PlayersRangeId) REFERENCES PlayersRanges(Id)
)

CREATE TABLE Creators
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(60) NOT NULL,
    LastName NVARCHAR(60) NOT NULL,
    Email NVARCHAR(60) NOT NULL
)

CREATE TABLE CreatorsBoardgames
(
    CreatorId INT NOT NULL,
        FOREIGN KEY(CreatorId) REFERENCES Creators(Id),
    BoardgameId INT NOT NULL,
        FOREIGN KEY(BoardgameId) REFERENCES Boardgames(Id),
    PRIMARY KEY(CreatorId,BoardgameId)
)

--problem 2. DML (10 pts)
INSERT INTO Boardgames([Name], YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
VALUES
    ('Deep Blue', 2019, 5.67, 1,            15,7),
    ('Paris', 2016, 9.78, 7,                1,5),
    ('Catan: Starfarers', 2021, 9.87, 7,    13,6),
    ('Bleeding Kansas', 2020, 3.25, 3,      7,4),
    ('One Small Step', 2019, 5.75, 5,       9,2)

INSERT INTO Publishers([Name], AddressId, Website, Phone)
VALUES
    ('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
    ('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
    ('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')


UPDATE PlayersRanges
SET PlayersMax += 1 
WHERE PlayersMax = 2 AND PlayersMin = 2

UPDATE Boardgames
SET [Name] = CONCAT([Name],'V2')
WHERE YearPublished >= 2020


DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN
(
    SELECT c.BoardgameId
    FROM Boardgames AS b
    JOIN Publishers AS p
    ON p.ID = PublisherId
    JOIN Addresses AS a
    ON a.ID = p.AddressId
    JOIN CreatorsBoardgames AS c
    ON b.Id = c.BoardgameId
    WHERE a.Town LIKE 'L%'
)

DELETE FROM Boardgames
WHERE PublisherId IN
(
    SELECT p.Id
    FROM Boardgames AS b
    JOIN Publishers AS p
    ON p.ID = PublisherId
    JOIN Addresses AS a
    ON a.ID = p.AddressId
    WHERE a.Town LIKE 'L%'
)

DELETE FROM Publishers
WHERE AddressId IN
(
    SELECT a.Id
    FROM Publishers AS p
    JOIN Addresses AS a
    ON a.ID = p.AddressId
    WHERE a.Town LIKE 'L%'
)

DELETE FROM Addresses
WHERE Town IN
(
    SELECT a.Town
    FROM Addresses AS a
    WHERE a.Town LIKE 'L%'
)


--problem 3. Querying (40 pts)
USE master
GO

ALTER DATABASE Boardgames SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

DROP DATABASE Boardgames
GO

        --NO ---- CREATE AND POPULATE AS IN PROBLEM 01
USE Boardgames
GO

SELECT 
    b.[Name]
    ,b.Rating
FROM Boardgames AS b
ORDER BY b.YearPublished, b.[Name] DESC

SELECT 
    b.Id
    ,b.[Name]
    ,b.YearPublished
    ,c.Name AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c
ON b.CategoryId = c.Id
WHERE c.Name IN ('Strategy Games' , 'Wargames')
ORDER BY b.YearPublished DESC


SELECT 
    c.Id
    ,CONCAT_WS(' ', c.FirstName,c.LastName) AS CreatorName
    ,c.Email
FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb
ON cb.CreatorId = c.Id
WHERE cb.BoardgameId IS NULL
ORDER BY c.FirstName

SELECT TOP(5)
     b.[Name]
    ,Rating
    ,c.Name AS CategoryName
FROM Boardgames AS b
JOIN PlayersRanges AS pr
ON pr.Id = b.PlayersRangeId
JOIN Categories AS c
ON c.Id = b.CategoryId
WHERE (b.Rating > 7 AND b.Name LIKE '%a%')  OR (b.Rating > 7.5 AND pr.PlayersMin >= 2 AND pr.PlayersMax <= 5)
ORDER BY b.Name, b.Rating DESC

USE Boardgames
GO
SELECT 
    CONCAT_WS(' ',c.FirstName,  c.LastName) AS FullName
    ,c.Email
    ,MAX(b.Rating)
FROM Creators AS c
JOIN CreatorsBoardgames AS cb
ON cb.CreatorId = c.Id 
JOIN Boardgames AS b
ON cb.BoardgameId = b.Id
WHERE c.Email LIKE '%.com'
GROUP BY CONCAT_WS(' ',c.FirstName,  c.LastName) , c.Email
ORDER BY CONCAT_WS(' ',c.FirstName,  c.LastName) 
GO

SELECT 
    c.LastName
    ,CEILING(AVG(b.Rating))
    ,p.Name AS PublisherName
FROM Creators AS c
JOIN CreatorsBoardgames AS cb
ON cb.CreatorId = c.Id 
JOIN Boardgames AS b
ON cb.BoardgameId = b.Id
JOIN Publishers AS p
ON p.Id = b.PublisherId
GROUP BY c.Id, c.LastName, p.Name
WHERE p.Id = b.PublisherId
HAVING (p.Name = 'Stonemaier Games')
ORDER BY AVG(b.Rating) DESC

GO

--problem 4. Programmability (20 pts)
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(60))
RETURNS INT
AS
BEGIN
    DECLARE @count INT

    SELECT 
        @count = COUNT(*)
    FROM Creators AS c
    JOIN CreatorsBoardgames AS cb
    ON cb.CreatorId = c.Id
    JOIN Boardgames AS b
    ON b.Id = cb.BoardgameId
    WHERE c.FirstName = @name

    RETURN @count
END
GO

SELECT dbo.udf_CreatorWithBoardgames('Bruno')
GO


CREATE PROC usp_SearchByCategory(@category VARCHAR(50))
AS
    SELECT
        b.Name
        ,b.YearPublished
        ,b.Rating
        ,c.Name AS CategoryName
        ,p.Name AS PublisherName
        ,CONCAT_WS(' ',pr.PlayersMin, 'people') AS MinPlayers
        ,CONCAT_WS(' ',pr.PlayersMax, 'people') AS MaxPlayers
    FROM Categories AS c
    JOIN Boardgames AS b
    ON c.Id = b.CategoryId AND c.Name = @category
    JOIN Publishers AS p
    ON p.Id = b.PublisherId
    JOIN PlayersRanges AS pr
    ON pr.Id = b.PlayersRangeId
    ORDER BY p.Name, b.YearPublished DESC
GO

EXEC usp_SearchByCategory 'Wargames'