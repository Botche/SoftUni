SELECT	p.FirstName + ' ' + p.LastName AS [Full Name],
		f.Origin,
		f.Destination
FROM Flights AS f
JOIN Tickets AS t ON t.FlightId = f.Id
JOIN Passengers AS p ON p.Id = t.PassengerId
ORDER BY [Full Name], f.Origin, f.Destination;