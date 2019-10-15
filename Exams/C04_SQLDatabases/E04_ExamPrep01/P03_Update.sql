UPDATE Tickets
SET Price += Price * 0.13
FROM Flights AS f
JOIN Tickets AS t ON t.FlightId = f.Id
WHERE Destination = 'Carlsbad';