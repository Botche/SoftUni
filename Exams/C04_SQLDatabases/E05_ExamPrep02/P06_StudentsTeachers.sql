SELECT s.FirstName, s.LastName, COUNT(st.TeacherId) AS [Total Count]
FROM Students AS s
JOIN StudentsTeachers AS st ON st.StudentId = s.Id
GROUP BY s.FirstName, s.LastName;