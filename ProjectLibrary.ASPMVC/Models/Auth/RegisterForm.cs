using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models.Auth
{
    public class RegisterForm
    {
        [DisplayName("Adresse électronique : ")]
        [EmailAddress(ErrorMessage = "L'adresse électronique n'est pas d'un format valide.")]
        [Required(ErrorMessage = "L'adresse électronique est obligatoire.")]
        public string Email { get; set; }
        [DisplayName("Mot de passe : ")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&=\-+])[a-zA-Z\d@$!%*?&=\-+]{8,64}$", ErrorMessage = "Le mot de passe ne correspond pas à la sécurité minimale requise.")]
        [MinLength(8,ErrorMessage ="Le mot de passe doit avoir au minimum 8 caractères.")]
        [MaxLength(64,ErrorMessage = "Le mot de passe doit avoir au maximum 64 caractères.")]
        public string Password { get; set; }
        [DisplayName("Confirmation du mot de passe : ")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La confirmation du mot de passe est obligatoire.")]
        [Compare(nameof(Password), ErrorMessage = "Le mot de passe ne correspond pas.")]
        public string ConfirmPassword { get; set; }
        [DisplayName("J'accepte les termes des conditions d'utilisation de notre site.")]
        public bool AgreeTerms { get; set; }
    }
}
