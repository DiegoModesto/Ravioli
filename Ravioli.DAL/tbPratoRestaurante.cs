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
    
    public partial class tbPratoRestaurante
    {
        public int id { get; set; }
        public int pratoId { get; set; }
        public int restauranteId { get; set; }
    
        public virtual tbPrato tbPrato { get; set; }
        public virtual tbRestaurante tbRestaurante { get; set; }
    }
}
