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
    public class ParticipanteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Usuario"] == null)
            {
                filterContext.Result = RedirectToAction("Login", "Auth");
                return;
            }

            base.OnActionExecuting(filterContext);
        }

        // GET: Participante
        public ActionResult Index()
        {
            if (Session["Rol"] == null || Session["Rol"].ToString() != "Administrador")
            {
                return RedirectToAction("Index", "Dashboard");
            }
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
        public ActionResult Create()
        {
            ViewBag.iIDCohorte = new SelectList(db.setCohortes, "CohorteId", "sNombreCohorte");

            return View();
        }

        // POST: Participante/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sTipoIdentificacion,sNumeroIdentificacion,sNombreCompleto,dtFechaNacimiento,sProvincia,sCanton,sDistrito,sDetallesResidencia,sEstadoCivil,sEmail,sTelefono,sDireccionResidencia,sContactoEmergencia,bEstaActivo,iIDCohorte")] Participante participante)
        {
            db.setParticipantes.Add(participante);
            db.SaveChanges();

            return RedirectToAction("AsignarCursos", new { id = participante.ParticipanteId });

            /*  if (!ModelState.IsValid)
              {
                   db.setParticipantes.Add(participante);
                   db.SaveChanges();

                   return RedirectToAction("Index");
            var errores = ModelState.Values
             .SelectMany(v => v.Errors);

                foreach (var error in errores)
                {
                    System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
                ViewBag.iIDCohorte = new SelectList(db.setCohortes, "iCohorteID", "sNombreCohorte", participante.iIDCohorte);

            return View(participante);*/
        }

        // GET: Participante/Edit/5
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
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [HttpPost]
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


        public ActionResult AsignarCursos(int id)
        {
            var participante = db.setParticipantes.Find(id);

            if (participante == null)
                return HttpNotFound();

            ViewBag.Cohortes = new SelectList(db.setCohortes, "CohorteId", "sNombreCohorte");

            ViewBag.Cursos = db.setCursos
                .Where(c => c.bCursoActivo == true)
                .ToList();

            return View(participante);
        }

        [HttpPost]
        public ActionResult AsignarCursos(int id, int iIDCohorte, int[] cursosSeleccionados)
        {
            var participante = db.setParticipantes.Find(id);

            if (participante == null)
                return HttpNotFound();

            participante.iIDCohorte = iIDCohorte;

            foreach (var cursoId in cursosSeleccionados)
            {
                var vParticipanteCurso = new ParticipanteCurso
                {
                    iParticipanteID = participante.ParticipanteId,
                    iCursoID = cursoId
                };

                db.setParticipanteCursos.Add(vParticipanteCurso);
            }

            db.SaveChanges();

            TempData["Mensaje"] = "Asignación guardada correctamente.";

            return RedirectToAction("Index");
        }
    }
}
