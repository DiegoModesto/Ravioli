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
    
    public partial class tbPratoCategoria
    {
        public tbPratoCategoria()
        {
            this.tbPrato = new HashSet<tbPrato>();
        }
    
        public int id { get; set; }
        public string nome { get; set; }
        public int statusId { get; set; }
    
        public virtual ICollection<tbPrato> tbPrato { get; set; }
        public virtual tbPratoCategoriaStatus tbPratoCategoriaStatus { get; set; }
    }
}
