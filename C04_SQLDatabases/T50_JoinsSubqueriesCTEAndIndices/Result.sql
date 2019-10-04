USE Softuni;

-- Problem 1
SELECT TOP(5) e.EmployeeId, e.JobTitle, a.AddressId, a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
ORDER BY a.AddressId

-- Problem 2
SELECT TOP(50) sq.FirstName, sq.LastName, t.[Name], sq.AddressText
FROM(
	SELECT e.FirstName, e.LastName, a.TownID, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
) AS sq
JOIN Towns AS t ON t.TownID = sq.TownID
ORDER BY sq.FirstName, sq.LastName;

-- Problem 3
SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID;

-- Problem 4
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID;


-- Problem 5
SELECT TOP(3) e.EmployeeID, e.FirstName
FROM Employees AS e
FULL JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID;

-- Problem 6
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > 1/1/1999 AND d.DepartmentID IN(3, 10)
ORDER BY e.HireDate;

-- Problem 7
SELECT TOP(5) sq.EmployeeID, sq.FirstName, p.[Name] AS [ProjectName]
FROM(
	SELECT e.EmployeeID, e.FirstName, ep.ProjectID
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
) AS sq
JOIN Projects AS p ON sq.ProjectID = p.ProjectID
WHERE p.StartDate > 13/08/2002 AND p.EndDate IS NULL
ORDER BY sq.EmployeeID;