SELECT sq.FirstName, sq.LastName, sq.Destination, sq.Price
FROM(
	SELECT p.FirstName, p.LastName, f.Destination, t.Price, 
		DENSE_RANK() OVER(PARTITION BY p.FirstName, p.LastName ORDER BY t.Price DESC) As PriceRank
	FROM Tickets AS t
	JOIN Passengers AS p ON p.Id = t.PassengerId
	JOIN Flights AS f ON t.FlightId = f.Id
) AS sq
WHERE sq.PriceRank = 1
ORDER BY sq.Price DESC, sq.FirstName, sq.LastName, sq.Destination;