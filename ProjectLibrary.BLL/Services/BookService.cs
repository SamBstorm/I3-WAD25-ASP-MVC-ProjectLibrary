using ProjectLibrary.BLL.Entities;
using ProjectLibrary.BLL.Mappers;
using ProjectLibrary.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibrary.BLL.Services
{
    public class BookService : IBookRepository<Book>
    {
        private readonly IBookRepository<DAL.Entities.Book> _dalService;

        public BookService(IBookRepository<DAL.Entities.Book> dalService)
        {
            _dalService = dalService;
        }

        public IEnumerable<Book> Get()
        {
            return _dalService.Get().Select(book => book.ToBLL());
        }

        public Book Get(Guid bookId)
        {
            return _dalService.Get(bookId).ToBLL();
        }

        public Guid Create(Book entity)
        {
            return _dalService.Create(entity.ToDAL());
        }

        public void Update(Guid bookId, Book newData)
        {
            _dalService.Update(bookId, newData.ToDAL());
        }

        public void Delete(Guid bookId)
        {
            _dalService.Delete(bookId);
        }
    }
}
