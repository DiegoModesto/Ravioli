//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ravioli.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbRestaurante
    {
        public tbRestaurante()
        {
            this.tbPratoRestaurante = new HashSet<tbPratoRestaurante>();
            this.tbReserva = new HashSet<tbReserva>();
        }
    
        public int id { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public System.DateTime dtCadastro { get; set; }
        public int usuarioId { get; set; }
        public int statusId { get; set; }
    
        public virtual ICollection<tbPratoRestaurante> tbPratoRestaurante { get; set; }
        public virtual ICollection<tbReserva> tbReserva { get; set; }
        public virtual tbRestauranteStatus tbRestauranteStatus { get; set; }
        public virtual tbUsuario tbUsuario { get; set; }
    }
}
