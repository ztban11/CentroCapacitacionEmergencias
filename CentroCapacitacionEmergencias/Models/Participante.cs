using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroCapacitacionEmergencias.Models
{
    public class Participante
    {
        public int ParticipanteId { get; set; } // Participante ID Interno

        public string sTipoIdentificacion { get; set; }
        public string sNumeroIdentificacion { get; set; }

        public string sNombreCompleto { get; set; }

        public DateTime dtFechaNacimiento { get; set; }

        /* Residencia Participante */

        public string sProvincia { get; set; }
        public string sCanton { get; set; }
        public string sDistrito { get; set; }
        public string sDetallesResidencia { get; set; }

        public string sEstadoCivil { get; set; }

        public string sEmail { get; set; }

        public string sTelefono { get; set; }
        public string sDireccionResidencia { get; set; }
        public string sContactoEmergencia { get; set; }

        public bool bEstaActivo { get; set; } = true;

        public ICollection<ParticipanteCurso> ICCursosParticipante { get; set; }

        public int iIDCohorte { get; set; }
        public Cohorte Cohorte { get; set; }
    }
}