using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.Common.Repositories
{
    public interface IUserRepository<TUser>
    {
        public Guid Create(TUser entity);
        public Guid CheckPassword(string email, string password);
    }
}
