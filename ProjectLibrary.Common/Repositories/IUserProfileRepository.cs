using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.Common.Repositories
{
    public interface IUserProfileRepository<TUserProfile> : ICRUDRepository<TUserProfile, Guid>
    {
        public void SetFavoriteBook(Guid userProfileId, Guid? bookId);
    }
}
