using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.Common.Repositories
{
    public interface IUserProfileRepository<TUserProfile>
    {
        public IEnumerable<TUserProfile> Get();
        public TUserProfile Get(Guid id);
        public Guid Create(TUserProfile entity);
        public void Update(Guid id, TUserProfile entity);
        public void Delete(Guid id);
    }
}
