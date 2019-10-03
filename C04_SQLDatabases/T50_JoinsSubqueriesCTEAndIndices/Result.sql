USE Softuni

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