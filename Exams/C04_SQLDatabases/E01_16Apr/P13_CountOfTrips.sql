SELECT p.FirstName, p.LastName, COUNT(t.PassengerId) AS [Total Trips]
FROM Passengers AS p
FULL JOIN Tickets AS t ON p.Id = t.PassengerId
GROUP BY p.Id, p.FirstName, p.LastName
ORDER BY [Total Trips] DESC, p.FirstName, p.LastName;