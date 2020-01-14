USE Orders;

-- Problem 18
SELECT ProductName, OrderDate,DATEADD(DAY, 3, OrderDate) AS [Pay Due], DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

-- Problem 19
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	[BirthDate] DATE NOT NULL
);

INSERT INTO People ([Name],[BirthDate])
VALUES ('Victor', '2000-12-07 00:00:00.000');

SELECT [Name], 
	DATEDIFF(YEAR,BirthDate,GETDATE()) AS [Age in Years], 
	DATEDIFF(MONTH,BirthDate,GETDATE()) AS [Age in Monts],
	DATEDIFF(DAY,BirthDate,GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE,BirthDate,GETDATE()) AS [Age in Minutes]
FROM People;