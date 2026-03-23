using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroCapacitacionEmergencias.Models
{
    public class DashboardCursos
    {
        public int CohorteId { get; set; }
        public int CursoId { get; set; }

        public double TasaAprobacion { get; set; }

        public int ParticipantesCertificados { get; set; }

        public int TotalParticipantes { get; set; }

        public List<ParticipanteRiesgoVM> ParticipantesRiesgo { get; set; }

        public List<ParticipanteHorasVM> IntervencionPendiente { get; set; }
    }

    public class ParticipanteRiesgoVM
    {
        public int ParticipanteId { get; set; }

        public string Nombre { get; set; }

        public double PuntajePromedio { get; set; }
    }
    public class ParticipanteHorasVM
    {
        public int ParticipanteId { get; set; }

        public string Nombre { get; set; }

        public int HorasCompletadas { get; set; }

        public int HorasRequeridas { get; set; }
    }
}