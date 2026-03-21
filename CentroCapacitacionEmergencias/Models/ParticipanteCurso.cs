using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroCapacitacionEmergencias.Models
{
    public class ParticipanteCurso
    {
        public int ParticipanteCursoId { get; set; }

        public int iParticipanteID { get; set; }
        public Participante PParticipante { get; set; }

        public int iCursoID { get; set; }
        public Curso CCurso { get; set; }
    }
}