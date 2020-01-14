CREATE TABLE Users(
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	[ProfilePicture] IMAGE,
	[LastLoginTime] DATETIME,
	[IsDeleted] VARCHAR(5) NOT NULL CHECK([IsDeleted] = 'true' OR [IsDeleted] = 'false')
)

INSERT INTO Users([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES	('Botche1', '1234', NULL, NULL, 'true'),
		('Botche2', '12345', NULL, NULL, 'false'),
		('Botche3', '123456', NULL, NULL, 'true'),
		('Botche4', '1234567', NULL, NULL, 'true'),
		('Botche5', '12345678', NULL, NULL, 'false')

ALTER TABLE Users
DROP PK__Users__3214EC07C724D212

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUsername
PRIMARY KEY ([Id],[Username]) 

ALTER TABLE Users
ADD CONSTRAINT DF_CheckPass
CHECK(LEN([Password]) >= 4 )

ALTER TABLE Users
ADD CONSTRAINT DF_LoginTime
DEFAULT GETDATE() FOR [LastLoginTime]

INSERT INTO Users ([Username],[Password],[IsDeleted])
VALUES ('abv','false','true')

ALTER TABLE Users
DROP CONSTRAINT PK_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_ID
PRIMARY KEY ([Id])

ALTER TABLE Users
ADD CONSTRAINT DF_CheckUser
CHECK(LEN([Password]) >= 3 )


SELECT * FROM Users