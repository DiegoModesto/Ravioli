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
    
    public partial class tbNotificacaoAlvo
    {
        public tbNotificacaoAlvo()
        {
            this.tbNotificacao = new HashSet<tbNotificacao>();
        }
    
        public int id { get; set; }
        public string nome { get; set; }
    
        public virtual ICollection<tbNotificacao> tbNotificacao { get; set; }
    }
}
