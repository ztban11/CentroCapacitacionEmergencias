
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CentroCapacitacionEmergencias.Data;
using CentroCapacitacionEmergencias.Models;

namespace CentroCapacitacionEmergencias.Controllers
{
    public class MonitoreoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var model = new DashboardCursos();

            model.TotalParticipantes = db.setParticipantes.Count();

            return View(model);
        }
    }
}