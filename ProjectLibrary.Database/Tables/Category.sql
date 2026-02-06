CREATE TABLE [dbo].[Category]
(
	[CategoryId] INT NOT NULL IDENTITY,
	[CategoryName] NVARCHAR(16) NOT NULL,
	CONSTRAINT PK_Category PRIMARY KEY ([CategoryId]),
	CONSTRAINT UK_Category_CategoryName UNIQUE ([CategoryName])
)
