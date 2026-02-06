CREATE PROCEDURE [dbo].[SP_Category_Get_ById]
	@categoryId INT
AS
BEGIN
	SELECT [CategoryId], [CategoryName]
		FROM [Category]
		WHERE [CategoryId] = @categoryId
END