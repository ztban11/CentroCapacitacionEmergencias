using CentroCapacitacionEmergencias.Data;
using CentroCapacitacionEmergencias.Models;
using CentroCapacitacionEmergencias.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;

using System.Web.Mvc;
using System.Web.Security;

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
            string sRol;

            bool bValido = AuthService.bValidarUsuario(
                model.sNombreUsuario,
                model.sPassword,
                out sMensaje,
                out sRol
            );

            if (bValido)
            {
                Session["Usuario"] = model.sNombreUsuario;

                Session["Rol"] = sRol;

                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Error = sMensaje;

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}