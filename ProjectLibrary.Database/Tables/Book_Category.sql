CREATE TABLE [dbo].[Book_Category]
(
	[BookId] UNIQUEIDENTIFIER NOT NULL,
	[CategoryId] INT NOT NULL,
	CONSTRAINT [PK_Book_Category] PRIMARY KEY ([BookId], [CategoryId]),
	CONSTRAINT [FK_Book_Category_Book] FOREIGN KEY ([BookId]) REFERENCES [Book]([BookId]),
	CONSTRAINT [FK_Book_Category_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([CategoryId])
)
