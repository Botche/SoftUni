SELECT TOP(10) s.FirstName, s.LastName, FORMAT(AVG(se.Grade), 'N2') AS Grade
FROM Students AS s 
JOIN StudentsExams AS se ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName;