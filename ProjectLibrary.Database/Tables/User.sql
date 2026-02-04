CREATE TABLE [dbo].[User]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[Email] NVARCHAR(320) NOT NULL UNIQUE,
	[Password] VARBINARY(32) NOT NULL,
	[Salt] UNIQUEIDENTIFIER NOT NULL,
	[RegisteredDate] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[DisabledDate] DATETIME2
)


GO

CREATE TRIGGER [dbo].[TR_User_Delete]
    ON [dbo].[User]
    INSTEAD OF DELETE
    AS
    BEGIN
		DECLARE @deletedId UNIQUEIDENTIFIER = (SELECT [UserId] FROM [deleted]) 
        SET NoCount ON
		UPDATE [User]
			SET [DisabledDate] = GETDATE()
			WHERE [UserId] = @deletedId
    END