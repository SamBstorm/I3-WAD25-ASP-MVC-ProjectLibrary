CREATE PROCEDURE [dbo].[SP_Category_Delete]
	@categoryId Int
AS
BEGIN
	DELETE FROM [Category]
		WHERE [CategoryId] = @categoryId
END