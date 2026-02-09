using ProjectLibrary.Common.Repositories;
using ProjectLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibrary.DAL.Services
{
    public class FakeBookService : IBookRepository<Book>
    {
        private static readonly List<Book> _library = new List<Book>();

        public void AddCategory(Guid bookId, int categoryId)
        {
            throw new NotImplementedException();
        }

        public Guid Create(Book entity)
        {
            entity.BookId = Guid.NewGuid();
            entity.RegisteredDate = DateTime.Now;
            _library.Add(entity);
            return entity.BookId;
        }

        public void Delete(Guid bookId)
        {
            Book entity = _library.SingleOrDefault(b => b.BookId == bookId);
            entity.DisabledDate = DateTime.Now;
        }

        public IEnumerable<Book> Get()
        {
            return _library;
        }

        public Book Get(Guid bookId)
        {
            return _library.SingleOrDefault(b => b.BookId == bookId);
        }

        public IEnumerable<Book> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void RemoveCategory(Guid bookId, int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid bookId, Book entity)
        {
            Book bookToEdit = _library.SingleOrDefault(b => b.BookId == bookId);
            bookToEdit.Title = entity.Title;
            bookToEdit.Author = entity.Author;
            bookToEdit.ISBN = entity.ISBN;
            bookToEdit.ReleaseDate = entity.ReleaseDate;
        }
    }
}
