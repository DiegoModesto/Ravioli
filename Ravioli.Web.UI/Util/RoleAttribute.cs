using System.Web;
using System.Web.Mvc;

namespace Ravioli.Utility
{
    public class RoleAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.Request.IsAuthenticated)
                return false;

            return true;
        }
    }
}