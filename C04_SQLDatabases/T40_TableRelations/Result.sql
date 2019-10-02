-- Problem 1
CREATE DATABASE Relations;

USE Relations;

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY NOT NULL,
	PassportNumber VARCHAR(50) NOT NULL
);

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	Salary DECIMAL(15, 2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) NOT NULL
);

INSERT INTO Passports([PassportID], [PassportNumber]) VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2');

INSERT INTO Persons([FirstName], [Salary], [PassportID]) VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101);

SELECT *
  FROM Persons AS p
  JOIN Passports As pass ON pass.PassportID = p.PassportID;

-- Problem 2
CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	EstablishedOn DATE NOT NULL
);

CREATE TABLE Models(
	ModelID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
);

INSERT INTO Manufacturers ([Name], EstablishedOn)
VALUES ('BMW', '07/03/1916'),
		('Tesla', '01/01/2003'),
		('Lada', '01/05/1966');

INSERT INTO Models ([Name], ManufacturerID)
VALUES ('X1', 1),
		('I6', 1),
		('Model S', 2),
		('Model X', 2),
		('Model 3', 2),
		('Nova', 3);

-- Problem 3 
CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(30) NOT NULL
);

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	[Name] VARCHAR(30) NOT NULL
);

CREATE TABLE StudentsExams(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL
);

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentIdExamId
PRIMARY KEY(StudentID,ExamID);

ALTER TABLE StudentsExams
ADD FOREIGN KEY (StudentID)
REFERENCES Students(StudentID);

ALTER TABLE StudentsExams
ADD FOREIGN KEY (ExamID)
REFERENCES Exams(ExamID);

INSERT INTO Students
VALUES	('Mila'),
		('Toni'),
		('Ron');

INSERT INTO Exams
VALUES	('SpringMVC'),
		('Neo4j'),
		('Oracle 11g');

INSERT INTO StudentsExams
VALUES	(1,101),
		(1,102),
		(2,101),
		(3,103),
		(2,102),
		(2,103);

-- Problem 3
CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	[Name] NVARCHAR(30) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID) NOT NULL
)

-- Problem 4
CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE Items(
	ItemID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
);

CREATE TABLE Cities(
	CityID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
);

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY IDENTITY NOT NULL,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
);

CREATE TABLE OrderItems(
	OrderID INT  NOT NULL,
	ItemID INT NOT NULL
);

ALTER TABLE OrderItems
ADD CONSTRAINT PK_OrderID_ItemID
PRIMARY KEY(OrderID, ItemID);

ALTER TABLE OrderItems
ADD CONSTRAINT PK_OrderItems_Orders
FOREIGN KEY(OrderID)
REFERENCES Orders(OrderID);

ALTER TABLE OrderItems
ADD CONSTRAINT PK_OrderItems_Items
FOREIGN KEY(ItemID)
REFERENCES Items(ItemID);

-- Problem 6
CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY IDENTITY NOT NULL,
	SubjectName NVARCHAR(30) NOT NULL
);

CREATE TABLE Majors(
	MajorID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(30) NOT NULL
);

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY NOT NULL,
	StudentNumber INT NOT NULL,
	StudentName NVARCHAR(30) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
);

CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY IDENTITY NOT NULL,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(15,2) NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
);

CREATE TABLE Agenda(
	StudentID INT NOT NULL,
	SubjectID INT NOT NULL
);

ALTER TABLE Agenda
ADD CONSTRAINT PK_StudenID_SubjectID
PRIMARY KEY(StudentID, SubjectID);

ALTER TABLE Agenda
ADD CONSTRAINT FK_Agenda_Students
FOREIGN KEY(StudentID)
REFERENCES Students(StudentID);

ALTER TABLE Agenda
ADD CONSTRAINT FK_Agenda_Subjects
FOREIGN KEY(SubjectID)
REFERENCES Subjects(SubjectID);


-- Problem 9
SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
JOIN Peaks AS p 
ON m.ID = p.MountainID
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC;