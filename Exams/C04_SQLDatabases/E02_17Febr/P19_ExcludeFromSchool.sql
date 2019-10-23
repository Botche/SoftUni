CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	IF((SELECT COUNT(*)
		FROM Students
		WHERE Id = @StudentId) = 0)
	BEGIN
		RAISERROR('This school has no student with the provided id!', 16, 1)
		RETURN
	END;

	DELETE FROM StudentsSubjects
	FROM StudentsSubjects AS ss
	JOIN Students AS s ON s.Id = ss.StudentId
	WHERE s.Id = @StudentId
	
	DELETE FROM StudentsExams
	FROM StudentsExams AS se
	JOIN Students AS s ON s.Id = se.StudentId
	WHERE s.Id = @StudentId
	
	DELETE FROM StudentsTeachers
	FROM StudentsTeachers AS st
	JOIN Students AS s ON s.Id = st.StudentId
	WHERE s.Id = @StudentId

	DELETE FROM Students
	WHERE Id = @StudentId
END;