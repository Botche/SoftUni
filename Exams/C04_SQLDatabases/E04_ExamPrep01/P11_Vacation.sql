CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @priceForAll DECIMAL(15,2)

	IF(@peopleCount <= 0)
		RETURN 'Invalid people count!';

	
	SET @priceForAll = @peopleCount * (SELECT t.Price
							FROM Flights AS f
							JOIN Tickets AS t ON t.FlightId = f.Id
							WHERE f.Origin = @origin AND f.Destination = @destination
	);

	IF(@priceForAll IS NULL)
		RETURN 'Invalid flight!';


	RETURN 'Total price ' + CAST(@priceForAll AS VARCHAR(50))
END