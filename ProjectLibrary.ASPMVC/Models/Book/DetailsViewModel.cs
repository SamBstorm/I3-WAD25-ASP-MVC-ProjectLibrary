using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models.Book
{
    public class DetailsViewModel
    {
        [ScaffoldColumn(false)]
        public Guid BookId { get; set; }
        [DisplayName("Titre :")]
        public string Title { get; set; }
        [DisplayName("Auteur :")]
        public string? Author { get; set; }
        [DisplayName("ISBN :")]
        public string? ISBN { get; set; }
        [DisplayName("Date de parution :")]
        public DateTime ReleaseDate { get; set; }
    }
}
