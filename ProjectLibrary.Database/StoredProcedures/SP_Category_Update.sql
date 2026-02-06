CREATE PROCEDURE [dbo].[SP_Category_Update]
	@categoryId INT,
	@categoryName NVARCHAR(16)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE [Category]
		SET [CategoryName] = @categoryName
		WHERE [CategoryId] = @categoryId
END