SELECT CONCAT(s.FirstName, ' ', s.LastName) AS FullName
FROM Students AS s
LEFT JOIN StudentsExams AS se ON se.StudentId = s.Id
WHERE se.ExamId IS NULL
ORDER BY FullName;