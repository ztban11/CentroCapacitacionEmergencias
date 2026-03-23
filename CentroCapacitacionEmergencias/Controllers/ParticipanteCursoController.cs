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
    public class ParticipanteCursoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ParticipanteCurso
        public ActionResult Index()
        {
            return View(db.setParticipanteCursos.ToList());
        }

        // GET: ParticipanteCurso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipanteCurso participanteCurso = db.setParticipanteCursos.Find(id);
            if (participanteCurso == null)
            {
                return HttpNotFound();
            }
            return View(participanteCurso);
        }

        // GET: ParticipanteCurso/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.iParticipanteID = new SelectList(db.setParticipantes, "iParticipanteID", "sNombreCompleto");

            ViewBag.iCursoID = new SelectList(db.setCursos, "iCursoID", "sNombreCurso");

            return View();
        }

        // POST: ParticipanteCurso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "ParticipanteCursoId,iParticipanteID,iCursoID")] ParticipanteCurso participanteCurso)
        {
            if (ModelState.IsValid)
            {
                db.setParticipanteCursos.Add(participanteCurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iParticipanteID = new SelectList(db.setParticipantes, "iParticipanteID", "sNombreCompleto", participanteCurso.iParticipanteID);
            ViewBag.iCursoID = new SelectList(db.setCursos, "iCursoID", "sNombreCurso", participanteCurso.iCursoID);

            return View(participanteCurso);
        }


        // GET: ParticipanteCurso/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipanteCurso participanteCurso = db.setParticipanteCursos.Find(id);
            if (participanteCurso == null)
            {
                return HttpNotFound();
            }
            return View(participanteCurso);
        }

        // POST: ParticipanteCurso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit([Bind(Include = "ParticipanteCursoId,iParticipanteID,iCursoID")] ParticipanteCurso participanteCurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participanteCurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(participanteCurso);
        }

        // GET: ParticipanteCurso/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipanteCurso participanteCurso = db.setParticipanteCursos.Find(id);
            if (participanteCurso == null)
            {
                return HttpNotFound();
            }
            return View(participanteCurso);
        }

        // POST: ParticipanteCurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            ParticipanteCurso participanteCurso = db.setParticipanteCursos.Find(id);
            db.setParticipanteCursos.Remove(participanteCurso);
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
