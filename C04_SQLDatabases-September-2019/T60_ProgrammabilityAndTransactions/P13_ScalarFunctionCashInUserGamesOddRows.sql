CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(50))
RETURNS TABLE
AS
	RETURN
	SELECT SUM(sq.Cash) AS SumCash
	FROM (
		SELECT	ug.Cash AS Cash,
				ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS [Row]
		FROM Games AS g
		JOIN UsersGames AS ug ON g.Id = ug.GameId
		WHERE g.[Name] = @gameName
	) AS sq
	WHERE sq.[Row] % 2 = 1;