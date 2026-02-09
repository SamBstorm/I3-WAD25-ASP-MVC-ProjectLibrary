using ProjectLibrary.BLL.Entities;
using ProjectLibrary.BLL.Mappers;
using ProjectLibrary.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibrary.BLL.Services
{
    public class CategoryService : ICategoryRepository<Category>
    {
        private readonly ICategoryRepository<DAL.Entities.Category> _dalService;

        public CategoryService(ICategoryRepository<DAL.Entities.Category> dalService)
        {
            _dalService = dalService;
        }

        public int Create(Category entity)
        {
            return _dalService.Create(entity.ToDAL());
        }

        public void Delete(int id)
        {
            _dalService.Delete(id);
        }

        public IEnumerable<Category> Get()
        {
            return _dalService.Get().Select(dal => dal.ToBLL());
        }

        public Category Get(int id)
        {
            return _dalService.Get(id).ToBLL();
        }

        public IEnumerable<Category> GetByBook(Guid bookId)
        {
            return _dalService.GetByBook(bookId).Select(dal => dal.ToBLL());
        }

        public void Update(int id, Category entity)
        {
            _dalService.Update(id, entity.ToDAL());
        }
    }
}
