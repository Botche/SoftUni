USE Diablo;

-- Problem 14
SELECT TOP(50) [Name], FORMAT([Start],'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, [Start]) IN(2011,2012)
ORDER BY [Start], [Name];

-- Problem 15
SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username;

-- Problem 16
SELECT [Username],[IpAddress]
FROM Users
WHERE IpAddress LIKE ('___.1%.%.___')
ORDER BY [Username];

-- Problem 17
SELECT [Name], 
	CASE
		WHEN DATEPART(HOUR,[Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR,[Start]) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR,[Start]) < 24 THEN 'Evening'
	END AS [Part of the Day],
	CASE 
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration <= 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END AS [DurationName]
FROM Games
ORDER BY [Name], [DurationName], [Part of the Day];