SELECT sq.[Full Name], f.Origin, f.Destination
FROM(
	SELECT t.FlightId, CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name] 
	FROM Passengers AS p
	JOIN Tickets AS t ON p.Id = t.PassengerId
) AS sq
JOIN Flights AS f ON sq.FlightId = f.Id
ORDER BY sq.[Full Name], f.Origin, f.Destination;