CREATE PROCEDURE [dbo].[SP_UserProfile_SetFavoriteBook]
	@bookId UNIQUEIDENTIFIER,
	@userProfileId UNIQUEIDENTIFIER
AS
BEGIN
	UPDATE [UserProfile]
		SET [FavoriteBook] = @bookId
		WHERE [UserProfileId] = @userProfileId
END
