
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

        public ActionResult Index(int? cohorteId, int? cursoId)
        {
            var model = new DashboardCursos();

            //Cargar cohortes
            ViewBag.Cohortes = db.setCohortes.ToList();

            //Cargar cursos
            ViewBag.Cursos = db.setCursos.ToList();

            //Conteo base
            if (cohorteId.HasValue)
            {
                model.TotalParticipantes = db.setParticipantes
                    .Count(p => p.iIDCohorte == cohorteId);
            }

            model.CohorteId = cohorteId ?? 0;
            model.CursoId = cursoId ?? 0;

            if (cohorteId.HasValue && cursoId.HasValue)
            {
                var participantesCohorte = db.setParticipantes
                    .Where(p => p.iIDCohorte == cohorteId)
                        .Select(p => p.ParticipanteId)
                        .ToList();

                var evaluaciones = db.setEvaluaciones
                    .Where(e => participantesCohorte.Contains(e.ParticipanteId)
                    && e.CursoId == cursoId)
                    .ToList();

                var curso = db.setCursos
                    .FirstOrDefault(c => c.CursoId == cursoId);

                if (curso != null && evaluaciones.Count > 0)
                {
                    var aprobadas = evaluaciones
                        .Count(e => e.PuntajeFinal >= curso.PuntajeMinimoAprobacion);

                    model.TasaAprobacion =
                        (double)aprobadas / evaluaciones.Count * 100;
                }
            }

            if (model.TasaAprobacion >= 80)
                model.EstadoSemaforo = "verde";
            else if (model.TasaAprobacion >= 60)
                model.EstadoSemaforo = "amarillo";
            else if (model.TasaAprobacion > 0)
                model.EstadoSemaforo = "rojo";

            model.DestrezasRiesgo =
(
    from e in db.setEvaluaciones
    join d in db.setDestrezas
        on e.DestrezaId equals d.DestrezaID
    join c in db.setCursos
        on e.CursoId equals c.CursoId
    where e.CursoId == cursoId
        && e.PuntajeFinal < c.PuntajeMinimoAprobacion
    group e by new { d.DestrezaID, d.NombreDestreza } into g
    orderby g.Count() descending
    select new DestrezaRiesgo
    {
        DestrezaId = g.Key.DestrezaID,
        NombreDestreza = g.Key.NombreDestreza,
        CantidadParticipantes = g.Count()
    }
).ToList();

            if (model.DestrezasRiesgo == null)
            {
                model.DestrezasRiesgo = new List<DestrezaRiesgo>();
            }

            return View(model);
        }

        public ActionResult ParticipantesEnRiesgo(int destrezaId)
        {
            var participantesRiesgo = db.setEvaluaciones
                .Where(e => e.DestrezaId == destrezaId)
                .OrderBy(e => e.PuntajeFinal)
                .Select(e => new ParticipanteRiesgo
                {
                    NombreParticipante = e.Participante.sNombreCompleto,
                    Puntaje = e.PuntajeFinal,
                    NombreDestreza = e.Destreza.NombreDestreza
                })
                .ToList();

            return View(participantesRiesgo);
        }
    }
}