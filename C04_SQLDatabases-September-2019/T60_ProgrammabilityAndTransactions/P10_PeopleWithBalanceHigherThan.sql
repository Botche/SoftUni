CREATE PROC usp_GetHoldersWithBalanceHigherThan (@balance DECIMAL(15,2))
AS
	SELECT ah.FirstName, ah.LastName
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON ah.Id = a.AccountHolderId
	GROUP BY  ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @balance
	ORDER BY ah.FirstName, ah.LastName;