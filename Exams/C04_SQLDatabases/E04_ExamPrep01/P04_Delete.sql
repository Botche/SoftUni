DELETE FROM Tickets
FROM Flights AS f
JOIN Tickets AS t ON t.FlightId = f.Id
WHERE Destination = 'Ayn Halagim';

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim';
