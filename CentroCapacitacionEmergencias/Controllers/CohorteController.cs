using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CentroCapacitacionEmergencias.Data;
using CentroCapacitacionEmergencias.Models;

namespace CentroCapacitacionEmergencias.Controllers
{
    
    public class CohorteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cohorte
        public ActionResult Index()
        {
            return View(db.setCohortes.ToList());
        }

        // GET: Cohorte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cohorte cohorte = db.setCohortes.Find(id);
            if (cohorte == null)
            {
                return HttpNotFound();
            }
            return View(cohorte);
        }


        public ActionResult Create()
        {
            return View();
        }

        // POST: Cohorte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cohorte cohorte)
        {
            if (ModelState.IsValid)
            {

                if (cohorte.dFechaInicio < new DateTime(1753, 1, 1))
                {
                    cohorte.dFechaInicio = DateTime.Now;
                }

                if (cohorte.dFechaFin < new DateTime(1753, 1, 1))
                {
                    cohorte.dFechaFin = DateTime.Now;
                }
                cohorte.bCohorteArchivada = false;

                db.setCohortes.Add(cohorte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cohorte);
        }

        // GET: Cohorte/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cohorte cohorte = db.setCohortes.Find(id);
            if (cohorte == null)
            {
                return HttpNotFound();
            }
            return View(cohorte);
        }

        // POST: Cohorte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "CohorteId,sNombreCohorte")] Cohorte cohorte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cohorte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cohorte);
        }

        // GET: Cohorte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cohorte cohorte = db.setCohortes.Find(id);
            if (cohorte == null)
            {
                return HttpNotFound();
            }
            return View(cohorte);
        }

        // POST: Cohorte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cohorte cohorte = db.setCohortes.Find(id);
            db.setCohortes.Remove(cohorte);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
