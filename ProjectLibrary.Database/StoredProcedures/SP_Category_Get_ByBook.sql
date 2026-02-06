CREATE PROCEDURE [dbo].[SP_Category_Get_ByBook]
	@bookId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT	[Category].[CategoryId], 
			[CategoryName]
		FROM [Category] JOIN [Book_Category]
			ON [Category].[CategoryId] = [Book_Category].[CategoryId]
		WHERE [BookId] = @bookId
END