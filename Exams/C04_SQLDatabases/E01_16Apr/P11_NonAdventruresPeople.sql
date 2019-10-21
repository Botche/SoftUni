SELECT p.FirstName, p.LastName, p.Age
FROM Passengers AS p
FULL JOIN Tickets AS t ON p.Id = t.PassengerId
WHERE t.Id IS NULL
ORDER BY p.Age DESC, p.FirstName, p.LastName;