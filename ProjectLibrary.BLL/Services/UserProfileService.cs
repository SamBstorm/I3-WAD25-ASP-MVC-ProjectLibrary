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

        public UserProfileService(IUserProfileRepository<DAL.Entities.UserProfile> dalService)
        {
            _dalService = dalService;
        }

        public IEnumerable<UserProfile> Get()
        {
            return _dalService.Get().Select(dal => dal.ToBLL());
        }

        public UserProfile Get(Guid userProfileId)
        {
            return _dalService.Get(userProfileId).ToBLL();
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
    }
}
