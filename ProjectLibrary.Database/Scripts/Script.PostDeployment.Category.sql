BEGIN TRANSACTION

EXEC SP_Category_Insert @categoryName = N'Romance'
EXEC SP_Category_Insert @categoryName = N'Fantasy'
EXEC SP_Category_Insert @categoryName = N'Thriller'
EXEC SP_Category_Insert @categoryName = N'Polar'
EXEC SP_Category_Insert @categoryName = N'Science-Fiction'
EXEC SP_Category_Insert @categoryName = N'Horreur'
EXEC SP_Category_Insert @categoryName = N'Suspense'
EXEC SP_Category_Insert @categoryName = N'Jeunesse'
EXEC SP_Category_Insert @categoryName = N'Young adult'
EXEC SP_Category_Insert @categoryName = N'Adult'

COMMIT

GO