using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

namespace CentroCapacitacionEmergencias.Models
{
    [Table("Evaluaciones")]
    public class Evaluacion
    {
        public int EvaluacionId { get; set; }

        public int ParticipanteId { get; set; }
        public int CursoId { get; set; }
        public int DestrezaId { get; set; }

        public string TiempoRespuesta { get; set; }

        public int PuntajeFinal { get; set; }

        public bool Control1 { get; set; }
        public bool Control2 { get; set; }
        public bool Control3 { get; set; }

        public string Instructor { get; set; }

        public DateTime FechaEvaluacion { get; set; }

        public virtual Participante Participante { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Destreza Destreza { get; set; }
    }
}