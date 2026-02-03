using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models.Book
{
    public class CreateForm
    {
        [DisplayName("Titre : ")]
        [Required(ErrorMessage = "Le titre est obligatoire.")]
        [MaxLength(255, ErrorMessage = "Le titre ne peut dépasser 255 caractères.")]
        public string Title { get; set; }
        [DisplayName("Date de parution : ")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La date de parution doit être renseignée.")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Auteur : ")]
        [MaxLength(128, ErrorMessage = "L'auteur ne peut dépasser 128 caractères.")]
        public string? Author { get; set; }
        [DisplayName("ISBN : ")]
        [StringLength(13, MinimumLength = 10 , ErrorMessage = "Le format ISBN doit être compris entre 10 et 13 caractères.")]
        [RegularExpression(@"^[\dX]+$", ErrorMessage = "Le format ISBN n'est pas valide.")]
        public string? ISBN { get; set; }
    }
}
