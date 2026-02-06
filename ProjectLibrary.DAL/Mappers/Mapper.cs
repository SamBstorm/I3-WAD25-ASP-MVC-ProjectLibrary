using Microsoft.Data.SqlClient;
using ProjectLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProjectLibrary.DAL.Mappers
{
    internal static class Mapper
    {
        public static Book ToBook(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Book()
            {
                BookId = (Guid)record[nameof(Book.BookId)],
                Title = (string)record[nameof(Book.Title)],
                Author = (record[nameof(Book.Author)] is DBNull) ? null : (string?)record[nameof(Book.Author)],
                ISBN = (record[nameof(Book.ISBN)] is DBNull) ? null : (string?)record[nameof(Book.ISBN)],
                ReleaseDate = (DateTime)record[nameof(Book.ReleaseDate)],
                RegisteredDate = (DateTime)record[nameof(Book.RegisteredDate)],
                DisabledDate = (record[nameof(Book.DisabledDate)] is DBNull) ? null : (DateTime?)record[nameof(Book.DisabledDate)]
            };
        }

        public static UserProfile ToUserProfile(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new UserProfile() {
                UserProfileId = (Guid)record[nameof(UserProfile.UserProfileId)],
                LastName = (string)record[nameof(UserProfile.LastName)],
                FirstName = (string)record[nameof(UserProfile.FirstName)],
                BirthDate = (DateTime)record[nameof(UserProfile.BirthDate)],
                Biography = (record[nameof(UserProfile.Biography)] is DBNull)? null: (string?)record[nameof(UserProfile.Biography)],
                ReadingSkill = (record[nameof(UserProfile.ReadingSkill)] is DBNull)? null: (byte?)record[nameof(UserProfile.ReadingSkill)],
                NewsLetterSubscribed = (bool)record[nameof(UserProfile.NewsLetterSubscribed)],
                FavoriteBook = (record[nameof(UserProfile.FavoriteBook)] is DBNull) ? null : (Guid?)record[nameof(UserProfile.FavoriteBook)],
                RegisteredDate = (DateTime)record[nameof(UserProfile.RegisteredDate)],
                DisabledDate = (record[nameof(UserProfile.DisabledDate)] is DBNull)?null:(DateTime?)record[nameof(UserProfile.DisabledDate)]
            };
        }
    
        public static User ToUser(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new User()
            {
                UserId = (Guid)record[nameof(User.UserId)],
                Email = (string)record[nameof(User.Email)],
                Password = "********",
                RegisteredDate = (DateTime)record[nameof(User.RegisteredDate)],
                DisabledDate = (record[nameof(User.DisabledDate)] is DBNull) ? null : (DateTime?)record[nameof(User.DisabledDate)],
            };
        }
    
        public static Category ToCategory (this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Category()
            {
                CategoryId = (int)record[nameof(Category.CategoryId)],
                CategoryName = (string)record[nameof(Category.CategoryName)]
            };
        }
    }
}
