CREATE PROCEDURE [dbo].[SP_User_RemoveAsAdministrator]
	@userid UNIQUEIDENTIFIER
AS
BEGIN
	DELETE FROM [Administrator]
		WHERE [UserId] = @userid
END