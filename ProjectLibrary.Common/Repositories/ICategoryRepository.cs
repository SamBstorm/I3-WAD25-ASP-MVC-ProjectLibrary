using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.Common.Repositories
{
    public interface ICategoryRepository<TCategory> : ICRUDRepository<TCategory, int>
    {
        public IEnumerable<TCategory> GetByBook(Guid bookId);
    }
}
