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
        #region UserProfile
        public static Models.UserProfile.ListItemViewModel ToListItem(this BLL.Entities.UserProfile entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.UserProfile.ListItemViewModel()
            {
                UserProfileId = entity.UserProfileId,
                LastName = entity.LastName,
                FirstName = entity.FirstName
            };
        }
        public static Models.UserProfile.DetailsViewModel ToDetails(this BLL.Entities.UserProfile entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.UserProfile.DetailsViewModel()
            {
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                YearsOld = entity.YearsOld,
                Biography = entity.Biography,
                ReadingSkill = entity.ReadingSkill,
                RegisterDaysCounter = entity.RegisterDaysCounter,
                NewsLetterSubscribed = entity.NewsLetterSubscribed
            };
        }
        public static BLL.Entities.UserProfile ToBLL(this Models.UserProfile.CreateForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Entities.UserProfile(
                entity.LastName,
                entity.FirstName,
                entity.BirthDate,
                entity.NewsLetterSubscribed);
        }
        public static BLL.Entities.UserProfile ToBLL(this Models.UserProfile.EditForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            /*return new BLL.Entities.UserProfile(
                Guid.NewGuid(),
                "Connor",
                "Sarah", 
                new DateTime(),
                entity.Biography,
                (byte?)entity.ReadingSkill,
                entity.NewsLetterSubscribed,
                DateTime.Now,
                null);*/
            return new BLL.Entities.UserProfile(
                entity.Biography,
                entity.ReadingSkill, 
                entity.NewsLetterSubscribed);
        }
        public static Models.UserProfile.EditForm ToEdit(this BLL.Entities.UserProfile entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.UserProfile.EditForm()
            {
                Biography = entity.Biography,
                ReadingSkill = entity.ReadingSkill,
                NewsLetterSubscribed = entity.NewsLetterSubscribed
            };
        }
        public static Models.UserProfile.DeleteViewModel ToDelete(this BLL.Entities.UserProfile entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.UserProfile.DeleteViewModel()
            {

                LastName = entity.LastName,
                FirstName = entity.FirstName
            };
        }
        #endregion
    }
}
