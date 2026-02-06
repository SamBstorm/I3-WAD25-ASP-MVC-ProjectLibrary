using ProjectLibrary.BLL.Entities;
using ProjectLibrary.BLL.Mappers;
using ProjectLibrary.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibrary.BLL.Services
{
    public class UserProfileService : IUserProfileRepository<UserProfile>
    {
        private readonly IUserProfileRepository<DAL.Entities.UserProfile> _dalService;
        private readonly IBookRepository<Book> _bookService;

        public UserProfileService(
            IUserProfileRepository<DAL.Entities.UserProfile> dalService, 
            IBookRepository<Book> bookService)
        {
            _dalService = dalService;
            _bookService = bookService;
        }

        public IEnumerable<UserProfile> Get()
        {
            return _dalService.Get().Select(dal => dal.ToBLL());
        }

        public UserProfile Get(Guid userProfileId)
        {
            DAL.Entities.UserProfile dalEntity = _dalService.Get(userProfileId);
            return dalEntity.ToBLL((dalEntity.FavoriteBook is null) ? null : _bookService.Get((Guid)dalEntity.FavoriteBook));
        }

        public Guid Create(UserProfile entity)
        {
            return _dalService.Create(entity.ToDAL());
        }

        public void Update(Guid userProfileId, UserProfile newData)
        {
            _dalService.Update(userProfileId, newData.ToDAL());
        }

        public void Delete(Guid userProfileId)
        {
            _dalService.Delete(userProfileId);
        }

        public void SetFavoriteBook(Guid userProfileId, Guid? bookId)
        {
            _dalService.SetFavoriteBook(userProfileId, bookId);
        }
    }
}
