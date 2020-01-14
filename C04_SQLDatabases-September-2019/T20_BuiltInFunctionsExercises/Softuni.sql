USE SoftUni

--Problem 1
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%';

--Problem 2
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%';

--Problem 3
SELECT FirstName 
FROM Employees
WHERE DepartmentId IN (3, 10)
AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005;

--Problem 4
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%';

--Problem 5
SELECT [Name]
FROM Towns
WHERE LEN([Name]) IN (5,6)
ORDER BY [Name];

--Problem 6
SELECT [TownId], [Name]
FROM Towns
WHERE [Name] LIKE 'B%' OR [Name] LIKE 'M%' OR [Name] LIKE 'K%' OR [Name] LIKE 'E%'
ORDER BY [Name];

--Problem 7
SELECT *
FROM Towns
WHERE [Name] NOT LIKE 'B%' AND [Name] NOT LIKE 'D%' AND [Name] NOT LIKE 'R%'
ORDER BY [Name];

--Problem 8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE DATEPART(YEAR,HireDate) > 2000;

--Problem 9
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5;

--Problem 10
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION by Salary order by EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC;

--Problem 11
SELECT *
    FROM
(
  SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION by Salary order by EmployeeID) AS [Rank]
    FROM Employees
   WHERE Salary BETWEEN 10000 AND 50000
)     AS MyRanking
   WHERE MyRanking.[Rank] = 2
ORDER BY MyRanking.Salary DESC;