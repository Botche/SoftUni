CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(30) NOT NULL,	
	LastName VARCHAR(30) NOT NULL,
	Title VARCHAR(30),
	Notes VARCHAR(MAX)
)

INSERT INTO Employees (FirstName,LastName)
VALUES ('Ivan', 'Ivanov'),
		('Iva', 'Ivan'),
		('Ivn', 'Ivanv')
		
CREATE TABLE Customers (
	AccountNumber INT  PRIMARY KEY NOT NULL,
	FirstName VARCHAR(30) NOT NULL,	
	LastName VARCHAR(30) NOT NULL,
	PhoneNumber INT,
	EmergencyName VARCHAR(30),
	EmergencyNumber INT,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers([AccountNumber], [FirstName], [LastName])
VALUES(12, 'Pesho', 'Petrov'),
		(13, 'Milenkata', 'Markov'),
		(14, 'Filip', 'Totev');

				

CREATE TABLE RoomStatus(
	[RoomStatus] VARCHAR(20) PRIMARY KEY NOT NULL CHECK(RoomStatus = 'Free' OR RoomStatus = 'Full' OR RoomStatus = 'Half'),
	[Notes] VARCHAR(MAX)
);

INSERT INTO RoomStatus([RoomStatus])
VALUES ('Free'),
		('Half'),
		('Full');

CREATE TABLE RoomTypes(
	[RoomType] VARCHAR(20) PRIMARY KEY NOT NULL,
[	Notes]VARCHAR(MAX)
);

INSERT INTO RoomTypes([RoomType])
VALUES	('Tripple'),
		('Double'),
		('Mezonet');

CREATE TABLE BedTypes(
	[BedType]  VARCHAR(20) PRIMARY KEY NOT NULL,
	[Notes]VARCHAR(MAX)
);

INSERT INTO BedTypes([BedType])
VALUES	('Single'),
		('Double'),
		('Tripple');

CREATE TABLE Rooms(
	[RoomNumber] INT PRIMARY KEY NOT NULL, 
	[RoomType] VARCHAR(20) FOREIGN KEY REFERENCES RoomTypes([RoomType]) NOT NULL,
	[BedType] VARCHAR(20) FOREIGN KEY REFERENCES BedTypes([BedType]) NOT NULL,
	[Rate] INT,
	[RoomStatus] VARCHAR(20) FOREIGN KEY REFERENCES RoomStatus([RoomStatus]) NOT NULL, 
	[Notes] VARCHAR(MAX)
);

INSERT INTO Rooms([RoomNumber], [RoomType], [BedType], [RoomStatus])
VALUES	(123, 'Tripple', 'Tripple', 'Free'),
		(1254, 'Mezonet', 'Single', 'Full'),
		(2563, 'Double', 'Single', 'Half');

CREATE TABLE Payments(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id]) NOT NULL,
	[PaymentDate] DATETIME,
	[AccountNumber] INT,
	[FirstDateOccupied] DATETIME,
	[LastDateOccupied] DATETIME,
	[TotalDays] INT,
	[AmountCharged] DECIMAL(15, 2),
	[TaxRate] INT, 
	[TaxAmount] DECIMAL(15, 2),
	[PaymentTotal] DECIMAL(15, 2), 
	[Notes] VARCHAR(MAX)
);

INSERT INTO Payments([EmployeeId])
VALUES	(2),
	(3),
	(1);

CREATE TABLE Occupancies(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id]) NOT NULL, 
	[DateOccupied] DATETIME, 
	[AccountNumber] INT, 
	[RoomNumber] INT, 
	[RateApplied] INT, 
	[PhoneCharge] INT, 
	[Notes] VARCHAR(MAX)
);

INSERT INTO Occupancies([EmployeeId])
VALUES	(2),
	(1),
	(3);

UPDATE Payments
SET TaxRate *= 0.97;

SELECT TaxRate FROM Payments

DELETE FROM Occupancies