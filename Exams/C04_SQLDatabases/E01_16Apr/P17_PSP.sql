SELECT p.[Name], p.Seats, COUNT(t.PassengerId) AS [Count]
FROM Tickets AS t
FULL JOIN Flights AS f ON t.FlightId = f.Id
FULL JOIN Planes AS p ON f.PlaneId = p.Id
GROUP BY p.[Name], p.Seats
ORDER BY [Count] DESC, p.[Name], p.Seats;