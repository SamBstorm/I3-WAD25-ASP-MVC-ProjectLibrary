using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models.UserProfile
{
    public class CreateForm
    {
        [DisplayName("Nom de famille : ")]
        [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
        [MaxLength(32, ErrorMessage = "Le nom de famille ne peut dépasser 32 caractères.")]
        public string LastName { get; set; }
        [DisplayName("Prénom : ")]
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [MaxLength(32, ErrorMessage = "Le prénom ne peut dépasser 32 caractères.")]
        public string FirstName { get; set; }
        [DisplayName("Date de naissance : ")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La date de naissance est obligatoire.")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Inscrit à la NewsLetter : ")]
        public bool NewsLetterSubscribed { get; set; }
    }
}
