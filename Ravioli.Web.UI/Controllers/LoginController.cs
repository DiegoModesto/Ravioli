using Ravioli.DAL.Concreto;
using Ravioli.Utility;
using Ravioli.Web.UI.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Ravioli.Web.UI.Controllers
{
    public class LoginController : Controller
    {
        readonly Util _util = new Util();

        public LoginController()
        {
            
        }
        
        public ActionResult Index()
        {
            if (_util.ChecarSessao())
                return RedirectToAction("../Admin");
            ViewBag.ClsAtual = "tela-login";
            ViewBag.Title = "Martin Luz Labs - Formulário de Login";
            return View("../Login/Index");
        }
        
        [HttpPost]
        public ActionResult Index(Login usuario)
        {
            ViewBag.ModoClass = _util.ChecarSessao() ? "logo-marca-cadastro" : "logo-marca-login";
            ViewBag.Title = _util.ChecarSessao() ? "Martin Luz Labs - Formulário de Cadastro" : "Martin Luz Labs - Formulário de Login";

            if (ModelState.IsValid)
            {
                var uControl = new ControleUsuario();

                try
                {
                    if (uControl.VerificarLogin(usuario.Email, usuario.Senha))
                    {
                        FormsAuthentication.SetAuthCookie(usuario.Email, false);
                        return RedirectToAction("../Admin");
                    }
                    else
                    {
                        TempData["Erro"] = true;
                        TempData["ErroMsg"] = "Usuário e/ou Senha Inválidos";
                        ViewBag.ClsAtual = "tela-login";
                        return View(usuario);
                    }
                }
                catch (Exception)
                {
                    TempData["Erro"] = true;
                    TempData["ErroMsg"] = "Erro ao conectar com a base de dados. Contato o Administrator do Sistema";
                    return View(usuario);
                }
            }
            else
            {

                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToList();

                TempData["ErroMsg"] = errorList;
                TempData["Erro"] = true;
                ViewBag.ClsAtual = "tela-login";
                return View(usuario);
            }
        }

        public ActionResult Deslogar(string id)
        {
            FormsAuthentication.SignOut();
            HttpContext.Cache.Remove("uControl");
            if (id == null)
                return RedirectToAction("../Login/Index");
            TempData["Erro"] = true;
            TempData["ErroMsg"] = "Erro na autenticidade do usuário. Caso o erro persista, contate o administrador. ErrNum: 0x005439443";
            return RedirectToAction("../Login/Index");
        }

        public ActionResult EsqueciMinhaSenha()
        {
            return View("EsqueciMinhaSenha");
        }
    }
}
