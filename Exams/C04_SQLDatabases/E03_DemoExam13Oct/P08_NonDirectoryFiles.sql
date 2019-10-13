SELECT fi.Id, fi.[Name], CONCAT(fi.Size, 'KB') AS Size
FROM Files AS f
RIGHT JOIN Files AS fi ON fi.Id = f.ParentId
WHERE f.Id IS NULL
ORDER BY f.Id, f.[Name], f.Size DESC;