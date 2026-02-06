CREATE PROCEDURE [dbo].[SP_Book_Remove_Category]
	@bookId UNIQUEIDENTIFIER,
	@categoryId INT
AS
BEGIN
	DELETE FROM [Book_Category]
		WHERE [BookId] = @bookId AND [CategoryId] = @categoryId
END
