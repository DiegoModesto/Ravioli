using System.ComponentModel.DataAnnotations;

namespace Ravioli.DAL
{
    /// <summary>
    /// Classe de Repositório para Usuários Logados
    /// </summary>
    public class UsrLogin
    {
        [Required]
        public int IdUsuario { get; set; }
        
        public int? IdRestaurante { get; set; }
        
        [Required]
        public int IdDepartamento { get; set; }
        
        public int? IdUsuarioPai { get; set; }
        
        [Required]
        public int IdCargo { get; set; }
        
        [Required]
        public string NomeUsuario { get; set; }
        
        [Required]
        [EmailAddress]
        public string EMailUsuario { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string SenhaUsuario { get; set; }
        
        public string NomeRestaurante { get; set; }
        
        [Required]
        public string NomeDepartamento { get; set; }
        
        public string NomeUsuarioPai { get; set; }
    }
}
