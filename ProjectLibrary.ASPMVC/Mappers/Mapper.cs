namespace ProjectLibrary.ASPMVC.Mappers
{
    public static class Mapper
    {
        #region Book
        public static Models.Book.ListItemViewModel ToListItem(this BLL.Entities.Book entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.Book.ListItemViewModel() { 
                BookId = entity.BookId,
                Title = entity.Title,
                Author = entity.Author,
                ISBN = entity.ISBN
            };
        }

        public static Models.Book.DetailsViewModel ToDetails(this BLL.Entities.Book entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.Book.DetailsViewModel()
            {
                BookId = entity.BookId,
                Title = entity.Title,
                Author = entity.Author,
                ISBN = entity.ISBN,
                ReleaseDate = entity.ReleaseDate
            };
        }

        public static BLL.Entities.Book ToBLL(this Models.Book.CreateForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Entities.Book(
                entity.Title,
                entity.Author,
                entity.ISBN, 
                entity.ReleaseDate);
        }

        public static BLL.Entities.Book ToBLL(this Models.Book.EditForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Entities.Book(
                entity.Title,
                entity.Author,
                entity.ISBN,
                entity.ReleaseDate);
        }

        public static Models.Book.EditForm ToEdit(this BLL.Entities.Book entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.Book.EditForm()
            {
                Title = entity.Title,
                Author = entity.Author,
                ISBN = entity.ISBN,
                ReleaseDate = entity.ReleaseDate
            };
        }

        public static Models.Book.DeleteViewModel ToDelete (this BLL.Entities.Book entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.Book.DeleteViewModel()
            {
                Title = entity.Title,
                ReleaseDate = entity.ReleaseDate
            };
        }
        #endregion
    }
}
