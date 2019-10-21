SELECT TOP(10) p.FirstName, p.LastName, t.Price
FROM Tickets AS t
JOIN Passengers AS p ON t.PassengerId = p.Id
ORDER BY t.Price DESC, p.FirstName, p.LastName;