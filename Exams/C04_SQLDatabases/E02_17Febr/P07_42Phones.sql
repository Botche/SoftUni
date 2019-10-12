SELECT s.FirstName, s.[Address], s.Phone
FROM Students AS s
WHERE s.Phone LIKE '42%' AND s.MiddleName IS NOT NULL
ORDER BY s.FirstName;