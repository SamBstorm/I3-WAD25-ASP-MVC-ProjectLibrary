using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.Common.Repositories
{
    public interface IBookRepository<TBook> : ICRUDRepository<TBook, Guid>
    {
        public IEnumerable<TBook> GetByCategory(int categoryId);
        public void AddCategory(Guid bookId, int categoryId);
        public void RemoveCategory(Guid bookId, int categoryId);
    }
}
