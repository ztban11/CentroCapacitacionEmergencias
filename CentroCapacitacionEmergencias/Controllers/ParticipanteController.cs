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
    [Authorize(Roles = "Administrador,Instructor")]
    public class ParticipanteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Participante
        public ActionResult Index()
        {
            return View(db.setParticipantes.ToList());
        }

        // GET: Participante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.setParticipantes.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // GET: Participante/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Participante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "ParticipanteId,sTipoIdentificacion,sNumeroIdentificacion,sNombreCompleto,dtFechaNacimiento,sProvincia,sCanton,sDistrito,sDetallesResidencia,sEstadoCivil,sEmail,sTelefono,sDireccionResidencia,sContactoEmergencia,bEstaActivo,iIDCohorte")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                db.setParticipantes.Add(participante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(participante);
        }

        // GET: Participante/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.setParticipantes.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // POST: Participante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit([Bind(Include = "ParticipanteId,sTipoIdentificacion,sNumeroIdentificacion,sNombreCompleto,dtFechaNacimiento,sProvincia,sCanton,sDistrito,sDetallesResidencia,sEstadoCivil,sEmail,sTelefono,sDireccionResidencia,sContactoEmergencia,bEstaActivo,iIDCohorte")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(participante);
        }

        // GET: Participante/Deactivate
        [Authorize(Roles = "Administrador")]
        public ActionResult Deactivate(int? id)
        {
            Participante participante = db.setParticipantes.Find(id);

            if (participante == null)
                return HttpNotFound();

            participante.bEstaActivo = false;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: Participante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participante participante = db.setParticipantes.Find(id);
            db.setParticipantes.Remove(participante);
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
