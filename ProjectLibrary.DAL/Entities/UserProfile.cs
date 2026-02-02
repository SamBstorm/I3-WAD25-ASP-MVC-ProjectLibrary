using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.DAL.Entities
{
    public class UserProfile
    {
        public Guid UserProfileId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Biography { get; set; }
        public byte? ReadingSkill { get; set; }
        public bool NewsLetterSubscribed { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime? DisabledDate { get; set; }
    }
}
