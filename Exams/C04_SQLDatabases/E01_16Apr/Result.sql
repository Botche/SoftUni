-- Problem 1 Create
CREATE DATABASE Airport;

USE Airport;

CREATE TABLE Planes(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
);

CREATE TABLE Flights(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATE,
	ArrivalTime DATE,
	[Origin] VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
);

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
);

CREATE TABLE LuggageTypes(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
);

CREATE TABLE Luggages(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
);

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(15,2) NOT NULL
);

-- Problem 2 Insert
INSERT INTO Planes ([Name], Seats, [Range])
VALUES	('Airbus 336', 112, 5132),
		('Airbus 330', 432, 5325),
		('Boeing 369', 231, 2355),
		('Stelt 297', 254, 2143),
		('Boeing 338', 165, 5111),
		('Airbus 558', 387, 1342),
		('Boeing 128', 345, 5541);

INSERT INTO LuggageTypes ([Type])
VALUES	('Crossbody Bag'),
		('School Backpack'),
		('Shoulder Bag');

-- Problem 3 Update
UPDATE Tickets
SET Price *= 1.13
WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Carlsbad');

-- Problem 4 Delete
DELETE FROM Tickets
WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Ayn Halagim');

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim';

-- Problem 5 Trips
SELECT Origin, Destination
FROM Flights
ORDER BY Origin, Destination;

-- Problem 6 The 'Tr' Planes
SELECT *
FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range];

-- Problem 7 The Flight Profits 
SELECT FlightId, SUM(Price) AS Price
FROM Tickets
GROUP BY FlightId
ORDER BY SUM(Price) DESC, FlightId;

-- Problem 8 Passengers and Prices 
SELECT TOP(10) p.FirstName, p.LastName, t.Price
FROM Tickets AS t
JOIN Passengers AS p ON t.PassengerId = p.Id
ORDER BY t.Price DESC, p.FirstName, p.LastName;

-- Problem 9 Most Used Luggage's 
SELECT lt.[Type], COUNT(l.LuggageTypeId) AS MostUsedLuggage 
FROM LuggageTypes AS lt
JOIN Luggages AS l ON lt.Id = l.LuggageTypeId
GROUP BY lt.[Type]
ORDER BY MostUsedLuggage DESC, lt.[Type];

-- Problem 10 Passenger Trips
SELECT sq.[Full Name], f.Origin, f.Destination
FROM(
	SELECT t.FlightId, CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name] 
	FROM Passengers AS p
	JOIN Tickets AS t ON p.Id = t.PassengerId
) AS sq
JOIN Flights AS f ON sq.FlightId = f.Id
ORDER BY sq.[Full Name], f.Origin, f.Destination;

-- Problem 11 Non Adventures People 
SELECT p.FirstName, p.LastName, p.Age
FROM Passengers AS p
FULL JOIN Tickets AS t ON p.Id = t.PassengerId
WHERE t.Id IS NULL
ORDER BY p.Age DESC, p.FirstName, p.LastName;

-- Problem 12 Lost Luggage's
SELECT p.PassportId, p.[Address]
FROM Luggages AS l
FULL JOIN Passengers AS p ON l.PassengerId = p.Id
WHERE l.LuggageTypeId IS NULL
ORDER BY p.PassportId, p.[Address];

-- Problem 13 Count of Trips
SELECT p.FirstName, p.LastName, COUNT(t.PassengerId) AS [Total Trips]
FROM Passengers AS p
FULL JOIN Tickets AS t ON p.Id = t.PassengerId
GROUP BY p.Id, p.FirstName, p.LastName
ORDER BY [Total Trips] DESC, p.FirstName, p.LastName;

-- Problem 14 Full Info
SELECT CONCAT(p.FirstName, ' ', p.LastName) AS FullName,
	pl.[Name] AS PlaneName, 
	CONCAT(f.Origin, ' - ', f.Destination) AS Trip,
	lt.[Type] AS LuggageType
FROM Tickets AS t
JOIN Passengers AS p ON t.PassengerId = p.Id
JOIN Flights AS f ON t.FlightId = f.Id
JOIN Planes AS pl ON f.PlaneId = pl.Id
JOIN Luggages AS l ON t.LuggageId = l.Id
JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
ORDER BY FullName, PlaneName, Origin, Destination, LuggageType

-- Problem 15 Most Expesnive Trips
SELECT sq.FirstName, sq.LastName, sq.Destination, sq.Price
FROM(
	SELECT p.FirstName, p.LastName, f.Destination, t.Price, 
		DENSE_RANK() OVER(PARTITION BY p.FirstName, p.LastName ORDER BY t.Price DESC) As PriceRank
	FROM Tickets AS t
	JOIN Passengers AS p ON p.Id = t.PassengerId
	JOIN Flights AS f ON t.FlightId = f.Id
) AS sq
WHERE sq.PriceRank = 1
ORDER BY sq.Price DESC, sq.FirstName, sq.LastName, sq.Destination;

-- Problem 16 Destinations Info 
SELECT f.Destination, COUNT(t.Id) AS FilesCount
FROM Flights AS f
FULL JOIN Tickets AS t ON t.FlightId = f.Id
GROUP BY f.Destination
ORDER BY FilesCount DESC, f.Destination;

-- Problem 17 PSP
SELECT p.[Name], p.Seats, COUNT(t.PassengerId) AS [Count]
FROM Tickets AS t
FULL JOIN Flights AS f ON t.FlightId = f.Id
FULL JOIN Planes AS p ON f.PlaneId = p.Id
GROUP BY p.[Name], p.Seats
ORDER BY [Count] DESC, p.[Name], p.Seats;