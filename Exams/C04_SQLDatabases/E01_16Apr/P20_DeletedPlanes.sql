CREATE TABLE DeletedPlanes
(
	Id INT,
	[Name] VARCHAR(50),
	Seats INT,
	[Range] INT
);

CREATE TRIGGER tr_DeletedPlanes ON [dbo].[Planes] FOR DELETE
AS
BEGIN
	INSERT INTO DeletedPlanes
	(
	    [Id],
	    [Name],
	    [Seats],
	    [Range]
	)
	SELECT * FROM [DELETED] AS d
END