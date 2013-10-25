using System;
using System.Web;
using System.Web.Security;

namespace Ravioli.Utility
{
    public class Util
    {
        public Util()
        {
            
        }
        public bool ChecarSessao()
        {
            try
            {
                var ses = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
                if (ses != null && ses.Value != string.Empty)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}