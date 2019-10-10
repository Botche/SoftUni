CREATE PROC usp_GetHoldersWithBalanceHigherThan (@balance DECIMAL(15,2))
AS
	SELECT ah.FirstName, ah.LastName
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON ah.Id = a.AccountHolderId
	WHERE SUM(a.Balance) > @balance
	GROUP BY  ah.FirstName, ah.LastName;