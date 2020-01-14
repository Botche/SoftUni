CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(15,2), @yearlyInterestRate FLOAT, @numbersOfYears INT)
RETURNS DECIMAL(15,4)
AS
BEGIN
	RETURN @sum * (POWER(1 + @yearlyInterestRate, @numbersOfYears))
END;