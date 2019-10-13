CREATE PROC usp_FindByExtension(@extension VARCHAR(30))
AS
BEGIN
	SELECT f.Id, f.[Name], CONCAT(f.Size, 'KB') AS Size
	FROM Files AS f
	WHERE f.[Name] LIKE '%' + @extension
	ORDER BY f.Id, f.[Name], f.Size
END

