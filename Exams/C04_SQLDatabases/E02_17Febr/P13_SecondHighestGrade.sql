SELECT sq.FirstName, sq.LastName, sq.Grade
FROM(
	SELECT s.FirstName, s.LastName, se.Grade, ROW_NUMBER() OVER(PARTITION BY s.FirstName, s.LastName ORDER BY se.Grade DESC) AS GradeRank
	FROM Students AS s
	JOIN StudentsSubjects AS se ON se.StudentId = s.Id
) AS sq
WHERE sq.GradeRank = 2
ORDER BY sq.FirstName, sq.LastName, sq.GradeRank;