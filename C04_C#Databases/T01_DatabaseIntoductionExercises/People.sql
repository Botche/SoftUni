CREATE DATABASE DatabaseIntoduction

CREATE TABLE People (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] IMAGE,
	[Height] DECIMAL(10,2),
	[Weight] DECIMAL(10,2),
	[Gender] VARCHAR(1) NOT NULL CHECK([Gender] = 'f' OR [Gender] = 'm'),
	[Birthdate] DATE NOT NULL,
	[Biography] VARCHAR(MAX)
)

INSERT INTO People ([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES ('Ivan', NULL, 1.70, 60, 'm', '2005/01/13', NULL),
		('George', NULL, 1.87, 90, 'm', '2005/01/13', NULL),
		('Antonia', NULL, 1.83, 60, 'f', '2005/01/13', NULL),
		('Martina', NULL, 1.63, 50, 'f', '2005/01/13', NULL),
		('Anna', NULL, 1.53, 46, 'f', '2005/01/13', NULL)