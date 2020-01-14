CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	DELETE
	  FROM EmployeesProjects
	 WHERE EmployeesProjects.EmployeeID IN (SELECT e.EmployeeID
	                                                    FROM Employees AS e
													   WHERE e.DepartmentID = @departmentId);
	UPDATE Departments
	   SET
	       Departments.ManagerID = NULL
	 WHERE Departments.DepartmentID = @departmentId;

	 UPDATE Employees
	    SET
	        Employees.ManagerID = NULL
	  WHERE Employees.ManagerID IN (SELECT e.EmployeeID
	                                            FROM Employees AS e
											   WHERE e.DepartmentID = @departmentId);

	DELETE
	  FROM Employees
	 WHERE Employees.DepartmentID = @departmentId;

	DELETE
	  FROM [dbo].[Departments]
	 WHERE [dbo].[Departments].[DepartmentID] = @departmentId;

	 SELECT COUNT(*)
       FROM Employees
      WHERE DepartmentID = @DepartmentId
END;