using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models.Rent
{
    public class ListItemViewModel
    {
        [ScaffoldColumn(false)]
        public Guid BookId { get; set; }
        [DisplayName("Titre : ")]
        public string Title { get; set; }
        [DisplayName("Date d'ajout : ")]
        public DateTime RentDate { get; set; }
    }
}
