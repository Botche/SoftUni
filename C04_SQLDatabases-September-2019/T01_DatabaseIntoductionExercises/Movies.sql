CREATE DATABASE Movies
USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DirectorName VARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors([DirectorName],[Notes])
VALUES  ('Ivan', NULL),
		('Pesho', 'TODO: Film'),
		('Gosho', 'TODO: Notes'),
		('Gabriel', 'TODO: Nothing'),
		('Stamo', NULL)

SELECT * FROM Directors

CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY(1,1),
	GenresName VARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Genres ([GenresName],[Notes])
VALUES  ('Ivancho', 'TODO: Film'),
		('Peshu', NULL),
		('Gosheto', 'TODO: Notes'),
		('Gabrcho', 'TODO: Nothing'),
		('Stamcho', NULL)

SELECT * FROM Genres

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY(1,1),
	CategoryName VARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories ([CategoryName],[Notes])
VALUES  ('Drama', NULL),
		('Action', NULL),
		('Comedy', 'ROLF'),
		('Vuduu', 'Better dont watch'),
		('Scary', NULL)

SELECT * FROM Categories 

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(30) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyRightYear INT,
	[Length] FLOAT(2),
	[GenreId] INT FOREIGN KEY REFERENCES Genres(Id),
	Rating FLOAT(1) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Movies ([Title], [DirectorId], [CopyRightYear], [Length], [GenreId], [Rating] ,[Notes])
VALUES ('It', '1', 2000, NULL, 1, 8.9, NULL),
		('It 2', '3', 2002, NULL, 3, 8.6, NULL),
		('It 3', '4', 2004, NULL, 2, 9.2, NULL),
		('It 4', '2', 2006, NULL, 5, 7.8, NULL),
		('It 5', '5', 2010, NULL, 4, 9.5, NULL)

SELECT * FROM Movies