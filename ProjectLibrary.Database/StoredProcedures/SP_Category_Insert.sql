CREATE PROCEDURE [dbo].[SP_Category_Insert]
	@categoryName NVARCHAR(16)
AS
BEGIN
	INSERT INTO [Category] ([CategoryName])
		OUTPUT [inserted].[CategoryId]
		VALUES(@categoryName)
END