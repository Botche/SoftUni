CREATE TABLE ExcludedStudents(
	StudentId INT NOT NULL,
	StudentName VARCHAR(50) NOT NULL
);

CREATE TRIGGER tr_DeletedStudents ON Students FOR DELETE
AS
BEGIN
	INSERT INTO ExcludedStudents(StudentId, StudentName)
	SELECT d.Id, d.FirstName + ' ' + d.LastName FROM [DELETED] AS d
END