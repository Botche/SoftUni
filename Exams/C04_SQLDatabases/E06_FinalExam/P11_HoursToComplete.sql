CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	DECLARE @hoursToWork INT;

	IF(@StartDate IS NULL OR @EndDate IS NULL)
	BEGIN
		RETURN 0
	END;

	SET @hoursToWork = DATEDIFF(HOUR, @StartDate, @EndDate);

	RETURN @hoursToWork;
END

 GO

 SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours 

   FROM Reports 