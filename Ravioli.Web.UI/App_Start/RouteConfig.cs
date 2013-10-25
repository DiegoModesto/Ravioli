using System.Web.Mvc;
using System.Web.Routing;

namespace Ravioli.Web.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Esqueci Senha",
                url: "Login/Esqueci-Minha-Senha",
                defaults: new { controller = "Login", action = "EsqueciMinhaSenha" },
                namespaces: new[] { "Ravioli.Web.UI.Controllers" }
            );

            routes.MapRoute(
                name: "Deslogar",
                url: "Login/Sair/{id}",
                defaults: new { controller = "Login", action = "Deslogar", id = UrlParameter.Optional },
                namespaces: new[] { "Ravioli.Web.UI.Controllers" }
            );

            routes.MapRoute(
                name: "Login_Default",
                url: "Login/{action}",
                defaults: new { controller = "Login", action = "Index" },
                namespaces: new[] { "Ravioli.Web.UI.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Ravioli.Web.UI.Controllers" }
            );
        }
    }
}