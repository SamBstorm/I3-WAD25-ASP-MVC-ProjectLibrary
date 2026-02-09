using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectLibrary.BLL.Entities
{
    public class Book
    {
        public Guid BookId { get; private set; }
        public string Title { get; private set; }
        public string? Author { get; set; }
        private string? _isbn;
        public string? ISBN
        {
            get { return _isbn; }
            private set {
                if(value is null)
                {
                    _isbn = value;
                    return;
                }
                if (value.Length > 13) throw new FormatException();
                if (!Regex.IsMatch(value, @"^[\dX]{10,13}$")) throw new FormatException();
                _isbn = value;
            }
        }
        public DateTime ReleaseDate { get; private set; }
        public DateTime RegisteredDate { get; private set; }
        private DateTime? _disabledDate;
        public bool IsActive { get { return _disabledDate is null; } }
        public IEnumerable<Category> Categories { get; set; }

        public Book(Guid bookId, string title, string? author, string? isbn, DateTime releaseDate, DateTime registeredDate, DateTime? disabledDate)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            ISBN = isbn;
            ReleaseDate = releaseDate;
            RegisteredDate = registeredDate;
            if (!(disabledDate is null) && disabledDate < RegisteredDate) throw new ArgumentException(nameof(disabledDate));
            _disabledDate = disabledDate;
        }

        public Book(string title, string? author, string? isbn, DateTime releaseDate)
        {
            BookId = Guid.NewGuid();
            Title = title;
            Author = author;
            ISBN = isbn;
            ReleaseDate = releaseDate;
            RegisteredDate = DateTime.Now;
        }

        public void Disable()
        {
            _disabledDate = DateTime.Now;
        }

    }
}
