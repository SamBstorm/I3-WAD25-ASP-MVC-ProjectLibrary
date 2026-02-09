CREATE TABLE [dbo].[Administrator]
(
	[UserId] UNIQUEIDENTIFIER CONSTRAINT PK_Administrator PRIMARY KEY,
	CONSTRAINT FK_Administrator_User FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
)
