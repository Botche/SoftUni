CREATE PROC usp_GetTownsStartingWith (@str VARCHAR(30))
AS
	SELECT t.[Name]
	FROM Towns AS t
	WHERE t.[Name] LIKE @str + '%';