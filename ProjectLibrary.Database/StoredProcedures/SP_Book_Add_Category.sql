CREATE PROCEDURE [dbo].[SP_Book_Add_Category]
	@bookId UNIQUEIDENTIFIER,
	@categoryId INT
AS
BEGIN
	PRINT CONCAT_WS(' ',@bookId, @categoryId)
	INSERT INTO [Book_Category]
		VALUES (@bookId, @categoryId)
END
