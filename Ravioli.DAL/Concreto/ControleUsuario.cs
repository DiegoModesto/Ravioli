using System;
using System.Linq;

namespace Ravioli.DAL.Concreto
{
    public class ControleUsuario
    {
        /// <summary>
        /// Verifica se usuário existe no contexto.
        /// </summary>
        public bool VerificarLogin(string login, string senha)
        {
            using (var ctx = new Entities())
            {
                senha = Cripto.Criptografar(senha);
                var busca = from u in ctx.tbUsuario
                                where u.email.Contains(login) && u.senha.Contains(senha) && u.statusId.Equals(1)
                                select u;

                if (busca.Count() != 1)
                    return false;
            }
            return true;
        }
    }
}
