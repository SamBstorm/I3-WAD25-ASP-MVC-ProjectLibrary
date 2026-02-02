using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.Common.Repositories
{
    public interface IBookRepository<TBook>
    {
        public IEnumerable<TBook> Get();
        public TBook Get(Guid bookId);
        public Guid Create(TBook entity);
        public void Update(Guid bookId, TBook entity);
        public void Delete(Guid bookId);
    }
}
