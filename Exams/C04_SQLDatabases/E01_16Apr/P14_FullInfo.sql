SELECT CONCAT(p.FirstName, ' ', p.LastName) AS FullName,
	pl.[Name] AS PlaneName, 
	CONCAT(f.Origin, ' - ', f.Destination) AS Trip,
	lt.[Type] AS LuggageType
FROM Tickets AS t
JOIN Passengers AS p ON t.PassengerId = p.Id
JOIN Flights AS f ON t.FlightId = f.Id
JOIN Planes AS pl ON f.PlaneId = pl.Id
JOIN Luggages AS l ON t.LuggageId = l.Id
JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
ORDER BY FullName, PlaneName, Origin, Destination, LuggageType