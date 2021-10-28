using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SistemaGCSYNCATARI.Models;

namespace SistemaGCSYNCATARI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(Usuario usuarios, string ReturnUrl)
        {
            HomeController obj = new HomeController();
            if (IsValid(usuarios))
            {
                Session["Usuarios"] = usuarios.Id_usuario;

                FormsAuthentication.SetAuthCookie(usuarios.Correo, false);
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            TempData["mensaje"] = "El correo electrónico o contraseña que ingresaste no está correcto a una cuenta. Encuentra tu cuenta e inicia sesión.";

            return View(usuarios);
        }
        private bool IsValid(Usuario usuarios)
        {

            return usuarios.Autenticar();
        }

        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}