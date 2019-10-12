SELECT sq.FullName, sq.Subjects, COUNT(sq.StudentId) AS Students
FROM(
	SELECT	CONCAT(t.FirstName,' ', t.LastName) AS FullName, 
			CONCAT(s.[Name], '-', s.Lessons) AS Subjects,
			st.StudentId
	FROM Teachers AS t
	JOIN Subjects AS s ON s.Id = t.SubjectId
	JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
) AS sq
GROUP BY sq.FullName, sq.Subjects
ORDER BY Students DESC, FullName, Subjects;