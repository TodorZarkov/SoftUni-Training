CREATE DATABASE Movies
GO

USE Movies
GO

CREATE TABLE Directors 
(
    Id BIGINT PRIMARY KEY IDENTITY,
    DirectorName NVARCHAR(100) NOT NULL,
    Notes NVARCHAR(MAX)--TO Constraint

)

CREATE TABLE Genres
(
    Id TINYINT PRIMARY KEY IDENTITY,
    GenreName NVARCHAR(20) NOT NULL,
    Notes NVARCHAR(MAX)
)

CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY,
    CategoryName NVARCHAR(20) NOT NULL,
    Notes NVARCHAR(MAX)
)

CREATE TABLE Movies
(
    Id BIGINT PRIMARY KEY IDENTITY,
    Title NVARCHAR(200) NOT NULL,
    DirectorId BIGINT,
    FOREIGN KEY(DirectorId) REFERENCES Directors(Id),
    CopyrightYear DATE,
    [Length] SMALLINT,
    GenreId TINYINT,
    FOREIGN KEY(GenreId) REFERENCES Genres(Id),
    CategoryId INT,
    FOREIGN KEY(CategoryId) REFERENCES Categories(Id),
    Rating INT,
    Notes NVARCHAR(MAX)
)

INSERT INTO Directors
VALUES 
    ('Klint Eastwood1', 'Western movie makaer and actor1'),
    ('Klint Eastwood2', 'Western movie makaer and actor2'),
    ('Klint Eastwood3', 'Western movie makaer and actor3'),
    ('Klint Eastwood4', 'Western movie makaer and actor4'),
    ('Klint Eastwood5', 'Western movie makaer and actor5')

INSERT INTO Genres
VALUES
    ('Western', null),
    ('Comedy', null),
    ('Thriller', null),
    ('Mystery', null),
    ('Horror', null)

INSERT INTO Categories
VALUES
    ('Acid Western', null),
    ('Economics film', null),
    ('Masala film', null),
    ('Horror comedy', null),
    ('Art horror', null)

INSERT INTO Movies
VALUES
    ('movie1', 3, '2022-10-10', 120, 4, 3, 1215, 'great movie1'),
    ('movie2', 2, '2022-10-10', 120, 4, 5, 125, 'great movie2'),
    ('movie3', 4, '2022-10-10', 120, 3, 3, 5000, 'great movie3'),
    ('movie4', 1, '2022-10-10', 120, 3, 5, 200, 'great movie4'),
    ('movie5', 1, '2022-10-10', 120, 2, 1, 1, 'great movie5')