using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using CentroCapacitacionEmergencias.Filters;

namespace CentroCapacitacionEmergencias.Controllers
{
    [AuthFilter]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Auth");

            return View();
        }
    }
}