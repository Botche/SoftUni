SELECT pl.[Name], pl.Seats, COUNT(p.Id) AS [Passengers Count]
FROM Tickets AS t
FULL JOIN Flights AS f ON f.Id = t.FlightId
FULL JOIN Planes AS pl ON pl.Id = f.PlaneId
LEFT JOIN Passengers AS p ON p.Id = t.PassengerId
GROUP BY pl.Id, pl.[Name], pl.Seats
ORDER BY [Passengers Count] DESC, pl.[Name], pl.Seats;