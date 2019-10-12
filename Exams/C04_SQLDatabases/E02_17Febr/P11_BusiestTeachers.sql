SELECT TOP(10) t.FirstName, t.LastName, COUNT(st.StudentId) AS StudentsCount
FROM Teachers AS t
JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY t.FirstName, t.LastName
ORDER BY StudentsCount DESC, t.FirstName, t.LastName;