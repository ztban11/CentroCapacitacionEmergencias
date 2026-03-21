using CentroCapacitacionEmergencias.Models;
using CentroCapacitacionEmergencias.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace CentroCapacitacionEmergencias.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string sMensaje;

            bool bValido = AuthService.bValidarUsuario(
                model.sNombreUsuario,
                model.sPassword,
                out sMensaje
            );

            if (bValido)
            {
                Session["Usuario"] = model.sNombreUsuario;

                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Error = sMensaje;

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}