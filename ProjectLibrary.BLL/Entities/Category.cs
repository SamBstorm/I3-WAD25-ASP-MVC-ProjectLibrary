using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.BLL.Entities
{
    public class Category
    {
        public int CategoryId { get; private set; }
        private string _categoryName;
        public string CategoryName { 
            get {
                return _categoryName;
            }
            private set {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException();
                if (value.Length > 16) throw new FormatException();
                _categoryName = value;
            } 
        }

        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
