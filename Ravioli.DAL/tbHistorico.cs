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
    
    public partial class tbHistorico
    {
        public int id { get; set; }
        public string mensagem { get; set; }
        public System.DateTime dataCriacao { get; set; }
        public int tipoId { get; set; }
        public int usuarioId { get; set; }
    
        public virtual tbHistoricoTipo tbHistoricoTipo { get; set; }
        public virtual tbUsuario tbUsuario { get; set; }
    }
}
