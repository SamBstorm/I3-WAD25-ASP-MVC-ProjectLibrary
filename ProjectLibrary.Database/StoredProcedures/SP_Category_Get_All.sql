CREATE PROCEDURE [dbo].[SP_Category_Get_All]
AS
BEGIN
	SELECT [CategoryId], [CategoryName]
		FROM [Category]
END