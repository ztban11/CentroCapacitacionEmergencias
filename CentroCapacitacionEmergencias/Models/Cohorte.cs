using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroCapacitacionEmergencias.Models
{
    public class Cohorte
    {
        public int CohorteId { get; set; }

        public string sNombreCohorte { get; set; }

        public ICollection<Participante> ICCohorteParticipantes { get; set; }
    }
}