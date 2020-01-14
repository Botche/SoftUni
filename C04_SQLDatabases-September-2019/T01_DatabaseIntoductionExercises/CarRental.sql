CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate FLOAT(1) NOT NULL,
	WeeklyRate FLOAT(1) NOT NULL,
	MontlyRate FLOAT(1) NOT NULL,
	WeekendRate FLOAT(1) NOT NULL
)

INSERT INTO Categories ([CategoryName], [DailyRate], [WeeklyRate], [MontlyRate], [WeekendRate])
VALUES ('Second-Hand', 7.9, 8.2, 8.0, 8.1),
		('Factory new', 8.3, 8.6, 8.7, 8.9),
		('Field tested', 7.8, 8.3, 8.1, 8.0)

SELECT * FROM Categories

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY(1,1),
	PlateNumber INT NOT NULL,
	Manufacturer NVARCHAR(10) NOT NULL,
	Model NVARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT NOT NULL,
	Condition VARCHAR(20),
	Available BIT NOT NULL
)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, [Year], CategoryId, Doors, Condition, Available)
VALUES (1234, 'ABC', 'Punto', 2000, 2, 4, NULL, 1),
		(2234, 'BBC', '3', 2003, 1, 4, NULL, 0),
		(3234, 'CBC', 'Fiesta', 2006, 3, 2, NULL, 1)

SELECT * FROM Cars

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Title VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees  (FirstName, LastName, Title, Notes)
VALUES ('Pesho', 'Peshev', 'Leader', NULL),
		('Ivan', 'Ivanov', 'Co-Leader', NULL),
		('Petko', 'Petkov', 'Employee', NULL)

SELECT * FROM Employees 

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY(1,1),
	DriverLicenceNumber VARCHAR(10) NOT NULL,
	FullName VARCHAR(30) NOT NULL,
	[Address] VARCHAR(50) NOT NULL,
	City VARCHAR(30) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
VALUES ('AX 1234 EB', 'Ivan', 'ul.Ne znam 2', 'Sofia', 1000, NULL),
		('AX 3467 EB', 'Petur', 'ul.Ne znam 5', 'Gabrovo', 5300, NULL),
		('AX 3457 EB', 'George', 'ul.Ne znam 12', 'Sevlievo', 1642, NULL)

SELECT * FROM Customers

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel INT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE,
	EndDate DATE,
	TotalDays INT,
	RateApplied INT,
	TaxRate INT,
	OrderStatus VARCHAR(30),
	Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES (1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
		(2, 3, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
		(3, 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)

SELECT * FROM RentalOrders
