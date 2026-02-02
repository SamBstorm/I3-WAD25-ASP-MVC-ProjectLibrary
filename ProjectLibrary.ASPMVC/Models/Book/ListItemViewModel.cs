using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models.Book
{
    public class ListItemViewModel
    {
        [ScaffoldColumn(false)]
        public Guid BookId { get; set; }
        [DisplayName("Titre :")]
        public string Title { get; set; }
        [DisplayName("Auteur :")]
        public string? Author { get; set; }
        [DisplayName("ISBN :")]
        public string? ISBN { get; set; }
    }
}
