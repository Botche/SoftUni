CREATE PROC usp_EmployeesBySalaryLevel (@levelOfSalary VARCHAR(10))
AS
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @levelOfSalary;