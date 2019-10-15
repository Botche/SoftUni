CREATE PROC usp_CancelFlights
AS
BEGIN
	UPDATE Flights
	   SET
	       Flights.DepartureTime = NULL,
	       Flights.ArrivalTime = NULL
	 WHERE DATEDIFF(SECOND, ArrivalTime, DepartureTime) < 0
END