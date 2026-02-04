using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.BLL.Entities
{
    public class User
    {
        public Guid UserId { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime RegisteredDate { get; private set; }
        public DateTime? DisabledDate { get; private set; }

        public User(Guid userId, string email, string password, DateTime registeredDate, DateTime? disabledDate)
        {
            UserId = userId;
            Email = email;
            Password = password;
            RegisteredDate = registeredDate;
            DisabledDate = disabledDate;
        }

        public User(string email, string password) : this(Guid.NewGuid(),email, password, DateTime.Now, null)
        {
            
        }
    }
}
