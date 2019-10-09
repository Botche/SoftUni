CREATE PROC usp_GetEmployeesSalaryAboveNumber (@money DECIMAL(18,4))
AS
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE e.Salary >= @money;