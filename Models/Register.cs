using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dotNet.Models
{
    public class Register
    {
        [DisplayName("Nom d'utilisateur *")]
        [Required(ErrorMessage = "Nom d'utilisateur obligatoire")]
        public string UserName { get; set; }

        [DisplayName("Email *")]
        [Required(ErrorMessage = "Email obligatoire")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public string Email { get; set; }

        [DisplayName("Mot de passe *")]
        [Required(ErrorMessage = "Mot de passe obligatoire")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit comporter au moins 6 caractères.")]
        public string Password { get; set; }

        [DisplayName("Confirmer le mot de passe *")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }
}
