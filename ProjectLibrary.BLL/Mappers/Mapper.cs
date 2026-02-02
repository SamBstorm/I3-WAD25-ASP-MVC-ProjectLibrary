using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.BLL.Mappers
{
    internal static class Mapper
    {
        #region Book
        public static BLL.Entities.Book ToBLL(this DAL.Entities.Book entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Entities.Book(
                entity.BookId,
                entity.Title,
                entity.Author,
                entity.ISBN,
                entity.ReleaseDate,
                entity.RegisteredDate,
                entity.DisabledDate
                );
        }

        public static DAL.Entities.Book ToDAL(this BLL.Entities.Book entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new DAL.Entities.Book()
            {
                BookId = entity.BookId,
                Title = entity.Title,
                Author = entity.Author,
                ISBN = entity.ISBN,
                ReleaseDate = entity.ReleaseDate,
                RegisteredDate = entity.RegisteredDate,
                //DisabledDate non reçu, car privé dans le BLL, et non nécessaire dans l'utilisation de la DAL : simple omission
                //OU
                //Si vraiment nécessaire dans la DAL
                //Remplacer la valeur réelle par une autre valeur cohérente
                //DisabledDate = (entity.IsActive) ? null : (DateTime?)DateTime.Now
            };
        }
        #endregion

        #region UserProfile

        public static BLL.Entities.UserProfile ToBLL(this DAL.Entities.UserProfile entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Entities.UserProfile(
                entity.UserProfileId,
                entity.LastName,
                entity.FirstName,
                entity.BirthDate,
                entity.Biography,
                entity.ReadingSkill,
                entity.NewsLetterSubscribed,
                entity.RegisteredDate,
                entity.DisabledDate
                );
        }

        public static DAL.Entities.UserProfile ToDAL(this BLL.Entities.UserProfile entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new DAL.Entities.UserProfile() { 
                UserProfileId = entity.UserProfileId,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                BirthDate = entity.BirthDate,
                Biography = entity.Biography,
                ReadingSkill = (byte?)entity.ReadingSkill,
                NewsLetterSubscribed = entity.NewsLetterSubscribed,
                RegisteredDate = entity.RegisteredDate,
                DisabledDate = entity.DisabledDate
            };
        }
        #endregion
    }
}
