CREATE PROCEDURE [dbo].[SP_User_SetAsAdministrator]
	@userId UNIQUEIDENTIFIER
AS
BEGIN
	INSERT INTO [Administrator]
		VALUES (@userId)
END