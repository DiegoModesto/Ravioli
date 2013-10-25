using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ravioli.Web.UI.Areas.Dashboard.Models;

namespace Ravioli.Web.UI.Areas.Dashboard.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                var usrEmail = FormsAuthentication.Decrypt(System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value);
                var uControl = new Usuario(usrEmail.Name);
                uControl.Pagina = "esq-visao-geral";
                
                ViewBag.Title = "Bem Vindo " + uControl.Dados.UNome;
                ViewBag.Migalha = "Visão Geral > ";
                ViewBag.NomeUsuario = uControl.Dados.UNome;
                ViewBag.Foto = uControl.Dados.UFoto;
                HttpContext.Cache["uControl"] = HttpContext.Cache["uControl"] != null ? HttpContext.Cache["uControl"] : uControl;

                return View(uControl);
            }
            catch (Exception)
            {
                return Redirect("~/Login/Sair/1");
            }
        }
    }
}
