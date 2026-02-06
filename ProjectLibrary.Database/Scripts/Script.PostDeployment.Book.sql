BEGIN TRANSACTION

DECLARE @id UNIQUEIDENTIFIER, @catId INT
DECLARE @bookIds TABLE([BookId] UNIQUEIDENTIFIER)

INSERT INTO @bookIds
EXEC [SP_Book_Insert] 
	@title = N'Belladonna', 
	@releaseDate = '2023-05-11', 
	@author = N'Adalyn Grace', 
	@isbn = '9782378762896'

SELECT @id = [BookId] FROM @bookIds
DELETE FROM @bookIds

SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Fantasy'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Young adult'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Romance'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId

INSERT INTO @bookIds
EXEC [SP_Book_Insert] 
	@title = N'Foxglove', 
	@releaseDate = '2024-01-03', 
	@author = N'Adalyn Grace', 
	@isbn = '9782378764043'	

SELECT @id = [BookId] FROM @bookIds
DELETE FROM @bookIds

SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Fantasy'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Young adult'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Romance'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId

INSERT INTO @bookIds
EXEC [SP_Book_Insert] 
	@title = N'Holly', 
	@releaseDate = '2025-11-27', 
	@author = N'Adalyn Grace', 
	@isbn = '9782378768003'

SELECT @id = [BookId] FROM @bookIds
DELETE FROM @bookIds

SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Fantasy'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Young adult'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Romance'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId

INSERT INTO @bookIds
EXEC [SP_Book_Insert] 
	@title = N'Wisteria', 
	@releaseDate = '2025-03-27', 
	@author = N'Adalyn Grace', 
	@isbn = '9782378766641'

SELECT @id = [BookId] FROM @bookIds
DELETE FROM @bookIds

SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Fantasy'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Young adult'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Romance'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId

INSERT INTO @bookIds
EXEC [SP_Book_Insert] 
	@title = N'N''invite pas la forêt à entrer', 
	@releaseDate = '2025-08-28', 
	@author = N'Drews C.G.', 
	@isbn = '9782378767396'
	
SELECT @id = [BookId] FROM @bookIds
DELETE FROM @bookIds

SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Horreur'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Young adult'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Suspense'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId

INSERT INTO @bookIds
EXEC [SP_Book_Insert] 
	@title = N'Phobos Origine', 
	@releaseDate = '2016-06-02', 
	@author = N'Victor Dixen', 
	@isbn = '9782221193204'

SELECT @id = [BookId] FROM @bookIds
DELETE FROM @bookIds

SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Science-Fiction'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Young adult'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Romance'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId

INSERT INTO @bookIds
EXEC [SP_Book_Insert] 
	@title = N'Phobos Tome 1', 
	@releaseDate = '2015-06-11', 
	@author = N'Victor Dixen', 
	@isbn = '9782221146637'

SELECT @id = [BookId] FROM @bookIds
DELETE FROM @bookIds

SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Science-Fiction'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Young adult'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Romance'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
INSERT INTO @bookIds

EXEC [SP_Book_Insert] 
	@title = N'Phobos Tome 2', 
	@releaseDate = '2015-11-19', 
	@author = N'Victor Dixen', 
	@isbn = '9782221146644'

SELECT @id = [BookId] FROM @bookIds
DELETE FROM @bookIds

SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Science-Fiction'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Young adult'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Romance'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId

INSERT INTO @bookIds
EXEC [SP_Book_Insert] 
	@title = N'Phobos Tome 3', 
	@releaseDate = '2016-11-24', 
	@author = N'Victor Dixen', 
	@isbn = '9782221195734'

SELECT @id = [BookId] FROM @bookIds
DELETE FROM @bookIds

SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Science-Fiction'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Young adult'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Romance'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId

INSERT INTO @bookIds
EXEC [SP_Book_Insert] 
	@title = N'Phobos Tome 4', 
	@releaseDate = '2017-11-23', 
	@author = N'Victor Dixen', 
	@isbn = '9782221202197'

SELECT @id = [BookId] FROM @bookIds
DELETE FROM @bookIds

SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Science-Fiction'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Young adult'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId
SELECT @catId = [CategoryId] FROM [Category] WHERE [CategoryName] = 'Romance'
EXEC SP_Book_Add_Category @bookId = @id, @categoryId = @catId

COMMIT

GO