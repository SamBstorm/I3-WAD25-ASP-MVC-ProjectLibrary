using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.BLL.Entities
{
    public class UserProfile
    {
        public Guid UserProfileId { get; private set; }
        private string _lastName;
        public string LastName { 
            get { return _lastName; }
            private set {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
                if (value.Length > 32) throw new FormatException();
                _lastName = value;
            }
        }
        private string _firstName;
        public string FirstName {
            get { return _firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
                if (value.Length > 32) throw new FormatException();
                _firstName = value;
            }
        }
        public DateTime BirthDate { get; private set; }
        public ushort YearsOld
        {
            get
            {
                ushort years =(ushort)(DateTime.Now.Year - BirthDate.Year);
                DateTime nextBirthdate = BirthDate.AddYears(years);
                if (DateTime.Now < nextBirthdate) years--;
                return years;
            }
        }

        private string? _biography;
        public string? Biography { 
            get { 
                return _biography; 
            }
            set { 
                if(value is null)
                {
                    _biography = value;
                    return;
                }
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(value));
                if (value.Length > 512) throw new FormatException();
                _biography = value;
            } 
        }
        private ushort? _readingSkill;
        public ushort? ReadingSkill {
            get { return _readingSkill; }
            set {
                if (!(value is null) && (value < 1 || value > 6)) throw new ArgumentOutOfRangeException(nameof(value));
                _readingSkill = value;
            } 
        }
        public Book? FavoriteBook { get; set; }

        public bool NewsLetterSubscribed { get; set; }
        public DateTime RegisteredDate { get; private set; }
        public uint RegisterDaysCounter
        {
            get
            {
                return (uint)(DateTime.Now - RegisteredDate).TotalDays;
            }
        }
        public DateTime? DisabledDate { get; private set; }

        public UserProfile(string lastname, string firstname, DateTime birthdate, bool newsletterSubscribed = true) : this(Guid.NewGuid(), lastname, firstname, birthdate, null, null, newsletterSubscribed, DateTime.Now, null)
        {
        }

        public UserProfile(Guid userProfileId, string lastname, string firstname, DateTime birthdate, string? biography, byte? readingSkill, bool newsletterSubscribed, DateTime registeredDate, DateTime? disabledDate)
        {
            UserProfileId = userProfileId;
            LastName = lastname;
            FirstName = firstname;
            BirthDate = birthdate;
            Biography = biography;
            ReadingSkill = readingSkill;
            NewsLetterSubscribed = newsletterSubscribed;
            RegisteredDate = registeredDate;
            DisabledDate = disabledDate;
        }

        public UserProfile(string? biography, ushort? readingSkill, bool newsletterSubscribed)
        {
            Biography = biography;
            ReadingSkill = readingSkill;
            NewsLetterSubscribed = newsletterSubscribed;
        }

        public void Disable()
        {
            DisabledDate = DateTime.Now;
        }
    }
}
