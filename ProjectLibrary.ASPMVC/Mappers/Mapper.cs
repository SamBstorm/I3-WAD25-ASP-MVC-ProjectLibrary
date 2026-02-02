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
        #endregion
    }
}
