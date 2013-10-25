using System.ComponentModel.DataAnnotations;

namespace Ravioli.Web.UI.Models
{
    public partial class Login
    {
        [Required(ErrorMessage = "E-Mail é requerido")]
        [EmailAddress(ErrorMessage = "Deve ser um E-Mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é requerido")]
        public string Senha { get; set; }
    }
}