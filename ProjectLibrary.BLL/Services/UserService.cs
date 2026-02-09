using ProjectLibrary.BLL.Entities;
using ProjectLibrary.BLL.Mappers;
using ProjectLibrary.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.BLL.Services
{
    public class UserService : IUserRepository<User>
    {
        private readonly IUserRepository<DAL.Entities.User> _dalService;

        public UserService(IUserRepository<DAL.Entities.User> dalService)
        {
            _dalService = dalService;
        }

        public bool CheckIsAdministrator(Guid userId)
        {
            return _dalService.CheckIsAdministrator(userId);
        }

        public Guid CheckPassword(string email, string password)
        {
            return _dalService.CheckPassword(email, password);
        }

        public Guid Create(User entity)
        {
            return _dalService.Create(entity.ToDAL());
        }

        public void RemoveAsAdministrator(Guid userId)
        {
            _dalService.RemoveAsAdministrator(userId);
        }

        public void SetAsAdministrator(Guid userId)
        {
            _dalService.SetAsAdministrator(userId);
        }
    }
}
