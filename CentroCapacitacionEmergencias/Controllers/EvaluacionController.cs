using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CentroCapacitacionEmergencias.Data;
using CentroCapacitacionEmergencias.Models;

namespace CentroCapacitacionEmergencias.Controllers
{
    public class EvaluacionController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var lista = db.setParticipanteCursos.ToList();

            foreach (var item in lista)
            {
                item.PParticipante = db.setParticipantes
                    .FirstOrDefault(p => p.ParticipanteId == item.iParticipanteID);

                item.CCurso = db.setCursos
                    .FirstOrDefault(c => c.CursoId == item.iCursoID);
            }

            return View(lista);
        }

        public ActionResult SeleccionarDestreza(int participantId, int cursoId)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var destrezas = db.setDestrezas
                .Where(d => d.CursoId == cursoId)
                .ToList();

            ViewBag.ParticipanteId = participantId;
            ViewBag.CursoId = cursoId;

            return View(destrezas);
        }

        public ActionResult Evaluacion(int participanteId, int cursoId, int destrezaId)
        {
            var destreza = db.setDestrezas
                             .FirstOrDefault(d => d.DestrezaID == destrezaId);

            ViewBag.ParticipanteId = participanteId;
            ViewBag.CursoId = cursoId;

            return View(destreza);
        }


        [HttpPost]
        public ActionResult GuardarEvaluacion(int ParticipanteId,int CursoId,int DestrezaId,string TiempoRespuesta,int PuntajeFinal,bool? control1,bool? control2,bool? control3)
        {
            bool c1 = control1 == true;
            bool c2 = control2 == true;
            bool c3 = control3 == true;

            bool puntoCriticoFallado = !c1 || !c2 || !c3;

            if (puntoCriticoFallado && PuntajeFinal > 70)
            {
                PuntajeFinal = 70;
            }

            using (var db = new ApplicationDbContext())
            {

                Evaluacion nuevaEvaluacion = new Evaluacion();

                nuevaEvaluacion.ParticipanteId = ParticipanteId;
                nuevaEvaluacion.CursoId = CursoId;
                nuevaEvaluacion.DestrezaId = DestrezaId;

                nuevaEvaluacion.TiempoRespuesta = TiempoRespuesta;
                nuevaEvaluacion.PuntajeFinal = PuntajeFinal;

                nuevaEvaluacion.Control1 = c1;
                nuevaEvaluacion.Control2 = c2;
                nuevaEvaluacion.Control3 = c3;

                nuevaEvaluacion.Instructor = User.Identity.Name;

                nuevaEvaluacion.FechaEvaluacion = DateTime.Now;

                db.setEvaluaciones.Add(nuevaEvaluacion);

                db.SaveChanges();
            }

            TempData["mensaje"] = "Evaluación almacenada correctamente";

            return RedirectToAction("Index");
        }

        public ActionResult EjecutarEvaluacion(int participantId, int cursoId, int destrezaId)
        {
            ViewBag.ParticipantId = participantId;
            ViewBag.CursoId = cursoId;
            ViewBag.DestrezaId = destrezaId;

            return View();
        }

    }
}