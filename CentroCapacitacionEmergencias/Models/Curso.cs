using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroCapacitacionEmergencias.Models
{
    public class Curso
    {
        public int CursoId { get; set; }

        public string sNombreCurso { get; set; }

        public bool bCursoActivo { get; set; }

        public ICollection<ParticipanteCurso> ICCursoParticipantes { get; set; }
    }
}