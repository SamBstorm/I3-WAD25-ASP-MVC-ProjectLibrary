using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models.Book
{
    public class DeleteViewModel
    {
        [DisplayName("Titre : ")]
        public string Title { get; set; }
        [DisplayName("Date de parution : ")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
