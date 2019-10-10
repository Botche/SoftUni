CREATE PROC  usp_CalculateFutureValueForAccount (@accountId INT, @Rate FLOAT)
AS
	SELECT a.Id AS [Account Id],
			ah.FirstName,
			ah.LastName,
			a.Balance,
			dbo.ufn_CalculateFutureValue(a.Balance, @Rate, 5)
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accountId;