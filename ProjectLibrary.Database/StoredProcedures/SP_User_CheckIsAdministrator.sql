CREATE PROCEDURE [dbo].[SP_User_CheckIsAdministrator]
	@userid UNIQUEIDENTIFIER
AS
BEGIN
	SELECT [UserId]
		FROM [Administrator]
		WHERE [UserId] = @userid
END