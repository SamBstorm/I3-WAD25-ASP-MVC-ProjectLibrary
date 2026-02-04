CREATE PROCEDURE [dbo].[SP_User_CheckPassword]
	@email NVARCHAR(320),
	@password NVARCHAR(64)
AS
BEGIN
	SELECT [UserId]
		FROM [User]
		WHERE	[Email] = @email
			AND	[Password] = [dbo].[SF_SaltAndHash](@password, [Salt])
			AND ([DisabledDate] IS NULL OR GETDATE() < DATEADD(DAY, 30,[DisabledDate]))
END