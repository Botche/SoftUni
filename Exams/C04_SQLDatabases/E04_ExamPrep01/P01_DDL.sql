CREATE DATABASE Airport;

USE Airport;

CREATE TABLE Planes(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL,
);

CREATE TABLE Flights(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id)
);

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT CHECK(Age > 0) NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL,
);

CREATE TABLE LuggageTypes(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Type] VARCHAR(30) NOT NULL
);

CREATE TABLE Luggages(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
);

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(15,2) NOT NULL
);