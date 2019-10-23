CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS VARCHAR(100)
AS
BEGIN
	DECLARE @countOfGrades INT;

	IF(@grade > 6)
	BEGIN
		RETURN 'Grade cannot be above 6.00!'
	END;

	DECLARE @studentName VARCHAR(30);

	SET @studentName = (SELECT s.FirstName
						FROM Students AS s
						WHERE s.Id = @studentId
	);

	IF(@studentName IS NULL)
	BEGIN
		RETURN 'The student with provided id does not exist in the school!'
	END;

	SET @countOfGrades = (SELECT COUNT(*)
							FROM StudentsSubjects AS ss
							WHERE ss.StudentId = @studentId AND Grade > @grade AND Grade <= @grade + 0.50
    );

	RETURN 'You have to update ' + CONVERT(VARCHAR(10), @countOfGrades) + ' grades for the student ' + @studentName;
END;

