BEGIN TRANSACTION

DECLARE @id UNIQUEIDENTIFIER
DECLARE @userIds TABLE ([UserId] UNIQUEIDENTIFIER NOT NULL)

INSERT INTO @userIds([UserId])
EXEC SP_User_Insert @email = N'samuel@mylibrary.be', @password = N'Test1234='

SELECT @id = [UserId] FROM @userIds
DELETE FROM @userIds

EXEC SP_UserProfile_Insert 
	@userid = @id,
	@lastname = N'Legrain',
	@firstname = N'Samuel',
	@birthdate = '1987-09-27',
	@biography = N'Lecteur novice, fan de fantasy et de science-fiction.',
	@readingSkill = 1, 
	@newsletterSubscribed = 0;

EXEC SP_User_SetAsAdministrator @userid = @id
	
INSERT INTO @userIds([UserId])
EXEC SP_User_Insert @email = N'michael@mylibrary.be', @password = N'Test1234='

SELECT @id = [UserId] FROM @userIds
DELETE FROM @userIds

EXEC SP_UserProfile_Insert 
	@userid = @id,
	@lastname = N'Person',
	@firstname = N'Michael',
	@birthdate = '1982-02-24',
	@biography = N'Lecteur amateur, fan de fantasy, d''horreur et de thiller.',
	@readingSkill = 3, 
	@newsletterSubscribed = 1;

INSERT INTO @userIds([UserId])
EXEC SP_User_Insert @email = N'thierry@mylibrary.be', @password = N'Test1234='

SELECT @id = [UserId] FROM @userIds
DELETE FROM @userIds

EXEC SP_UserProfile_Insert 
	@userid = @id,
	@lastname = N'Morre',
	@firstname = N'Thierry',
	@birthdate = '1975-06-21',
	@biography = N'Vrai fan de lecture! A dévoré la série "C# in Nutshell" en 3 jours! Fan de fantasy, d''horreur et de thiller.',
	@readingSkill = 6, 
	@newsletterSubscribed = 1;

COMMIT

GO