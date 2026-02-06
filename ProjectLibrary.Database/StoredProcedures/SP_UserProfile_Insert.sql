CREATE PROCEDURE [dbo].[SP_UserProfile_Insert]	
	@userid UNIQUEIDENTIFIER,
	@lastname NVARCHAR(32),
	@firstname NVARCHAR(32),
	@birthdate DATE,
	@biography NVARCHAR(512),
	@readingSkill TINYINT,
	@newsletterSubscribed BIT
AS
BEGIN
	SET NOCOUNT ON
	INSERT 
		INTO [UserProfile](
			[UserProfileId],
			[LastName],
			[FirstName],
			[BirthDate],
			[Biography],
			[ReadingSkill],
			[NewsLetterSubscribed])
		OUTPUT [inserted].[UserProfileId]
		VALUES (
			@userid,
			@lastname,
			@firstname,
			@birthdate,
			@biography,
			@readingSkill,
			@newsletterSubscribed
		)
END
