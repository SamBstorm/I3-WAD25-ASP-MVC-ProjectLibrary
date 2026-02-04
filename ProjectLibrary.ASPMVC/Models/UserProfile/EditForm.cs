using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models.UserProfile
{
    public class EditForm
    {
        [DisplayName("Biographie : ")]
        [DataType(DataType.MultilineText)]
        [MaxLength(512, ErrorMessage = "La biographie ne peut dépasser 512 caractères.")]
        public string? Biography { get; set; }
        [DisplayName("Niveau de lecture (nombre de livres par mois) : ")]
        [Range(1,6,ErrorMessage = "Le niveau de lecture n'est pas valide")]
        public ushort? ReadingSkill { get; set; }
        [DisplayName("Inscrit à la NewsLetter : ")]
        public bool NewsLetterSubscribed { get; set; }
    }
}
