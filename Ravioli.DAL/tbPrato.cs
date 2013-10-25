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
    
    public partial class tbPrato
    {
        public tbPrato()
        {
            this.tbPratoRestaurante = new HashSet<tbPratoRestaurante>();
        }
    
        public int id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public Nullable<decimal> valor { get; set; }
        public int statusId { get; set; }
        public int categoriaId { get; set; }
        public int usuarioId { get; set; }
        public System.DateTime dtCriacao { get; set; }
    
        public virtual tbPratoCategoria tbPratoCategoria { get; set; }
        public virtual tbPratoStatus tbPratoStatus { get; set; }
        public virtual tbUsuario tbUsuario { get; set; }
        public virtual ICollection<tbPratoRestaurante> tbPratoRestaurante { get; set; }
    }
}
