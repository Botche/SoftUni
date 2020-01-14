CREATE DATABASE Softuni

USE Softuni

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY(1,1),
	AddressText VARCHAR(30) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY(1,1),
	[FirstName] VARCHAR(30) NOT NULL,
	[MiddleName] VARCHAR(30),
	[LastName] VARCHAR(30) NOT NULL,
	JobTitle VARCHAR(30),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE,
	Salary DECIMAL(6,2),
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns (Name)
VALUES ('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas')

INSERT INTO Departments(Name)
VALUES ('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance')

INSERT INTO Employees (FirstName,MiddleName,LastName,JobTitle,DepartmentId,HireDate,Salary)
VALUES	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.0),
		('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.0),
		('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
		('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.0),
		('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)

SELECT * FROM Towns
ORDER BY Name

SELECT * FROM Departments
ORDER BY Name

SELECT * FROM Employees
ORDER BY Salary DESC
 
SELECT [Name] From Towns
ORDER BY Name

SELECT [Name] From Departments
ORDER BY Name

SELECT FirstName,LastName,JobTitle,Salary From Employees
ORDER BY Salary DESC

UPDATE Employees
SET Salary += Salary * 0.1

SELECT Salary From Employees