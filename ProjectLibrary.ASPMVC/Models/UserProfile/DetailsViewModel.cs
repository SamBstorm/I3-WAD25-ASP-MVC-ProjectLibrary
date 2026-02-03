using System.ComponentModel;

namespace ProjectLibrary.ASPMVC.Models.UserProfile
{
    public class DetailsViewModel
    {
        [DisplayName("Nom de famille : ")]
        public string LastName { get; set; }
        [DisplayName("Prénom : ")]
        public string FirstName { get; set; }
        [DisplayName("Âge : ")]
        public ushort YearsOld { get; set; }
        [DisplayName("Nombre de jours en tant que membre : ")]
        public uint RegisterDaysCounter { get; set; }
        [DisplayName("Biographie : ")]
        public string? Biography { get; set; }
        [DisplayName("Niveau de lecture (nombre de livres par mois) : ")]
        public ushort? ReadingSkill { get; set; }
        [DisplayName("Inscrit à la NewsLetter : ")]
        public bool NewsLetterSubscribed { get; set; }
    }
}
