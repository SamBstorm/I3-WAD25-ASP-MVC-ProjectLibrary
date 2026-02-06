CREATE TABLE [dbo].[UserProfile]
(
	[UserProfileId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [PK_UserProfile] PRIMARY KEY,
	[LastName] NVARCHAR(32) NOT NULL,
	[FirstName] NVARCHAR(32) NOT NULL,
	[BirthDate] DATE NOT NULL,
	[Biography] NVARCHAR(512),
	[ReadingSkill] TINYINT,
	[FavoriteBook] UNIQUEIDENTIFIER,
	[NewsLetterSubscribed] BIT NOT NULL DEFAULT 1,
	[RegisteredDate] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[DisabledDate] DATETIME2,
	CONSTRAINT [CK_UserProfile_ReadingSkill] CHECK ([ReadingSkill] IS NULL OR [ReadingSkill] BETWEEN 1 AND 6),
	CONSTRAINT [CK_UserProfile_DisabledDate] CHECK ([DisabledDate] IS NULL OR [DisabledDate] > [RegisteredDate]),
	CONSTRAINT [FK_UserProfile_User] FOREIGN KEY ([UserProfileId]) REFERENCES [User]([UserId]),
	CONSTRAINT [FK_UserProfile_Book] FOREIGN KEY ([FavoriteBook]) REFERENCES [Book]([BookId]),
);
GO

CREATE TRIGGER [TR_UserProfile_Delete] 
	ON [UserProfile]
	INSTEAD OF DELETE
	AS
	BEGIN
		SET NOCOUNT ON
		DECLARE @id UNIQUEIDENTIFIER
		SELECT @id = [UserProfileId]
			FROM [deleted]

		UPDATE [UserProfile]
			SET [DisabledDate] = GETDATE()
			WHERE [UserProfileId] = @id
	END;