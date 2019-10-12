SELECT s.[Name], AVG(ss.Grade) AS AverageGrade
FROM Subjects AS s
JOIN StudentsSubjects AS ss ON ss.SubjectId = s.Id
GROUP BY ss.SubjectId, s.[Name]
ORDER BY ss.SubjectId;