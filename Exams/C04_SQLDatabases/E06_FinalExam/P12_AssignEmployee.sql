CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS 
BEGIN
	IF((SELECT e.DepartmentId
		FROM Employees AS e
		WHERE e.Id = @EmployeeId) =
		(SELECT c.DepartmentId
		FROM Reports AS r
		JOIN Categories AS c ON c.Id = r.CategoryId
		WHERE r.Id = @ReportId))
	BEGIN
		UPDATE Reports 
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId 
	END
	ELSE
	BEGIN
		RAISERROR('Employee doesn''t belong to the appropriate department!',16,1)
	END
END