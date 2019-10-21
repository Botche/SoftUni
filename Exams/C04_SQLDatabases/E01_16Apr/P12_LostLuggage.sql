SELECT p.PassportId, p.[Address]
FROM Luggages AS l
FULL JOIN Passengers AS p ON l.PassengerId = p.Id
WHERE l.LuggageTypeId IS NULL
ORDER BY p.PassportId, p.[Address];