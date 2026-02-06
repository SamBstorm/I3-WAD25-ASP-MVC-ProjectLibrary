CREATE PROCEDURE [dbo].[SP_Book_Get_ByCategory]
	@categoryId INT
AS
BEGIN
	SELECT	[Book].[BookId], 
			[Title], 
			[Author],
			[ReleaseDate], 
			[ISBN],
			[RegisteredDate],
			[DisabledDate]
		FROM [Book] JOIN [Book_Category]
			ON [Book].[BookId] = [Book_Category].[BookId]
		WHERE [CategoryId] = @categoryId
END