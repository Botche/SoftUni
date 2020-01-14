USE Geography;

-- Problem 12
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM MountainsCountries AS mc
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY Elevation DESC;

-- Problem 13
SELECT mc.CountryCode, COUNT(m.MountainRange) AS MountainRanges
FROM MountainsCountries AS mc
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE mc.CountryCode IN ('BG', 'US', 'RU')
GROUP BY mc.CountryCode;

-- Problem 14
SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName;

-- Problem 15
SELECT k.ContinentCode, k.CurrencyCode, k.CurrencyUsage
FROM (
	SELECT	c.ContinentCode,
			c.CurrencyCode,
			COUNT(c.CurrencyCode) AS [CurrencyUsage],
			DENSE_RANK() OVER(PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank]
	FROM Countries AS c
	JOIN Currencies AS cc ON cc.CurrencyCode = c.CurrencyCode
	GROUP BY c.ContinentCode, c.CurrencyCode
	HAVING COUNT(c.CurrencyCode) != 1
) AS k
WHERE k.[Rank] = 1
ORDER BY k.ContinentCode;

-- Problem 16
SELECT COUNT(c.ContinentCode) AS CountryCode
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL
GROUP BY mc.MountainId;

-- Problem 17
SELECT TOP(5)
	c.CountryName, 
	MAX(p.Elevation) AS HighestPeakElevation,
	MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId 
LEFT JOIN Peaks AS p ON p.MountainId = m.Id
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName;

-- Problem 18
SELECT TOP(5)
		sq.CountryName,
		ISNULL(sq.PeakName,'(no highest peak)') AS [Highest Peak Name],
		ISNULL(sq.Elevation, 0) AS [Highest Peak Elevation],
		ISNULL(sq.Elevation, '(no mountain)') AS [Mountain]
FROM(
	SELECT 
		c.CountryName,
		p.PeakName,
		p.Elevation,
		m.MountainRange,
		DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [Rank]
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m ON m.Id = mc.MountainId 
	LEFT JOIN Peaks AS p ON p.MountainId = m.Id
) AS sq
WHERE sq.[Rank] = 1
ORDER BY sq.CountryName, sq.PeakName;