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
        private readonly ICategoryRepository<Category> _categoryService;

        public BookService(
            IBookRepository<DAL.Entities.Book> dalService, 
            ICategoryRepository<Category> categoryService)
        {
            _dalService = dalService;
            _categoryService = categoryService;
        }

        public IEnumerable<Book> Get()
        {
            return _dalService.Get().Select(book => book.ToBLL());
        }

        public Book Get(Guid bookId)
        {
            IEnumerable<Category> categories = _categoryService.GetByBook(bookId);
            return _dalService.Get(bookId).ToBLL(categories);
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

        public IEnumerable<Book> GetByCategory(int categoryId)
        {
            return _dalService.GetByCategory(categoryId).Select(dal => dal.ToBLL());
        }

        public void AddCategory(Guid bookId, int categoryId)
        {
            _dalService.AddCategory(bookId, categoryId);
        }

        public void RemoveCategory(Guid bookId, int categoryId)
        {
            _dalService.RemoveCategory(bookId, categoryId);
        }
    }
}
