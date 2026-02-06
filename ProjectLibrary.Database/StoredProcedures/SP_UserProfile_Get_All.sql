CREATE PROCEDURE [dbo].[SP_UserProfile_Get_All]
AS
	BEGIN
	SELECT	[UserProfileId],
			[LastName],
			[FirstName],
			[BirthDate],
			[Biography],
			[ReadingSkill],
			[NewsLetterSubscribed],
			[FavoriteBook],
			[RegisteredDate],
			[DisabledDate]
		FROM [UserProfile]
	END