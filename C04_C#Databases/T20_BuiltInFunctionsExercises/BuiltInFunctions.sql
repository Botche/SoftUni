SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

SELECT FirstName 
FROM Employees
WHERE DepartmentId IN (3, 10)
AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005;